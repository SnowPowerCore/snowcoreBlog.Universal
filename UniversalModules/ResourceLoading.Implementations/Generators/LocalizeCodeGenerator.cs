using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using snowcoreBlog.ResourceLoading.Implementations.Internal;
using snowcoreBlog.ResourceLoading.Implementations.Internal.Helper;
using snowcoreBlog.ResourceLoading.Implementations.Internal.Json;
using snowcoreBlog.ResourceLoading.Models;

namespace snowcoreBlog.ResourceLoading.Implementations.Generators;

[Generator]
public class LocalizeCodeGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        // TODO: Run only if AdditionalFiles or one of the CultureFiles is changed
    }

    public void Execute(GeneratorExecutionContext context)
    {
        // #if DEBUG
        //             if (!System.Diagnostics.Debugger.IsAttached)
        //                 System.Diagnostics.Debugger.Launch();
        // #endif

        var translationReader = new JsonTranslationReader(context.ReportDiagnostic);
        var codeGenerator = new LocalizeCodeGeneratorCore();
        var additionalFiles = context.AdditionalFiles.Where(af => af.Path.EndsWith(".json", StringComparison.OrdinalIgnoreCase));
        foreach (var file in additionalFiles)
        {
            var namesResolver = new NamesResolver(file, context.Compilation.AssemblyName, context.AnalyzerConfigOptions);
            var ctx = new GeneratorDataBuilder(file, namesResolver, translationReader).Build();
            context.AddSource(ctx.GeneratedFileName, codeGenerator.CreateClass(ctx));
        }
    }
}