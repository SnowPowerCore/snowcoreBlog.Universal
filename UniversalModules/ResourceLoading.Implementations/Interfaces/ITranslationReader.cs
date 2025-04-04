using Microsoft.CodeAnalysis;
using snowcoreBlog.ResourceLoading.Implementations.Models;

namespace snowcoreBlog.ResourceLoading.Implementations.Interfaces;

internal interface ITranslationReader
{
    TranslationData Read(AdditionalText text);
}