using System.Globalization;
using System.Text.Json;
using Microsoft.Extensions.Options;
using MinimalStepifiedSystem.Utils;
using snowcoreBlog.ResourceLoading.Interfaces;
using snowcoreBlog.ResourceLoading.Models;

namespace snowcoreBlog.ResourceLoading.Implementations.Services;

public class JsonLocalResourceService : IResourceService
{
    private readonly Dictionary<string, JsonLocalization[]> _localization = [];

    public JsonLocalResourceService(IOptions<ResourceSettings> resourceSettings)
    {
        if (resourceSettings.Value.UseBase)
            PopulateLocalization("Resources");

        if (resourceSettings.Value.AdditionalPaths is default(DictionaryWithDefault<Type, string>))
            return;

        foreach (var additional in resourceSettings.Value.AdditionalPaths)
        {
            var codeBase = additional.Key.Assembly.Location;
            var uri = new UriBuilder(codeBase);
            var data = Uri.UnescapeDataString(uri.Path);
            var path = Path.GetDirectoryName(data);
            var fullPath = Path.Combine(path!, additional.Value);
            PopulateLocalization(fullPath);
        }
    }

    /// <summary>
    /// resource:key:culture<br />
    /// resource is the resource name<br />
    /// key is the key you're looking for<br />
    /// culture is optional
    /// </summary>
    /// <param name="key"></param>
    public string this[string key] => GetString(key);

    private void PopulateLocalization(string path)
    {
        foreach (var resource in Directory.EnumerateFiles(path, "*.json", SearchOption.AllDirectories))
        {
            try
            {
                var fileInfo = new FileInfo(resource);
                var fileName = fileInfo.Name[..fileInfo.Name.IndexOf('.')];
                _localization[fileName] = JsonSerializer.Deserialize<JsonLocalization[]>(File.ReadAllText(resource));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Resource Manager: Something went wrong, check the inner exception. "
                    + $"Inner exception: {ex.InnerException?.Message ?? ex.Message}");
            }
        }
    }

    private string GetString(string query)
    {
        try
        {
            var culture = default(string);

            var split = query.Split(':');
            var resource = split[0];
            var key = split[1];
            if (split.Length > 2)
                culture = split[2];

            culture ??= CultureInfo.CurrentCulture.Name;

            var resValue = _localization
                .Single(l => l.Key == resource)
                .Value.Single(x => x.Key == key);

            return resValue.LocalizedValues[culture]
                ?? resValue.LocalizedValues["_"];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Resource Manager: Couldn't find the key: {query}. "
                + $"Inner exception: {ex.InnerException?.Message ?? ex.Message}");
            return string.Empty;
        }
    }
}