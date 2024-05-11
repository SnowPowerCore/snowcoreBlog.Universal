using System.Net;
using System.Reflection;

namespace snowcoreBlog.HttpClientInterception.Interceptor.HttpClient;

internal class HttpClientInterceptorHandler : HttpMessageHandler
{
    private static readonly MethodInfo SendAsyncMethod = typeof(HttpMessageHandler).GetMethod(nameof(SendAsync), BindingFlags.Instance | BindingFlags.NonPublic);

    private readonly HttpClientInterceptor _httpClientInterceptor;

    private readonly HttpMessageHandler _baseHandler;

    public HttpClientInterceptorHandler(HttpClientInterceptor httpClientInterceptor, HttpMessageHandler baseHandler)
    {
        _httpClientInterceptor = httpClientInterceptor;
        _baseHandler = baseHandler;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = default(HttpResponseMessage);
        var exception = default(Exception);
        var args = new HttpClientInterceptorEventArgs(request);
        try
        {
            await _httpClientInterceptor.InvokeBeforeSendAsync(args);
            if (args.Cancel)
            {
                response = new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            else
            {
                response = await (SendAsyncMethod.Invoke(_baseHandler, new object[] { request, cancellationToken }) as Task<HttpResponseMessage>);
            }
            return response;
        }
        catch (Exception e)
        {
            exception = e;
            throw;
        }
        finally
        {
            if (!args.Cancel)
            {
                var argsAfter = new HttpClientInterceptorEventArgs(request, response, exception);
                await _httpClientInterceptor.InvokeAfterSendAsync(argsAfter);
                await args._asyncTask;
            }
        }
    }

    protected override void Dispose(bool disposing)
    {
        _baseHandler?.Dispose();
        base.Dispose(disposing);
    }
}