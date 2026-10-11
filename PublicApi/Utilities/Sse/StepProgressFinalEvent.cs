using snowcoreBlog.PublicApi.Utilities.Api;

namespace snowcoreBlog.PublicApi.Utilities.Sse;

/// <summary>
/// The terminal payload of a server-sent events stream of a stepified process.
/// It wraps the regular API response envelope together with the HTTP status code
/// the process would have produced with a plain JSON response.
/// </summary>
public sealed record StepProgressFinalEvent(int StatusCode, ApiResponse? Response);
