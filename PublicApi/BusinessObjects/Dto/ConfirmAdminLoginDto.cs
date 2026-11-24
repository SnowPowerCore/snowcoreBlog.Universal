namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public record ConfirmAdminLoginDto
{
    public required string Token { get; init; }
}
