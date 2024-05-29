using System.Net;
using Results;

namespace snowcoreBlog.PublicApi;

public static class StatusCodeExtensions
{
    public static int ToStatusCode<T>(this IResult<T> result) where T : notnull
    {
        if (result is SuccessResult<T>)
        {
            return (int)HttpStatusCode.OK;
        }
        else if (result is IErrorResult<T>)
        {
            return (int)HttpStatusCode.BadRequest;
        }
        else
        {
            return (int)HttpStatusCode.InternalServerError;
        }
    }
}