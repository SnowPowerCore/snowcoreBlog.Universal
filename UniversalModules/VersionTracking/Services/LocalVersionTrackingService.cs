using System.Reflection;
using System.Text;
using MinimalStepifiedSystem.Utils;
using snowcoreBlog.LocalStorage.Interfaces;
using snowcoreBlog.VersionTracking.Interfaces;

namespace snowcoreBlog.VersionTracking.Services;

public class LocalVersionTrackingService : IVersionTrackingService
{
    private const string VersionTrailKey = $"{nameof(LocalVersionTrackingService)}.Trail";
    private const string VersionsKey = $"{nameof(LocalVersionTrackingService)}.Versions";
    private const string BuildsKey = $"{nameof(LocalVersionTrackingService)}.Builds";

    private readonly ILocalStorageService _localStorage;

    private static readonly char[] _separator = ['|'];

    private DictionaryWithDefault<string, List<string>> _versionTrail;

    public LocalVersionTrackingService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;

        var version = Assembly.GetCallingAssembly().GetName().Version;
        CurrentVersion = version?.ToString();
        CurrentBuild = version?.Build.ToString();

        InitVersionTracking();

        PreviousVersion = GetPrevious(VersionsKey);
        PreviousBuild = GetPrevious(BuildsKey);
        FirstInstalledVersion = _versionTrail[VersionsKey].FirstOrDefault();
        FirstInstalledBuild = _versionTrail[BuildsKey].FirstOrDefault();
        LastInstalledVersion = _versionTrail[VersionsKey].LastOrDefault();
        LastInstalledBuild = _versionTrail[BuildsKey].LastOrDefault();
        VersionHistory = [.. _versionTrail[VersionsKey]];
        BuildHistory = [.. _versionTrail[BuildsKey]];
    }

    public bool IsFirstLaunchEver { get; private set; }

    public bool IsFirstLaunchForCurrentVersion { get; private set; }

    public bool IsFirstLaunchForCurrentBuild { get; private set; }

    public string CurrentVersion { get; private set; }

    public string CurrentBuild { get; private set; }

    public string PreviousVersion { get; private set; }

    public string PreviousBuild { get; private set; }

    public string FirstInstalledVersion { get; private set; }

    public string FirstInstalledBuild { get; private set; }

    private string LastInstalledVersion { get; set; }

    private string LastInstalledBuild { get; set; }

    public IEnumerable<string> VersionHistory { get; private set; }

    public IEnumerable<string> BuildHistory { get; private set; }

    public void Track() { }

    public bool IsFirstLaunchForVersion(string version) =>
        CurrentVersion == version && IsFirstLaunchForCurrentVersion;

    public bool IsFirstLaunchForBuild(string build) =>
        CurrentBuild == build && IsFirstLaunchForCurrentBuild;

    /// <summary>
    /// Initialize VersionTracking module, load data and track current version
    /// </summary>
    /// <remarks>
    /// For internal use. Usually only called once in production code, but multiple times in unit tests
    /// </remarks>
    internal void InitVersionTracking()
    {
        IsFirstLaunchEver = !_localStorage.HasKey(VersionsKey) || !_localStorage.HasKey(BuildsKey);
        if (IsFirstLaunchEver)
        {
            _versionTrail = new(defaultValue: [])
            {
                [VersionsKey] = [],
                [BuildsKey] = []
            };
        }
        else
        {
            _versionTrail = new(defaultValue: [])
            {
                [VersionsKey] = [.. ReadHistory(VersionsKey)],
                [BuildsKey] = [.. ReadHistory(BuildsKey)]
            };
        }

        IsFirstLaunchForCurrentVersion = !_versionTrail[VersionsKey].Contains(CurrentVersion) || CurrentVersion != LastInstalledVersion;
        if (IsFirstLaunchForCurrentVersion)
        {
            // Avoid duplicates and move current version to end of list if already present
            _versionTrail[VersionsKey].RemoveAll(v => v == CurrentVersion);
            _versionTrail[VersionsKey].Add(CurrentVersion);
        }

        IsFirstLaunchForCurrentBuild = !_versionTrail[BuildsKey].Contains(CurrentBuild) || CurrentBuild != LastInstalledBuild;
        if (IsFirstLaunchForCurrentBuild)
        {
            // Avoid duplicates and move current build to end of list if already present
            _versionTrail[BuildsKey].RemoveAll(b => b == CurrentBuild);
            _versionTrail[BuildsKey].Add(CurrentBuild);
        }

        if (IsFirstLaunchForCurrentVersion || IsFirstLaunchForCurrentBuild)
        {
            WriteHistory(VersionsKey, _versionTrail[VersionsKey]);
            WriteHistory(BuildsKey, _versionTrail[BuildsKey]);
        }
    }

    internal string GetStatus()
    {
        var sb = new StringBuilder();
        sb.AppendLine();
        sb.AppendLine("Version Tracking: ");
        sb.AppendLine($"  IsFirstLaunchEver:              {IsFirstLaunchEver}");
        sb.AppendLine($"  IsFirstLaunchForCurrentVersion: {IsFirstLaunchForCurrentVersion}");
        sb.AppendLine($"  IsFirstLaunchForCurrentBuild:   {IsFirstLaunchForCurrentBuild}");
        sb.AppendLine();
        sb.AppendLine($"  CurrentVersion:                 {CurrentVersion}");
        sb.AppendLine($"  PreviousVersion:                {PreviousVersion}");
        sb.AppendLine($"  FirstInstalledVersion:          {FirstInstalledVersion}");
        sb.AppendLine($"  VersionHistory:                 [{string.Join(", ", VersionHistory)}]");
        sb.AppendLine();
        sb.AppendLine($"  CurrentBuild:                   {CurrentBuild}");
        sb.AppendLine($"  PreviousBuild:                  {PreviousBuild}");
        sb.AppendLine($"  FirstInstalledBuild:            {FirstInstalledBuild}");
        sb.AppendLine($"  BuildHistory:                   [{string.Join(", ", BuildHistory)}]");
        return sb.ToString();
    }

    private string[] ReadHistory(string key) =>
        _localStorage.Get<string>(key)?.Split(_separator, StringSplitOptions.RemoveEmptyEntries) ?? [];

    private void WriteHistory(string key, IEnumerable<string> history) =>
        _localStorage.Set(key, string.Join("|", history));

    private string GetPrevious(string key)
    {
        var trail = _versionTrail[key];
        return trail.Count >= 2 ? trail[trail.Count - 2] : default;
    }
}