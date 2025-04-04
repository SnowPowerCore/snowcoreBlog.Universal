using System.Collections.Generic;

namespace snowcoreBlog.ResourceLoading.Implementations.Internal.Helper;

internal class TranslationData : Dictionary<string, object>
{
    public IDictionary<string, string> Flatten() => FlattenCore(this, string.Empty);

    private static Dictionary<string, string> FlattenCore(TranslationData translationData, string parentKey)
    {
        var result = new Dictionary<string, string>();
        foreach (var kvp in translationData)
        {
            var key = string.IsNullOrEmpty(parentKey) ? kvp.Key : $"{parentKey}::{kvp.Key}";
            if (kvp.Value is TranslationData nested)
            {
                foreach (var nestedKvp in FlattenCore(nested, key)) 
                    result[nestedKvp.Key] = nestedKvp.Value;
            }
            else
                result[key] = kvp.Value.ToString();
        }

        return result;
    }        
}