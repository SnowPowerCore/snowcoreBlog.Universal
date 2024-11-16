using System.Text.Json;

namespace snowcoreBlog.PublicApi.Extensions;

public static class JsonExtensions
{
    public static JsonElement ToJsonElement(this object @object, JsonSerializerOptions options) =>
        JsonSerializer.SerializeToElement(@object, options);
}