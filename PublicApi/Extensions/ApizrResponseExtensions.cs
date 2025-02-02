using System.Text.Json;
using Apizr;
using snowcoreBlog.PublicApi.Utilities.Api;

namespace snowcoreBlog.PublicApi.Extensions;

public static class ApizrResponseExtensions
{
    private static readonly JsonSerializerOptions _serializerOptions = new() { PropertyNameCaseInsensitive = true };

    public static T? ToData<T>(this IApizrResponse<ApiResponse> response, out List<string> errors) where T : notnull
    {
        errors = [];

        if (!response.IsSuccess && !response.Exception.Handled)
        {
            errors.Add(response.Exception.Message);
        }

        var data = response.Result;
        if (data is default(ApiResponse))
        {
            return default;
        }

        if (data.Errors?.Count > 0)
        {
            errors.AddRange(data.Errors);
            return default;
        }

        if (data.DataCount <= 0)
        {
            return default;
        }

        return data.Data!.Deserialize<T>(_serializerOptions);
    }
}