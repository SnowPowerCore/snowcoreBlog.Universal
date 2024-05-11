using System.Diagnostics.CodeAnalysis;

namespace snowcoreBlog.LocalStorage.Interfaces;

public interface ILocalStorageService
{
    bool HasKey(string possibleKey);

    object Get(string key);

    T? Get<T>(string key) where T : class;

    void Set<T>([NotNull] string key, T value);

    void Clear();
}