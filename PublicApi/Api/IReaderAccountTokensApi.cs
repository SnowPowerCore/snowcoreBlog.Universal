using Apizr.Configuring.Request;
using Refit;
using snowcoreBlog.PublicApi.Utilities.Api;

namespace snowcoreBlog.PublicApi.Api;

public interface IReaderAccountTokensApi : ITokensApi
{
	[Headers("Accept: application/json, application/problem+json")]
	[Post("/tokens/refresh/v1")]
	Task<IApiResponse<ApiResponse>> RefreshReaderJwtPair([Body] string refreshToken, [RequestOptions] IApizrRequestOptions options);
}