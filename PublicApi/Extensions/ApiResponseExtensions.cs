using System.Collections;
using System.Text.Json;
using MaybeResults;
using snowcoreBlog.PublicApi.Constants;
using snowcoreBlog.PublicApi.Utilities.Api;

namespace snowcoreBlog.PublicApi.Extensions;

public static class ApiResponseExtensions
{
    public static ApiResponse ToApiResponse<T>(this IMaybe<T> result, JsonSerializerOptions serializerOptions = null) where T : notnull
    {
        if (result is Some<T> success)
        {
            var dataCount = success.Value is ICollection e ? e.Count : 1;
            return new(success.Value.ToJsonDocument(serializerOptions), dataCount, 0);
        }
        else if (result is INone<T> error)
        {
            var errors = error.Details.Select(x => $"{x.Code}: {x.Description}").ToList();
            if (errors.Count == 0)
                errors.Add(error.Message);
            return new(default, 0, -1, errors);
        }
        else
        {
            return new(default, 0, -1, [ApiResponseConstants.UnknownError]);
        }
    }
}