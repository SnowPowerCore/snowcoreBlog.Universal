using Apizr;
using Apizr.Extending.Configuring.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using snowcoreBlog.PublicApi.Api;

namespace snowcoreBlog.PublicApi.Extensions;

public static class NotificationsApizrConfigurationExtensions
{
    /// <summary>
    /// Hand-written companion to the Refitter-generated Configure*ApizrManagers methods:
    /// registers the Apizr manager for the ServiceNotifications API. The caller passes
    /// base address, Refit settings and per-side message handlers through the options
    /// builder (same pattern as the generated managers).
    /// </summary>
    public static IServiceCollection ConfigureSnowcoreBlogBackendNotificationsApizrManagers(
        this IServiceCollection services,
        Action<IApizrExtendedCommonOptionsBuilder> optionsBuilder)
    {
        optionsBuilder ??= _ => { };
        optionsBuilder += static options => options
            .ConfigureHttpClientBuilder(static builder => builder
                .AddStandardResilienceHandler(static config =>
                {
                    var timeSpan = TimeSpan.FromMinutes(1);
                    config.AttemptTimeout.Timeout = timeSpan;
                    config.CircuitBreaker.SamplingDuration = timeSpan * 2;
                    config.TotalRequestTimeout.Timeout = timeSpan * 3;
                    config.Retry = new HttpRetryStrategyOptions
                    {
                        UseJitter = true,
                        MaxRetryAttempts = 3,
                        Delay = TimeSpan.FromSeconds(0.5)
                    };
                }));

        return services.AddApizr(
            registry => registry.AddManagerFor<INotificationsApi>(),
            optionsBuilder);
    }
}
