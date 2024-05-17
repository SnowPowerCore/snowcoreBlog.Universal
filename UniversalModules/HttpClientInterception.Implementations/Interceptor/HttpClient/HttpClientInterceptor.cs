using snowcoreBlog.HttpClientInterception.Interceptor.HttpClient;
using snowcoreBlog.HttpClientInterception.Interfaces;

namespace snowcoreBlog.HttpClientInterception.Implementations.Interceptor.HttpClient;

/// <summary>
/// Intercept all of the sending HTTP requests on a client side Blazor application.
/// </summary>
public class HttpClientInterceptor : IHttpClientInterceptor
{
    /// <summary>
    /// Occurs before a HTTP request sending.
    /// </summary>
    public event EventHandler<HttpClientInterceptorEventArgs> BeforeSend;

    /// <summary>
    /// Occurs before a HTTP request sending.
    /// </summary>
    public event HttpClientInterceptorEventHandler BeforeSendAsync;

    /// <summary>
    /// Occurs after received a response of a HTTP request. (include it wasn't succeeded.)
    /// </summary>
    public event EventHandler<HttpClientInterceptorEventArgs> AfterSend;

    /// <summary>
    /// Occurs after received a response of a HTTP request. (include it wasn't succeeded.)
    /// </summary>
    public event HttpClientInterceptorEventHandler AfterSendAsync;

    internal HttpClientInterceptor() { }

    internal async Task InvokeBeforeSendAsync(HttpClientInterceptorEventArgs args)
    {
        BeforeSend?.Invoke(this, args);
        await InvokeAsync(BeforeSendAsync, args);
    }

    internal async Task InvokeAfterSendAsync(HttpClientInterceptorEventArgs args)
    {
        AfterSend?.Invoke(this, args);
        await InvokeAsync(AfterSendAsync, args);
    }

    private async Task InvokeAsync(HttpClientInterceptorEventHandler asyncEventHandler, HttpClientInterceptorEventArgs args)
    {
        if (asyncEventHandler == null) return;

        var asyncHandlerTasks = asyncEventHandler.GetInvocationList()
            .Cast<HttpClientInterceptorEventHandler>()
            .Select(handler => handler.Invoke(this, args))
            .ToArray();
        await Task.WhenAll(asyncHandlerTasks);
    }
}