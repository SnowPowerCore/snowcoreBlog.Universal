namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public record AcceptAdminInviteDto
{
    public required string Token { get; init; }

    public string NickName { get; init; } = string.Empty;
}
