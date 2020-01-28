using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace Ofl.Google
{
    public static class ApiKeyProviderExtensions
    {
        public static async Task<string> AddKeyToQueryStringAsync(
            this IApiKeyProvider apiKeyProvider, 
            string url,
            CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (apiKeyProvider == null) throw new ArgumentNullException(nameof(apiKeyProvider));
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentNullException(nameof(url));

            // The key.
            const string name = "key";

            // Get the value.
            string value = await apiKeyProvider
                .GetApiKeyAsync(cancellationToken)
                .ConfigureAwait(false);

            // Append and return.
            return QueryHelpers.AddQueryString(url, name, value);
        }

        public static async Task<Uri> AddKeyToQueryStringAsync(
            this IApiKeyProvider apiKeyProvider, 
            Uri url,
            CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (apiKeyProvider == null) throw new ArgumentNullException(nameof(apiKeyProvider));
            if (url == null) throw new ArgumentNullException(nameof(url));

            // Call the overload.
            return new Uri(await apiKeyProvider.AddKeyToQueryStringAsync(url.ToString(), cancellationToken).ConfigureAwait(false));
        }
    }
}
