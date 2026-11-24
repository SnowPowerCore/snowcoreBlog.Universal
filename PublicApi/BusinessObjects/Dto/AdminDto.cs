namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public record AdminDto
{
    public required Guid Id { get; init; }

    public required string Email { get; init; }

    public string NickName { get; init; } = string.Empty;

    public Guid? InvitedByAdminId { get; init; }

    public DateTime InvitedAtUtc { get; init; }

    public bool IsActive { get; init; }
}
