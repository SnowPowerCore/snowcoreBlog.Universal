namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public record CreateArticleDto
{
    public required string Title { get; init; }
    public required string Markdown { get; init; }
    public string[]? Tags { get; init; }
    public string? CoverImageUrl { get; init; }
    // Free-form category; null = uncategorized.
    public string? Category { get; init; }
    // Short summary shown in lists; null = derive from content on the client.
    public string? Excerpt { get; init; }
    // SEO meta description; null = fall back to Excerpt.
    public string? MetaDescription { get; init; }
    // Optional list of author user ids. If omitted, the caller's user id will be used as the sole author.
    public Guid[]? Authors { get; init; }
}
