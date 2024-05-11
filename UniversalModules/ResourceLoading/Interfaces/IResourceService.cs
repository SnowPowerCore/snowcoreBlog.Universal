namespace snowcoreBlog.ResourceLoading.Interfaces;

public interface IResourceService
{
    string this[string key] { get; }
}