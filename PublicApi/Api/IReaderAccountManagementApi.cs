// <auto-generated>
//     This code was generated by Refitter.
// </auto-generated>


using Refit;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Apizr.Configuring.Request;
using System.Threading.Tasks;

using snowcoreBlog.PublicApi.Utilities.Api;
using snowcoreBlog.PublicApi.BusinessObjects.Dto;

#nullable enable annotations

namespace snowcoreBlog.PublicApi.Api
{
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.5.2.0")]
    public partial interface IReaderAccountManagementApi
    {
        /// <param name="requestVerificationToken">A required antiforgery token that has to be sent along the request with implicit cookie as a pair.</param>
        /// <param name="options">The <see cref="IApizrRequestOptions"/> instance to pass through the request.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Success</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>500</term>
        /// <description>Server Error</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json, application/problem+json")]
        [Post("/check/nickname/v1")]
        Task<IApiResponse<ApiResponse>> CheckNickNameNotTaken([Body, AliasAs("CheckNickNameNotTakenDto")] CheckNickNameNotTakenDto checkNickNameNotTakenDto, [Header("RequestVerificationToken")] string requestVerificationToken, [RequestOptions] IApizrRequestOptions options);

        /// <param name="requestVerificationToken">A required antiforgery token that has to be sent along the request with implicit cookie as a pair.</param>
        /// <param name="options">The <see cref="IApizrRequestOptions"/> instance to pass through the request.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Success</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>500</term>
        /// <description>Server Error</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json, application/problem+json")]
        [Post("/create/confirm/email/v1")]
        Task<IApiResponse<ApiResponse>> ConfirmCreateByEmail([Body, AliasAs("ConfirmCreateReaderAccountDto")] ConfirmCreateReaderAccountDto confirmCreateReaderAccountDto, [Header("RequestVerificationToken")] string requestVerificationToken, [RequestOptions] IApizrRequestOptions options);

        /// <param name="requestVerificationToken">A required antiforgery token that has to be sent along the request with implicit cookie as a pair.</param>
        /// <param name="requestCaptcha">A required base64 captcha solution that has to be sent along the request.</param>
        /// <param name="options">The <see cref="IApizrRequestOptions"/> instance to pass through the request.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Success</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>500</term>
        /// <description>Server Error</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json, application/problem+json")]
        [Post("/login/assertion/v1")]
        Task<IApiResponse<ApiResponse>> LoginByAssertion([Body, AliasAs("LoginByAssertionDto")] LoginByAssertionDto loginByAssertionDto, [Header("RequestVerificationToken")] string requestVerificationToken, [Header("RequestCaptcha")] string requestCaptcha, [RequestOptions] IApizrRequestOptions options);

        /// <param name="options">The <see cref="IApizrRequestOptions"/> instance to pass through the request.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Success</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Unauthorized</description>
        /// </item>
        /// <item>
        /// <term>403</term>
        /// <description>Forbidden</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json, application/problem+json")]
        [Get("/ping/v1")]
        Task<IApiResponse<string>> Ping([RequestOptions] IApizrRequestOptions options);

        /// <param name="requestVerificationToken">A required antiforgery token that has to be sent along the request with implicit cookie as a pair.</param>
        /// <param name="options">The <see cref="IApizrRequestOptions"/> instance to pass through the request.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Success</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>500</term>
        /// <description>Server Error</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json, application/problem+json")]
        [Post("/request/assertion/v1")]
        Task<IApiResponse<ApiResponse>> RequestAssertionOptions([Body, AliasAs("RequestAssertionOptionsDto")] RequestAssertionOptionsDto requestAssertionOptionsDto, [Header("RequestVerificationToken")] string requestVerificationToken, [RequestOptions] IApizrRequestOptions options);

        /// <param name="requestVerificationToken">A required antiforgery token that has to be sent along the request with implicit cookie as a pair.</param>
        /// <param name="options">The <see cref="IApizrRequestOptions"/> instance to pass through the request.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Success</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>500</term>
        /// <description>Server Error</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json, application/problem+json")]
        [Post("/create/attestation/v1")]
        Task<IApiResponse<ApiResponse>> RequestAttestationOptions([Body, AliasAs("RequestAttestationOptionsDto")] RequestAttestationOptionsDto requestAttestationOptionsDto, [Header("RequestVerificationToken")] string requestVerificationToken, [RequestOptions] IApizrRequestOptions options);

        /// <param name="options">The <see cref="IApizrRequestOptions"/> instance to pass through the request.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Success</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Unauthorized</description>
        /// </item>
        /// <item>
        /// <term>403</term>
        /// <description>Forbidden</description>
        /// </item>
        /// <item>
        /// <term>500</term>
        /// <description>Server Error</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json, application/problem+json")]
        [Get("/check/me/v1")]
        Task<IApiResponse<ApiResponse>> RequestAuthData([RequestOptions] IApizrRequestOptions options);

        /// <param name="requestVerificationToken">A required antiforgery token that has to be sent along the request with implicit cookie as a pair.</param>
        /// <param name="requestCaptcha">A required base64 captcha solution that has to be sent along the request.</param>
        /// <param name="options">The <see cref="IApizrRequestOptions"/> instance to pass through the request.</param>
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Success</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>500</term>
        /// <description>Server Error</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json, application/problem+json")]
        [Post("/create/request/email/v1")]
        Task<IApiResponse<ApiResponse>> RequestCreateByEmail([Body, AliasAs("RequestCreateReaderAccountDto")] RequestCreateReaderAccountDto requestCreateReaderAccountDto, [Header("RequestVerificationToken")] string requestVerificationToken, [Header("RequestCaptcha")] string requestCaptcha, [RequestOptions] IApizrRequestOptions options);
    }

}