using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ofl.Net.Http.ApiClient.Json;

namespace Ofl.Google
{
    public abstract class GoogleApiClient : JsonApiClient
    {
        #region Constructor

        protected GoogleApiClient(IApiKeyProvider apiKeyProvider, IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            // Validate parameters.
            ApiKeyProvider = apiKeyProvider ?? throw new ArgumentNullException(nameof(apiKeyProvider));
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
