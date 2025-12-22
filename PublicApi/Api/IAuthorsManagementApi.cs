using Refit;
using Apizr.Configuring.Request;
using System.Threading.Tasks;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;
using snowcoreBlog.PublicApi.Utilities.Api;

#nullable enable annotations

namespace snowcoreBlog.PublicApi.Api;

/// <summary>
/// API interface for Authors Management operations.
/// </summary>
[Headers("Accept: application/json, application/problem+json")]
public partial interface IAuthorsManagementApi
{
    /// <summary>
    /// Become an author by converting a reader account to an author account.
    /// </summary>
    /// <param name="request">The become author request containing user ID and display name.</param>
    /// <param name="requestVerificationToken">A required antiforgery token that has to be sent along the request with implicit cookie as a pair.</param>
    /// <param name="options">The Apizr request options.</param>
    /// <returns>API response containing the result of the operation.</returns>
    [Headers("Content-Type: application/json")]
    [Post("/author/become/v1")]
    Task<IApiResponse<ApiResponse>> BecomeAuthor(
        [Body] BecomeAuthorAccountRequestDto request,
        [Header("RequestVerificationToken")] string requestVerificationToken,
        [RequestOptions] IApizrRequestOptions options);
}
