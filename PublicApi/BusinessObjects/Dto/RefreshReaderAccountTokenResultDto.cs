namespace snowcoreBlog.PublicApi.BusinessObjects.Dto;

/// <summary>
/// Successful reader token refresh. The new token pair itself is delivered
/// via auth cookies; this marker carries no additional payload.
/// </summary>
public sealed record RefreshReaderAccountTokenResultDto;
