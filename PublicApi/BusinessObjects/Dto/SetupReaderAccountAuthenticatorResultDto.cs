namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Authenticator app provisioning data: Base32 secret, otpauth:// URI and a
/// pre-rendered QR code (SVG markup) for scanning with an authenticator app.
/// </summary>
public sealed record SetupReaderAccountAuthenticatorResultDto(
    string Secret,
    string OtpAuthUri,
    string SvgQrCode);
