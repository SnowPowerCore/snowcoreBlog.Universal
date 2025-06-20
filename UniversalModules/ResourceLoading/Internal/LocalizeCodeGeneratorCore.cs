﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using snowcoreBlog.ResourceLoading.Implementations.Internal.Helper;

namespace snowcoreBlog.ResourceLoading.Implementations.Internal;

internal class LocalizeCodeGeneratorCore
{
    public SourceText CreateClass(GeneratorData generatorData)
    {
        var sourceAsString = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.ParseName(generatorData.Namespace))
            .WithLeadingTrivia(SyntaxFactory.Comment(CreateFileHeader()))
            .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System")))
            .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Globalization")))
            .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.ParseName("System.Collections.Generic")))
            .AddUsings(SyntaxFactory.UsingDirective(SyntaxFactory.NameEquals(SyntaxFactory.IdentifierName("Translations")), SyntaxFactory.ParseName("System.Collections.Generic.Dictionary<string, string>")))
            .AddMembers(SyntaxFactory.ClassDeclaration(generatorData.GeneratedClassName)
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.SealedKeyword))
                .AddModifiers(SyntaxFactory.Token(SyntaxKind.PartialKeyword))
                .AddMembers(LocalizationProviderProperty())
                .AddMembers(GetAllMethod())
                .AddMembers(GetStringMethod())
                .AddMembers(CreateLocalizationProviderClass(generatorData))
                .AddMembers(ProjectTranslationsToMemberDeclarations(generatorData.InvariantTranslationData)))
            .NormalizeWhitespace()
            .ToFullString();

        return SourceText.From(sourceAsString, Encoding.UTF8);
    }

    private static MemberDeclarationSyntax LocalizationProviderProperty() =>
        SyntaxFactory.ParseMemberDeclaration("private static readonly LocalizationProvider provider = new LocalizationProvider();");

    private static MemberDeclarationSyntax GetAllMethod() =>
        SyntaxFactory.ParseMemberDeclaration("public static IDictionary<string, string> GetAll(CultureInfo cultureInfo = null) => provider.GetValues(cultureInfo ?? CultureInfo.CurrentUICulture);");

    private static MemberDeclarationSyntax GetStringMethod() =>
        SyntaxFactory.ParseMemberDeclaration("public static string GetString(string key, CultureInfo cultureInfo = null) => provider.GetValue(key, cultureInfo ?? CultureInfo.CurrentUICulture);");

    private MemberDeclarationSyntax[] ProjectTranslationsToMemberDeclarations(TranslationData translationData, string parentKey = "")
    {
        return (from translation in translationData
            let key = string.IsNullOrEmpty(parentKey) ? translation.Key : $"{parentKey}::{translation.Key}"
            select translation.Value switch
            {
                string value => CreateTranslationAccessProperty(translation.Key, key, value),
                TranslationData child => CreateNestedTranslationAccessClass(translation.Key, key, child),
                _ =>  throw new ArgumentOutOfRangeException(nameof(translation.Value))
            }).ToArray();
    }

    private MemberDeclarationSyntax CreateNestedTranslationAccessClass(string className, string translationKey, TranslationData next) =>
        SyntaxFactory.ClassDeclaration(className)
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword))
            .AddModifiers(SyntaxFactory.Token(SyntaxKind.StaticKeyword))
            .AddMembers(ProjectTranslationsToMemberDeclarations(next, translationKey));


    private static MemberDeclarationSyntax CreateTranslationAccessProperty(string propertyName, string translationKey, string translationValue)
    {
        var member = $"""
            public static string {propertyName} 
                => provider.GetValue("{translationKey}", CultureInfo.CurrentUICulture); 
            """;

        return SyntaxFactory.ParseMemberDeclaration(member)!
            .WithLeadingTrivia(SyntaxFactory.Comment(CreateMemberHeader(translationValue)));
    }
    
    private static ClassDeclarationSyntax CreateLocalizationProviderClass(GeneratorData context)
    {
        var syntaxNode = CSharpSyntaxTree.ParseText(
            @"
                    private class LocalizationProvider 
                    {
                        delegate bool SelectorFunc<T>(Translations translations, out T arg);

                        internal string GetValue(string key, CultureInfo cultureInfo)
                        {
                            bool ValueSelector(Translations translations, out string value)
                            {
                                if (translations.TryGetValue(key, out value))
                                    return true;

                                value = key;
                                return false;
                            }

                            return TraverseCultures<string>(cultureInfo, ValueSelector);
                        }

                        internal IDictionary<string, string> GetValues(CultureInfo cultureInfo)
                        {
                            bool ValueSelector(Translations translations, out Translations value)
                            {
                                value = translations;
                                return true;
                            }

                            return TraverseCultures<Translations>(cultureInfo, ValueSelector);
                        }

                        private T TraverseCultures<T>(CultureInfo cultureInfo, SelectorFunc<T> selectorFunc)
                        {
                            if (resources.TryGetValue(cultureInfo, out Translations translations))
                            {
                                if (selectorFunc(translations, out T result) || cultureInfo == CultureInfo.InvariantCulture)
                                    return result;
                            }

                            return TraverseCultures<T>(cultureInfo.Parent, selectorFunc);
                        }
                    }   
                ").GetRoot();

        return ((ClassDeclarationSyntax)syntaxNode.DescendantNodes().First())
            .AddMembers(GetTranslationDictionaryFieldDeclaration(context))
            .AddMembers(GetResourceDictionaryFieldDeclaration(context.CultureData));
    }

    private static MemberDeclarationSyntax[] GetTranslationDictionaryFieldDeclaration(GeneratorData context) =>
        context.CultureData
            .Select(cd =>
            {
                var entries = cd.Translations
                    .Flatten()
                    .Select(t => $"{{ \"{t.Key}\", \"{EscapeValue(t.Value)}\" }},");

                return $@"private static readonly Translations {cd.NormalizedKey} = new()
                            {{
                                {string.Join("\r\n", entries)}
                            }};";
            })
            .Select(source => SyntaxFactory.ParseMemberDeclaration(source))
            .ToArray();

    private static MemberDeclarationSyntax GetResourceDictionaryFieldDeclaration(IReadOnlyList<CultureData> cultureData)
    {
        var entries = cultureData.Select(cd =>
        {
            var key = cd.Key == CultureData.InvariantKeyName ? "CultureInfo.InvariantCulture" : $"new CultureInfo(\"{cd.Key}\")";
            return $"{{ {key}, {cd.NormalizedKey} }},";
        });
        var source = $@"private static readonly Dictionary<CultureInfo, Translations> resources = new()
                            {{
                                {string.Join("\r\n", entries)}
                            }};";

        return SyntaxFactory.ParseMemberDeclaration(source);
    }

    private static string CreateMemberHeader(string value) =>
        $"///<summary>Similar to: {EscapeValue(value)}</summary>";

    private string CreateFileHeader()
    {
        return string.Format(@"//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by {0}.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------"
        , GetType().Assembly.GetName().Name);
    }

    private static string EscapeValue(string input)
    {
        return input
            .Replace("\\", "\\\\")  // Escape Backslashes
            .Replace("\"", "\\\"")  // Escape double quotes
            .Replace("\n", "\\n")   // Escape newline
            .Replace("\r", "\\r")   // Escape carriage return
            .Replace("\t", "\\t");  // Escape tab
    }
}