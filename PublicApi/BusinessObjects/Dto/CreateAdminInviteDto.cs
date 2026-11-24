namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public record CreateAdminInviteDto
{
    public required string Email { get; init; }

    public string NickName { get; init; } = string.Empty;
}
