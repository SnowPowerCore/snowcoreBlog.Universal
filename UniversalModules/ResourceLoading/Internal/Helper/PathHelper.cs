using System.IO;

namespace snowcoreBlog.ResourceLoading.Implementations.Internal.Helper;

public static class PathHelper
{
    public static string FileNameWithoutCulture(string path)
    {
        var fileName = Path.GetFileNameWithoutExtension(path);
        var fileNameSpan = fileName.AsSpan();
        var lastUnderscoreIndex = fileNameSpan.LastIndexOf('_');
        if (lastUnderscoreIndex < 0)
            return fileName;

        return fileNameSpan.Slice(0, lastUnderscoreIndex).ToString();
    }
}