namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public record CreateArticleDto
{
    public required string Title { get; init; }
    public required string Markdown { get; init; }
    public string[]? Tags { get; init; }
    public string? CoverImageUrl { get; init; }
    // Optional list of author user ids. If omitted, the caller's user id will be used as the sole author.
    public Guid[]? Authors { get; init; }
}
