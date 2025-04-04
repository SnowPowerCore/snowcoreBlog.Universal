using Microsoft.CodeAnalysis;
using snowcoreBlog.ResourceLoading.Implementations.Internal.Helper;

namespace snowcoreBlog.ResourceLoading.Implementations.Interfaces;

internal interface ITranslationReader
{
    TranslationData Read(AdditionalText text);
}