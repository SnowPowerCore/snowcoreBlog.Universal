using Apizr.Configuring.Request;
using Refit;
using snowcoreBlog.PublicApi.Utilities.Api;

namespace snowcoreBlog.PublicApi.Api;

public interface IReaderAccountTokensApi : ITokensApi
{
	// The proactive rotation path intentionally sends an EMPTY token (string.Empty) —
	// the backend resolves the refresh token from the HTTP-only cookie. Refit emits a
	// raw StringContent, so the empty token arrives as a 0-byte body with a JSON
	// content type; the backend's custom request binder accepts empty bodies and
	// resolves the cookie. Do not "fix" this by JSON-encoding the token here. Without
	// the empty-body tolerance, every auth-state resolution inside the rotation window
	// re-fires the request → request storm (observed ~10 req/s).
	[Headers("Accept: application/json, application/problem+json", "Content-Type: application/json")]
	[Post("/tokens/refresh/v1")]
	Task<IApiResponse<ApiResponse>> RefreshReaderJwtPair([Body] string refreshToken, [RequestOptions] IApizrRequestOptions options);

	// Signs the current reader out: the backend revokes the refresh-token record
	// in Redis and expires both HTTP-only auth cookies on the response. Bodyless
	// POST — the caller is identified by the refresh-token cookie alone.
	[Headers("Accept: application/json, application/problem+json")]
	[Post("/tokens/revoke/v1")]
	Task<IApiResponse<ApiResponse>> RevokeReaderTokens([Header("RequestVerificationToken")] string requestVerificationToken, [RequestOptions] IApizrRequestOptions options);
}