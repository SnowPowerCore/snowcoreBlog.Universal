namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public record AdminInviteResolutionDto
{
    public required string Email { get; init; }

    public string NickName { get; init; } = string.Empty;

    public required Guid InvitedByAdminId { get; init; }

    public required DateTime ExpiresAtUtc { get; init; }
}
