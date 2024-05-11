using System.Text.Json;

namespace snowcoreBlog.PublicApi;

public record ApiResponse(JsonElement? Data = default, int DataCount = 0, int StatusCode = -1, IReadOnlyCollection<string>? Errors = default);