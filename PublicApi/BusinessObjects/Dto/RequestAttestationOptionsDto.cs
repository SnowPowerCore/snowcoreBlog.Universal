using Fido2NetLib.Objects;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record RequestAttestationOptionsDto
{
    public required string Email { get; set; }

    public required string VerificationToken { get; set; }

    public AuthenticatorAttachment? AuthenticatorAttachment { get; set; }

    public AttestationConveyancePreference AttestationType { get; set; } = AttestationConveyancePreference.None;

    public ResidentKeyRequirement ResidentKey { get; set; } = ResidentKeyRequirement.Discouraged;

    public UserVerificationRequirement UserVerification { get; set; } = UserVerificationRequirement.Preferred;
}