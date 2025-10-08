

#nullable enable
namespace snowcoreBlog.PublicApi.Api
{
    // Please make sure to complete the following steps resulting from your configuration:
    // - dotnet add package Apizr.Integrations.FileTransfer.MediatR, then register MediatR
    // - dotnet add package Apizr.Integrations.Fusillade
    // - Add your file transfer manager while calling ConfigureSnowcoreBlogBackendReadersManagementApizrManagers method thanks to its options builder parameter

    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Http.Resilience;
    using MediatR;
    using Apizr;
    using Apizr.Extending.Configuring.Common;
    using Polly.Timeout;
    using Polly;

    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Register all your Apizr managed apis with common shared options.
        /// You may call WithConfiguration option to adjust settings to your need.
        /// </summary>
        /// <param name="optionsBuilder">Adjust common shared options</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureSnowcoreBlogBackendReadersManagementApizrManagers(
            this IServiceCollection services,
            Action<IApizrExtendedCommonOptionsBuilder> optionsBuilder)
        {
            optionsBuilder ??= _ => { }; // Default empty options if null
            optionsBuilder += options => options
                .ConfigureHttpClientBuilder(builder => builder
                    .AddStandardResilienceHandler(config =>
                    {
                        // This code changes the default AttemptTimeout and TotalRequestTimeout for an endpoint that has a long-running import operation.

                        config.Retry = new HttpRetryStrategyOptions
                        {
                            UseJitter = true,
                            MaxRetryAttempts = 3,
                            Delay = TimeSpan.FromSeconds(0.5)
                        };
                        
                        config.AttemptTimeout.TimeoutGenerator = timeoutGenerator(
                            config.AttemptTimeout.Timeout,
                            TimeSpan.FromMinutes(1));

                        config.TotalRequestTimeout.TimeoutGenerator = timeoutGenerator(
                            config.TotalRequestTimeout.Timeout,
                            config.Retry.MaxRetryAttempts * TimeSpan.FromMinutes(1));

                        Func<TimeoutGeneratorArguments, ValueTask<TimeSpan>> timeoutGenerator(TimeSpan defaultTimeout, TimeSpan importTimeout)
                        {
                            return arguments =>
                            {
                                // add the using Polly; namespace for GetRequestMessage()
                                var tryRequestMessage = arguments.Context.GetRequestMessage();
                                var timeout = tryRequestMessage switch
                                {
                                    HttpRequestMessage request when request.RequestUri.AbsolutePath.EndsWith("/import")
                                                => ValueTask.FromResult(importTimeout),
                                    _ => ValueTask.FromResult(defaultTimeout),
                                };

                                return timeout;
                            };
                        }
                    }))
                .WithPriority()
                .WithMediation()
                .WithFileTransferMediation();
            
            return services.AddApizr(
                registry => registry
                  .AddManagerFor<ITokensApi>()
                  .AddManagerFor<IReaderAccountManagementApi>(),
                optionsBuilder);

        }
    }
}

