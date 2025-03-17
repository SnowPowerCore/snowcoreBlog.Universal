using System.Net;
using MaybeResults;

namespace snowcoreBlog.PublicApi.Extensions;

public static class StatusCodeExtensions
{
    public static int ToStatusCode<T>(this IMaybe<T> result) where T : notnull
    {
        if (result is Some<T>)
        {
            return (int)HttpStatusCode.OK;
        }
        else if (result is INone<T>)
        {
            return (int)HttpStatusCode.BadRequest;
        }
        else
        {
            return (int)HttpStatusCode.InternalServerError;
        }
    }
}