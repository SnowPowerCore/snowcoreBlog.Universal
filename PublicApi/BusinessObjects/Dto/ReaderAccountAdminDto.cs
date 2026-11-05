namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Reader account row as seen by the admin portal (search results).
/// </summary>
public record ReaderAccountAdminDto
{
    public required Guid Id { get; init; }

    public required Guid UserId { get; init; }

    public string NickName { get; init; } = string.Empty;
}
