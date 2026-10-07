using Apizr.Configuring.Request;
using Refit;
using snowcoreBlog.PublicApi.Utilities.Api;

namespace snowcoreBlog.PublicApi.Api;

public interface IReaderAccountTokensApi : ITokensApi
{
	[Headers("Accept: application/json, application/problem+json")]
	// The proactive rotation path intentionally sends an EMPTY token (string.Empty) —
	// the backend resolves the refresh token from the HTTP-only cookie. Refit emits a
	// plain StringContent (text/plain) for string bodies, which FastEndpoints rejects
	// with 415; pinning Content-Type here keeps the empty body a valid JSON document
	// ("\"\""). Without it, every auth-state resolution inside the rotation window
	// re-fires the request → request storm (observed ~10 req/s).
	[Headers("Content-Type: application/json")]
	[Post("/tokens/refresh/v1")]
	Task<IApiResponse<ApiResponse>> RefreshReaderJwtPair([Body] string refreshToken, [RequestOptions] IApizrRequestOptions options);
}