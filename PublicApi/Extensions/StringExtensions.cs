namespace snowcoreBlog.PublicApi.Extensions;

public static class StringExtensions
{
    public static string TrimEnd(this string target, string trimString)
    {
        ReadOnlySpan<char> targetSpan = target;
        ReadOnlySpan<char> trimStringSpan = trimString;
        if (targetSpan.EndsWith(trimStringSpan))
            return targetSpan.Slice(0, targetSpan.Length - trimStringSpan.Length).ToString();
        return target;
    }

    /// <summary>Trims a filter value; blank filters are dropped from the query string.</summary>
    public static string? Normalize(this string? value)
        => string.IsNullOrWhiteSpace(value) ? null : value.Trim();
}