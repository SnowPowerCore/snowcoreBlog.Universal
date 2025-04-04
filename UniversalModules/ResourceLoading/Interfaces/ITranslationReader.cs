using Microsoft.CodeAnalysis;
using snowcoreBlog.ResourceLoading.Models;

namespace snowcoreBlog.ResourceLoading.Interfaces;

public interface ITranslationReader
{
    TranslationData Read(AdditionalText text);
}