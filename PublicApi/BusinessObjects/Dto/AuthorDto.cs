namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record AuthorDto
{
    public required Guid Id { get; init; }
    public required Guid UserId { get; init; }
    public required string DisplayName { get; init; }
}
