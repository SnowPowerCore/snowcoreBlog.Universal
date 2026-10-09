namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public record ArticleDto
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Slug { get; init; }
    // Latest markdown content (from latest snapshot)
    public required string Markdown { get; init; }
    // Support multiple authors
    public required Guid[] AuthorUserIds { get; init; }
    // Latest snapshot id referenced by this article
    public required Guid LatestSnapshotId { get; init; }
    public DateTime? PublishedAt { get; init; }
    public DateTime? ModifiedAt { get; init; }
    public string[]? Tags { get; init; }
    public string? CoverImageUrl { get; init; }
    // Free-form category; null = uncategorized.
    public string? Category { get; init; }
    // Latest snapshot excerpt; null = derive from content on the client.
    public string? Excerpt { get; init; }
    // Latest snapshot SEO meta description; null = fall back to Excerpt.
    public string? MetaDescription { get; init; }
}
