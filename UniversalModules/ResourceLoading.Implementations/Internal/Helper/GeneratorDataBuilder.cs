using Microsoft.CodeAnalysis;
using snowcoreBlog.ResourceLoading.Interfaces;
using snowcoreBlog.ResourceLoading.Models;

namespace snowcoreBlog.ResourceLoading.Implementations.Internal.Helper;

internal class GeneratorDataBuilder(AdditionalText originFile, NamesResolver namesResolver, ITranslationReader translationReader)
{
    public GeneratorData Build()
    {
        return new GeneratorData
        {
            GeneratedClassName = namesResolver.ResolveGeneratedClassName(),
            GeneratedFileName = namesResolver.ResolveGeneratedFileName(),
            Namespace = namesResolver.ResolveNamespace(),
            CultureData = CultureData.Initialize(originFile.Path, translationReader),
        };
    }
}