using MinimalStepifiedSystem.Base;

namespace snowcoreBlog.ApplicationLaunch.Context;

public class LaunchContext(Version currentVersion) : BaseGenericContext
{
    public Version CurrentVersion { get; } = currentVersion;
}