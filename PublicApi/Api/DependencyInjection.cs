

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
    using Apizr;
    using Apizr.Extending.Configuring.Common;



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
                        config.Retry = new HttpRetryStrategyOptions
                        {
                            UseJitter = true,
                            MaxRetryAttempts = 3,
                            Delay = TimeSpan.FromSeconds(0.5)
                        };
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

