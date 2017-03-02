using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ofl.Core.Net.Http;

namespace Ofl.Google
{
    public abstract class GoogleApiClient : JsonApiClient
    {
        #region Constructor

        protected GoogleApiClient(IApiKeyProvider apiKeyProvider, IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            // Validate parameters.
            if (apiKeyProvider == null) throw new ArgumentNullException(nameof(apiKeyProvider));

            // Assign values.
            ApiKeyProvider = apiKeyProvider;
        }

        #endregion

        #region Instance, read-only state.

        protected IApiKeyProvider ApiKeyProvider { get; }

        #endregion

        #region Overrides

        protected override Task<HttpClient> CreateHttpClientAsync(CancellationToken cancellationToken)
        {
            // Call the overload, create the message handler.
            return CreateHttpClientAsync(new GoogleApiMessageHandler(ApiKeyProvider), cancellationToken);
        }

        #endregion
    }
}
