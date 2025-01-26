namespace snowcoreBlog.VersionTracking.Interfaces;

public interface IVersionTrackingService
{
    bool IsFirstLaunchEver { get; }

    bool IsFirstLaunchForCurrentVersion { get; }

    bool IsFirstLaunchForCurrentBuild { get; }

    string CurrentVersion { get; }

    string CurrentBuild { get; }

    string? PreviousVersion { get; }

    string? PreviousBuild { get; }

    string? FirstInstalledVersion { get; }

    string? FirstInstalledBuild { get; }

    public IEnumerable<string> VersionHistory { get; }

    public IEnumerable<string> BuildHistory { get; }

    void Track();

    bool IsFirstLaunchForVersion(string version);

    bool IsFirstLaunchForBuild(string build);
}