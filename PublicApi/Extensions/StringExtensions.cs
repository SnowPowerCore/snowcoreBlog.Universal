namespace snowcoreBlog.PublicApi.Extensions;

public static class StringExtensions
{
    public static string TrimEnd(this string target, string trimString)
    {
        if (target.EndsWith(trimString))
            return target.Substring(0, target.Length - trimString.Length);
        return target;
    }
}