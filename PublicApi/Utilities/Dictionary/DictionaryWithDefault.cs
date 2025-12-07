using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace snowcoreBlog.PublicApi.Utilities.Dictionary;

public sealed class DictionaryWithDefault<TKey, TValue>(TValue defaultValue, int capacity) : Dictionary<TKey, TValue>(capacity) where TKey : notnull
{
    public TValue DefaultValue { get; init; } = defaultValue;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public DictionaryWithDefault() : this(defaultValue: default, 0) { }

    public new TValue this[[NotNull] TKey key]
    {
        get => TryGetValue(key, out var t) ? t : DefaultValue;
        set => base[key] = value;
    }
}