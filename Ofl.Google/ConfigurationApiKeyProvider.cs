using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Ofl.Google
{
    public class ConfigurationApiKeyProvider : IApiKeyProvider
    {
        #region Constructor

        public ConfigurationApiKeyProvider(IOptions<ApiKeyConfiguration> apiKeyConfiguration)
        {
            // Validate parameters.
            if (string.IsNullOrWhiteSpace(apiKeyConfiguration?.Value?.ApiKey)) throw new ArgumentNullException(nameof(apiKeyConfiguration));

            // Assign values.
            _apiKeyConfiguration = apiKeyConfiguration.Value;
        }

        #endregion

        #region Instance, read-only state.

        private readonly ApiKeyConfiguration _apiKeyConfiguration;

        #endregion

        #region Implementation of IApiKeyProvider

        public Task<string> GetApiKeyAsync(CancellationToken cancellationToken)
        {
            // Return the configuration.
            return Task.FromResult(_apiKeyConfiguration.ApiKey);
        }

        #endregion
    }
}
