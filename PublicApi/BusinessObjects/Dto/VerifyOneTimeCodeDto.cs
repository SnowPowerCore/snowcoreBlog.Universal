namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record VerifyOneTimeCodeDto
{
    public required string Email { get; set; }

    public required string Code { get; set; }
}
