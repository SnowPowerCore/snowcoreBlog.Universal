using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
using snowcoreBlog.ResourceLoading.Implementations.Interfaces;
using snowcoreBlog.ResourceLoading.Implementations.Models;

namespace snowcoreBlog.ResourceLoading.Implementations.Internal.Json;

internal class JsonTranslationReader(Action<Diagnostic> reportDiagnostic) : ITranslationReader
{
    public TranslationData Read(AdditionalText text)
    {
        try
        {
            var reader = new JsonTextReader(new StringReader(text.GetText()!.ToString()));
            return ReadCore(text.Path, reader);
        }
        catch (JsonReaderException ex)
        {
            reportDiagnostic.ReportInvalidFileFormat(text.Path, ex);
        }

        return [];
    }

    private TranslationData ReadCore(string filePath, JsonTextReader reader)
    {
        var hierachy = new Stack<TranslationData>([[]]);
        var propertyName = string.Empty;
        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    HandleStartObject(reader, hierachy, propertyName);
                    break;
                case JsonToken.PropertyName:
                    HandleProperty(filePath, reader, ref propertyName);
                    break;
                case JsonToken.String:
                    hierachy.Peek().Add(propertyName, reader.Value!.ToString());
                    break;
                case JsonToken.EndObject:
                    HandleEndObject(reader, hierachy);
                    break;
                case JsonToken.None:
                case JsonToken.Comment:
                    reader.Skip();
                    break;
                default:
                    reportDiagnostic.ReportInvalidTokenType(filePath, reader);
                    reader.Skip();
                    break;
            }
        }

        return hierachy.Pop();
    }

    private static void HandleEndObject(JsonTextReader reader, Stack<TranslationData> hierarchy)
    {
        if (reader.Depth > 0)
            hierarchy.Pop();
    }

    private void HandleProperty(string filePath, JsonTextReader reader, ref string propertyName)
    {
        var identifier = reader.Value!.ToString();
        if (!IsValidIdentifier(identifier))
        {
            reportDiagnostic.ReportInvalidKey(filePath, reader);
            reader.Skip();
        }
        else
            propertyName = identifier;
    }

    private static void HandleStartObject(JsonTextReader reader, Stack<TranslationData> hierachie, string propertyName)
    {
        if (reader.Depth > 0)
        {
            var currentDepth = new TranslationData();
            hierachie.Peek().Add(propertyName, currentDepth);
            hierachie.Push(currentDepth);
        }
    }

    private static bool IsValidIdentifier(string identifier) =>
        SyntaxFacts.IsValidIdentifier(identifier)
            && SyntaxFacts.GetKeywordKind(identifier) == SyntaxKind.None
            && SyntaxFacts.GetContextualKeywordKind(identifier) == SyntaxKind.None;
}