namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public record RequestAdminLoginLinkDto
{
    public required string Email { get; init; }
}
