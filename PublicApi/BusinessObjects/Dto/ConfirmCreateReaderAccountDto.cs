using Fido2NetLib;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record ConfirmCreateReaderAccountDto
{
    public required string Email { get; set; }

    public required string VerificationToken { get; set; }

    public required AuthenticatorAttestationRawResponse AuthenticatorAttestation { get; set; }
}