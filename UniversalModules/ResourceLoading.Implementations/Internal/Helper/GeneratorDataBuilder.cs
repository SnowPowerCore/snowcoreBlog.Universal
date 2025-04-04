using Microsoft.CodeAnalysis;
using snowcoreBlog.ResourceLoading.Interfaces;

namespace snowcoreBlog.ResourceLoading.Implementations.Internal.Helper;

internal class GeneratorDataBuilder(IReadOnlyList<AdditionalText> files, 
    NamesResolver namesResolver, ITranslationReader translationReader)
{
    public GeneratorData Build() =>
        new()
        {
            GeneratedClassName = namesResolver.ResolveGeneratedClassName(),
            GeneratedFileName = namesResolver.ResolveGeneratedFileName(),
            Namespace = namesResolver.ResolveNamespace(),
            CultureData = CultureData.Initialize(namesResolver.ResolveNeutralCulture(), files, translationReader),
        };
}