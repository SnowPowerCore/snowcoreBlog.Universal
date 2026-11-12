namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Successful reader token revocation (sign-out). Cookies are expired on the
/// response; this marker carries no additional payload.
/// </summary>
public sealed record RevokeReaderAccountTokenResultDto;
