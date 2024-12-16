using Fido2NetLib.Objects;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record RequestAssertionOptionsDto(
    string Email, UserVerificationRequirement UserVerification = UserVerificationRequirement.Preferred);