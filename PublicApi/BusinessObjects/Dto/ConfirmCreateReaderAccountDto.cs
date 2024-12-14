using Fido2NetLib;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record ConfirmCreateReaderAccountDto(
    string Email,
    string VerificationToken,
    AuthenticatorAttestationRawResponse AuthenticatorAttestation);