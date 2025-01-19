namespace snowcoreBlog.PublicApi.Utilities.Api;

/// <summary>
/// Don't use anywhere besides Description(b => b.Produces<ApiResponseForOpenApi<T>>(200, "application/json")
/// </summary>
/// <typeparam name="T">Data type</typeparam>
public sealed record ApiResponseForOpenApi<T>(T? Data = default, int DataCount = 0, int StatusCode = -1, IReadOnlyCollection<string>? Errors = default);