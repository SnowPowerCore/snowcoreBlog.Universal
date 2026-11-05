namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Article with its latest content snapshot, for the admin detail view.
/// </summary>
public record ArticleAdminDetailDto : ArticleAdminDto
{
    public string Markdown { get; init; } = string.Empty;

    public string? Excerpt { get; init; }

    public string? MetaDescription { get; init; }

    public DateTimeOffset SnapshotModifiedAt { get; init; }
}
