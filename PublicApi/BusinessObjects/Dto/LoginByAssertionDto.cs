using Fido2NetLib;

namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

public sealed record LoginByAssertionDto
{
    public required string Email { get; set; }

    /// <summary>
    /// Present when signing in with a passkey (WebAuthn assertion result).
    /// </summary>
    public AuthenticatorAssertionRawResponse? AuthenticatorAssertion { get; set; }

    /// <summary>
    /// Present when signing in with a one-time code from an authenticator app.
    /// When set, the passkey assertion is not required.
    /// </summary>
    public string? OneTimeCode { get; set; }
}