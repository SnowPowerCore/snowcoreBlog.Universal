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

public record AdminInviteDto
{
    public required Guid Id { get; init; }

    public required string Email { get; init; }

    public string NickName { get; init; } = string.Empty;

    public required Guid InvitedByAdminId { get; init; }

    public DateTime CreatedAtUtc { get; init; }

    public DateTime ExpiresAtUtc { get; init; }

    public DateTime? AcceptedAtUtc { get; init; }
}

public record RequestAdminLoginLinkDto
{
    public required string Email { get; init; }
}

public record ConfirmAdminLoginDto
{
    public required string Token { get; init; }
}

public record CreateAdminInviteDto
{
    public required string Email { get; init; }

    public string NickName { get; init; } = string.Empty;
}

public record AcceptAdminInviteDto
{
    public required string Token { get; init; }

    public string NickName { get; init; } = string.Empty;
}

public record AdminInviteResolutionDto
{
    public required string Email { get; init; }

    public string NickName { get; init; } = string.Empty;

    public required Guid InvitedByAdminId { get; init; }

    public required DateTime ExpiresAtUtc { get; init; }
}
