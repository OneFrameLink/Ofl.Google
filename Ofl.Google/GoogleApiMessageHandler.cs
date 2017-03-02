using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ofl.Core.Net.Http;

namespace Ofl.Google
{
    internal class GoogleApiMessageHandler : HttpClientHandler
    {
        #region Constructor.

        internal GoogleApiMessageHandler(IApiKeyProvider apiKeyProvider)
        {
            // Validate parameters.
            if (apiKeyProvider == null) throw new ArgumentNullException(nameof(apiKeyProvider));

            // Assign values.
            _apiKeyProvider = apiKeyProvider;

            // Set compression.
            this.SetCompression();
        }

        #endregion

        #region Instance, read-only state.

        private readonly IApiKeyProvider _apiKeyProvider;

        #endregion

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Validate parameters.
            if (request == null) throw new ArgumentNullException(nameof(request));

            // Add the key to the URL.
            request.RequestUri = await _apiKeyProvider.AddKeyToQueryStringAsync(request.RequestUri, cancellationToken).
                ConfigureAwait(false);

            // Call the base.
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
