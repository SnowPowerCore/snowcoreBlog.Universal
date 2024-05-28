using System.Text.Json;

namespace snowcoreBlog.PublicApi;

public static class JsonExtensions
{
    private static readonly JsonSerializerOptions _serializerOptions = new(JsonSerializerDefaults.Web);

    public static JsonElement ToJsonElement(this object @object) =>
        JsonSerializer.SerializeToElement(@object, _serializerOptions);
}