using MinimalStepifiedSystem.Utils;

namespace snowcoreBlog.ResourceLoading.Models;

public class JsonLocalization
{
    public string Key { get; set; } = string.Empty;

    public DictionaryWithDefault<string, string> LocalizedValues { get; set; } = [];
}