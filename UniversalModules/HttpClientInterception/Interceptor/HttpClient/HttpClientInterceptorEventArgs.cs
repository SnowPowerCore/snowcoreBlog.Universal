using System.Net.Http.Headers;

namespace snowcoreBlog.HttpClientInterception.Interceptor.HttpClient;

/// <summary>
/// Provides data for the event that is raised when before or after sending HTTP request.
/// </summary>
public class HttpClientInterceptorEventArgs : EventArgs
{
    private byte[] _capturedContentBytes;

    private HttpContentHeaders _capturedContentHeaders;

    internal Task _asyncTask = Task.CompletedTask;

    /// <summary>
    /// The HttpRequestMessage object uses or used sending HTTP request.
    /// </summary>
    public HttpRequestMessage Request { get; }

    /// <summary>
    /// The HttpResponseMessage object that is returned from HTTP request handler.<br/>
    /// This property is available only when "AfterSend" event is fired.
    /// <para>[NOTICE]<br/>Don't retrive content from the "Response.Content" property directly.<br/>
    /// Instead, call the "GetCapturedContentAsync()" method of this event arguments object to do it.</para>
    /// </summary>
    public HttpResponseMessage Response { get; }

    /// <summary>
    /// The exception object if an HTTP request has thrown an exception.
    /// </summary>
    public Exception Exception { get; }

    /// <summary>
    /// Cancel sending HTTP request
    /// </summary>
    public bool Cancel { get; set; }

    /// <summary>
    /// Provides data for the event that is raised when before sending HTTP request.
    /// </summary>
    /// <param name="request">Request</param>
    public HttpClientInterceptorEventArgs(HttpRequestMessage request) : this(request, response: null, exception: null) { }

    /// <summary>
    /// Provides data for the event that is raised when after sending HTTP request.
    /// </summary>
    /// <param name="request">Request</param>
    /// <param name="response">Response</param>
    /// <param name="exception">The exception object if an HTTP request has thrown an exception.</param>
    public HttpClientInterceptorEventArgs(HttpRequestMessage request, HttpResponseMessage response, Exception exception)
    {
        Request = request;
        Response = response;
        Exception = exception;
        Cancel = false;
    }

    /// <summary>
    /// Get the HttpContent object that is returned from HTTP request.<br/>
    /// This method is available only when "AfterSend" event is fired.<br/>
    /// You can call this method multiple times.
    /// </summary>
    public async ValueTask<HttpContent> GetCapturedContentAsync()
    {
        if (Response == null) throw new InvalidOperationException("You can call GetCapturedContentAsync() only when \"AfterSend\" event is fired.");

        if (_capturedContentBytes == null)
        {
            _asyncTask = CaptureContentAsync();
            await _asyncTask;
        }

        var httpContent = new ReadOnlyMemoryContent(_capturedContentBytes);
        foreach (var contentHeader in _capturedContentHeaders)
        {
            httpContent.Headers.Add(contentHeader.Key, contentHeader.Value);
        }
        return httpContent;
    }

    private async Task CaptureContentAsync()
    {
        await Response.Content.LoadIntoBufferAsync();

        _capturedContentHeaders = Response.Content.Headers;

        _capturedContentBytes = await Response.Content.ReadAsByteArrayAsync();
        await using var stream = await Response.Content.ReadAsStreamAsync();
        stream.Seek(0, SeekOrigin.Begin);
    }
}