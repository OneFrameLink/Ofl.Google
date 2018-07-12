using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ofl.Google
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGoogleApi(this IServiceCollection serviceCollection,
            IConfiguration apiKeyConfiguration)
        {
            // Validate parameters.
            var sc = serviceCollection ?? throw new ArgumentNullException(nameof(serviceCollection));
            if (apiKeyConfiguration == null) throw new ArgumentNullException(nameof(apiKeyConfiguration));

            // Configure the options.
            sc = sc.Configure<ApiKeyConfiguration>(apiKeyConfiguration.Bind);

            // Configure the api key provider.
            sc = sc.AddTransient<IApiKeyProvider, ConfigurationApiKeyProvider>();

            // Return the service configuration.
            return sc;
        }
    }
}
