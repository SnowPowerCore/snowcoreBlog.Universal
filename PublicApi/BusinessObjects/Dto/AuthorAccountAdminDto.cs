namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Author account row as seen by the admin portal (search results).
/// </summary>
public record AuthorAccountAdminDto
{
    public required Guid Id { get; init; }

    public required Guid UserId { get; init; }

    public string DisplayName { get; init; } = string.Empty;
}
