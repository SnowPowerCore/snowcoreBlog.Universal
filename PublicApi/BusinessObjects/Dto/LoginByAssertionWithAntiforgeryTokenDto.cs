namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record LoginByAssertionWithAntiforgeryTokenDto : LoginByAssertionDto
{
    public required string VerificationToken { get; set; } = string.Empty;
}