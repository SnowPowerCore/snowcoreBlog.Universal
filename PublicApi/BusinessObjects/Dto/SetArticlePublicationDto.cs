namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Publishes or unpublishes an article from the admin portal.
/// When <see cref="Publish"/> is true and <see cref="PublishedAt"/> is not set,
/// the current UTC time is used.
/// </summary>
public record SetArticlePublicationDto
{
    public bool Publish { get; init; }

    public DateTimeOffset? PublishedAt { get; init; }
}
