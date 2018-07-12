using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Ofl.Net.Http;

namespace Ofl.Google
{
    public class GoogleApiMessageHandler : HttpClientHandler
    {
        #region Constructor.

        public GoogleApiMessageHandler(
            IApiKeyProvider apiKeyProvider)
        {
            // Validate parameters.
            _apiKeyProvider = apiKeyProvider ?? throw new ArgumentNullException(nameof(apiKeyProvider));

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
            // TODO: Should the original request URI be restored?
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
