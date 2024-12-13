using Fido2NetLib.Objects;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record RequestAttestationOptionsForLoginDto(
    string Email, AuthenticatorAttachment? AuthenticatorAttachment,
    AttestationConveyancePreference AttestationType = AttestationConveyancePreference.None,
    ResidentKeyRequirement ResidentKey = ResidentKeyRequirement.Discouraged,
    UserVerificationRequirement UserVerification = UserVerificationRequirement.Preferred);