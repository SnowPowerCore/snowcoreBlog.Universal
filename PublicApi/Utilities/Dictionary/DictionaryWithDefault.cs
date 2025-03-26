using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace snowcoreBlog.PublicApi.Utilities.Dictionary;

public sealed class DictionaryWithDefault<TKey, TValue>(TValue defaultValue) : Dictionary<TKey, TValue> where TKey : notnull
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public DictionaryWithDefault() : this(defaultValue: default) { }

    public TValue DefaultValue { get; init; } = defaultValue;

    public new TValue this[[NotNull] TKey key]
    {
        get => TryGetValue(key, out var t) ? t : DefaultValue;
        set => base[key] = value;
    }
}