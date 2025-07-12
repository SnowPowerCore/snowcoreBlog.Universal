using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace snowcoreBlog.PublicApi.Utilities.Dictionary;

public sealed class DictionaryWithDefault<TKey, TValue> : Dictionary<TKey, TValue> where TKey : notnull
{
    public TValue DefaultValue { get; init; }
    
    [EditorBrowsable(EditorBrowsableState.Never)]
    public DictionaryWithDefault() : this(defaultValue: default, 0) { }

    public DictionaryWithDefault(TValue defaultValue, int capacity) : base(capacity)
    {
        DefaultValue = defaultValue;
    }

    public new TValue this[[NotNull] TKey key]
    {
        get => TryGetValue(key, out var t) ? t : DefaultValue;
        set => base[key] = value;
    }
}