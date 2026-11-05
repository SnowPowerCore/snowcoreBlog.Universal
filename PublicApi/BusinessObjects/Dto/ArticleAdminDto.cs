namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Article row as seen by the admin portal (search results).
/// </summary>
public record ArticleAdminDto
{
    public required Guid Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public string Slug { get; init; } = string.Empty;

    public IReadOnlyList<string> Tags { get; init; } = [];

    public string? Category { get; init; }

    public string? CoverImageUrl { get; init; }

    public Guid LatestSnapshotId { get; init; }

    public DateTimeOffset? PublishedAt { get; init; }

    public bool IsPublished => PublishedAt is not null;
}
