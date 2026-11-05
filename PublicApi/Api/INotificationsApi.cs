using Apizr.Configuring.Request;
using Refit;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;
using snowcoreBlog.PublicApi.Utilities.Api;

namespace snowcoreBlog.PublicApi.Api;

/// <summary>
/// ServiceNotifications endpoints consumed by clients (active notifications bar).
/// Hand-written companion to the Refitter-generated API interfaces — keep the
/// PublicApi copies (Backend / Frontend / Console) in sync.
/// </summary>
public interface INotificationsApi
{
    [Headers("Accept: application/json, application/problem+json")]
    [Get("/active/v1")]
    Task<IApiResponse<ApiResponse>> GetActiveNotifications([Query] GetActiveNotificationsDto? query, [RequestOptions] IApizrRequestOptions options);
}