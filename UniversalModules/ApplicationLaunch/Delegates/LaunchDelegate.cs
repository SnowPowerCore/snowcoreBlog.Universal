using snowcoreBlog.ApplicationLaunch.Context;
using snowcoreBlog.ApplicationLaunch.Models;

namespace snowcoreBlog.ApplicationLaunch.Delegates;

public delegate Task<ApplicationLaunchResult> LaunchDelegate(LaunchContext context, CancellationToken token = default);