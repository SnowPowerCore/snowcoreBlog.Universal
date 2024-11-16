using System.Text.Json;
using Results;
using snowcoreBlog.PublicApi.Constants;
using snowcoreBlog.PublicApi.Utilities.Api;

namespace snowcoreBlog.PublicApi.Extensions;

public static class ApiResponseExtensions
{
    public static ApiResponse ToApiResponse<T>(this IResult<T> result, int dataCount = 0, JsonSerializerOptions serializerOptions = null) where T : notnull
    {
        if (result is SuccessResult<T> success)
        {
            return new(success.Data.ToJsonElement(serializerOptions), dataCount, 0);
        }
        else if (result is IErrorResult<T> error)
        {
            return new(default, 0, -1, error.Errors.Select(x => $"{x.Code}: {x.Details}").ToList());
        }
        else
        {
            return new(default, 0, -1, [ApiResponseConstants.UnknownError]);
        }
    }
}