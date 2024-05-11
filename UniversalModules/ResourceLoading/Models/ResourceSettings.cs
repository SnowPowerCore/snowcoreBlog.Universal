using MinimalStepifiedSystem.Utils;

namespace snowcoreBlog.ResourceLoading.Models;

public class ResourceSettings
{
    public bool UseBase { get; set; } = true;

    public DictionaryWithDefault<Type, string> AdditionalPaths { get; set; } =
        new(defaultValue: string.Empty);
}