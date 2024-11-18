using System.Collections;
using System.Text.Json;
using Results;
using snowcoreBlog.PublicApi.Constants;
using snowcoreBlog.PublicApi.Utilities.Api;

namespace snowcoreBlog.PublicApi.Extensions;

public static class ApiResponseExtensions
{
    public static ApiResponse ToApiResponse<T>(this IResult<T> result, JsonSerializerOptions serializerOptions = null) where T : notnull
    {
        if (result is SuccessResult<T> success)
        {
            var dataCount = success.Data is ICollection e ? e.Count : 1;
            return new(success.Data.ToJsonElement(serializerOptions), dataCount, 0);
        }
        else if (result is IErrorResult<T> error)
        {
            var errors = error.Errors.Select(x => $"{x.Code}: {x.Details}").ToList();
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