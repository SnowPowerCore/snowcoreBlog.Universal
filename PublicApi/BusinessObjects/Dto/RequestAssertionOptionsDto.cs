using Fido2NetLib.Objects;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record RequestAssertionOptionsDto
{
    public required string Email { get; set; }

    public UserVerificationRequirement UserVerification { get; set; } = UserVerificationRequirement.Preferred;
}