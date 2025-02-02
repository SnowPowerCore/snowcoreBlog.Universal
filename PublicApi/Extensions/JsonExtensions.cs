using System.Text.Json;

namespace snowcoreBlog.PublicApi.Extensions;

public static class JsonExtensions
{
    public static JsonDocument ToJsonDocument(this object @object, JsonSerializerOptions options) =>
        JsonSerializer.SerializeToDocument(@object, options);
}