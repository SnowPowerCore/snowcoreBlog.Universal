﻿namespace snowcoreBlog.HttpClientInterception.Interceptor.HttpClient;

public delegate Task HttpClientInterceptorEventHandler(object sender, HttpClientInterceptorEventArgs e);