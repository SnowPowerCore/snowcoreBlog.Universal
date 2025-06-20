﻿using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using snowcoreBlog.ResourceLoading.Implementations.Internal;
using snowcoreBlog.ResourceLoading.Implementations.Internal.Helper;
using snowcoreBlog.ResourceLoading.Implementations.Internal.Json;

namespace snowcoreBlog.ResourceLoading.Implementations;

[Generator(LanguageNames.CSharp)]
public class LocalizeCodeGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext ctx)
    {
        var assemblyNameProvider = ctx.CompilationProvider.Select(static (c, _) => c.AssemblyName);
        var configOptionsProvider = ctx.AnalyzerConfigOptionsProvider;
        var additionalTextsWithOptionsAndAssemblyName =
            ctx.AdditionalTextsProvider
                .Where(static at => Path.GetExtension(at.Path) == ".json")
                .Combine(configOptionsProvider)
                .Where(static pair =>
                {
                    var additionalText = pair.Left;
                    var options = pair.Right;
                    return options.GetOptions(additionalText)
                        .TryGetValue($"build_metadata.AdditionalFiles.{NamesResolver.MetaDataNeutralCulture}",
                            out var _);
                })
                .Select(static (pair, _) => pair.Left)
                .Collect()
                .Select(static (additionalTexts, _) =>
                    additionalTexts.GroupBy(at => PathHelper.FileNameWithoutCulture(at.Path)))
                .Combine(configOptionsProvider)
                .Combine(assemblyNameProvider);
        
        ctx.RegisterSourceOutput(additionalTextsWithOptionsAndAssemblyName, (spc, pipeline) =>
        {
            var assemblyName = pipeline.Right;
            var optionsProvider = pipeline.Left.Right;
            foreach (var additionalTexts in pipeline.Left.Left)
            {
                spc.ReportDiagnostic(Diagnostic.Create(
                    new DiagnosticDescriptor($"SGL001FOO", "snowcoreBlog.ResourceLoading.Generator", 
                        $"{additionalTexts.First().Path}"
                        , "Source Generators", DiagnosticSeverity.Warning, true),
                    Location.None));
                var codeGenerator = new LocalizeCodeGeneratorCore();
                var translationReader = new JsonTranslationReader(spc.ReportDiagnostic);
                var namesResolver = new NamesResolver(additionalTexts.First(), assemblyName, optionsProvider);
                var generatorData = new GeneratorDataBuilder(additionalTexts.ToList(), namesResolver, translationReader).Build();
                spc.AddSource(generatorData.GeneratedFileName, codeGenerator.CreateClass(generatorData));
            }
        });
    }
}