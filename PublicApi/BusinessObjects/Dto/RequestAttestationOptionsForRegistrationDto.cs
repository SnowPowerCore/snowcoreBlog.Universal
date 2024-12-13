using Fido2NetLib.Objects;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record RequestAttestationOptionsForRegistrationDto(
    string Email, string VerificationToken, AuthenticatorAttachment? AuthenticatorAttachment,
    AttestationConveyancePreference AttestationType = AttestationConveyancePreference.None,
    ResidentKeyRequirement ResidentKey = ResidentKeyRequirement.Discouraged,
    UserVerificationRequirement UserVerification = UserVerificationRequirement.Preferred);