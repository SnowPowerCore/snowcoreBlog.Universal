using snowcoreBlog.ResourceLoading.Models;

namespace snowcoreBlog.ResourceLoading.Interfaces;

public interface ITranslationReader
{
    TranslationData Read(string filePath);
}