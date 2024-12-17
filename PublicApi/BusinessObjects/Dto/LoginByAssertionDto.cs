using Fido2NetLib;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record LoginByAssertionDto(
    string Email,
    AuthenticatorAssertionRawResponse AuthenticatorAssertion);