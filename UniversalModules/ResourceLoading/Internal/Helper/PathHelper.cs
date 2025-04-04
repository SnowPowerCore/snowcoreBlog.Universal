using System.IO;

namespace snowcoreBlog.ResourceLoading.Implementations.Internal.Helper;

public static class PathHelper
{
    public static string FileNameWithoutCulture(string path)
    {
        var fileName = Path.GetFileNameWithoutExtension(path);
        return fileName.Substring(0, fileName.LastIndexOf('_'));
    }
}