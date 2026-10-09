namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record ConfirmCreateReaderAccountWithAuthenticatorDto
{
    public required string Email { get; set; }

    public required string VerificationToken { get; set; }

    public required string Code { get; set; }
}
