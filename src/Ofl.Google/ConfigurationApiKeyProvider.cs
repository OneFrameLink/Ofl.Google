using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Ofl.Google
{
    public class ConfigurationApiKeyProvider : IApiKeyProvider
    {
        #region Constructor

        public ConfigurationApiKeyProvider(IOptions<ApiKeyConfiguration> apiKeyConfigurationOptions)
        {
            // Validate parameters.
            _apiKeyConfigurationOptions = apiKeyConfigurationOptions ??
                throw new ArgumentNullException(nameof(apiKeyConfigurationOptions));
        }

        #endregion

        #region Instance, read-only state.

        private readonly IOptions<ApiKeyConfiguration> _apiKeyConfigurationOptions;

        #endregion

        #region Implementation of IApiKeyProvider

        public Task<string> GetApiKeyAsync(CancellationToken cancellationToken)
        {
            // Return the configuration.
            return Task.FromResult(_apiKeyConfigurationOptions.Value.ApiKey);
        }

        #endregion
    }
}
