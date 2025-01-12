using Fido2NetLib;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record LoginByAssertionDto
{
    public required string Email { get; set; }

    public required AuthenticatorAssertionRawResponse AuthenticatorAssertion { get; set; }
}