using System.Text.Json;
using Apizr;
using snowcoreBlog.PublicApi.Utilities.Api;

namespace snowcoreBlog.PublicApi.Extensions;

public static class ApizrResponseExtensions
{
    private static readonly JsonSerializerOptions _serializerOptions = new() { PropertyNameCaseInsensitive = true };

    public static T? ToData<T>(this IApizrResponse<ApiResponse> response, out List<string> errors, JsonSerializerOptions serializerOptions = null) where T : notnull
    {
        errors = new List<string>(response.Result?.Errors?.Count ?? 0);

        var refitContent = response.ApiResponse?.Error?.Content;
        if (!string.IsNullOrWhiteSpace(refitContent))
        {
            var errorResponse = JsonSerializer.Deserialize<ApiResponse?>(refitContent, _serializerOptions);
            errors.AddRange(errorResponse?.Errors ?? []);
        }

        if (!response.IsSuccess && !response.Exception.Handled)
        {
            errors.Add(response.Exception.Message);
        }

        if (response.Result?.Errors?.Count > 0)
        {
            errors.AddRange(response.Result.Errors);
            errors.TrimExcess();
            return default;
        }

        errors.TrimExcess();

        if (response.Result?.DataCount <= 0)
        {
            return default;
        }

        if (response.Result is default(ApiResponse))
        {
            return default;
        }

        return response.Result.Data!.Deserialize<T>(serializerOptions ?? _serializerOptions);
    }
}