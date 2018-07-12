using System;
using Microsoft.Extensions.DependencyInjection;

namespace Ofl.Google
{
    public static class HttpClientBuilderExtensions
    {
        public static IHttpClientBuilder ConfigureGoogleApiKeyProvider(this IHttpClientBuilder httpClientBuilder)
        {
            // Validate parameters.
            if (httpClientBuilder == null) throw new ArgumentNullException(nameof(httpClientBuilder));

            // Add the handler.
            httpClientBuilder = httpClientBuilder
                .ConfigurePrimaryHttpMessageHandler<GoogleApiMessageHandler>();

            // Return.
            return httpClientBuilder;
        }
    }
}
