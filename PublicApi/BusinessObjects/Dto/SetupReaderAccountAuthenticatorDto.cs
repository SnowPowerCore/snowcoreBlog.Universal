namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record SetupReaderAccountAuthenticatorDto
{
    public required string Email { get; set; }

    public required string VerificationToken { get; set; }
}
