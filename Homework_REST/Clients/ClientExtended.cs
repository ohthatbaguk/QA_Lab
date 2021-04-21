using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Homework_REST.Utils;
using Microsoft.Extensions.Logging;

namespace Homework_REST.Clients
{
    public sealed class ClientExtended : HttpClient
    {
        private readonly ClientLogging _clientLogging;

        public ClientExtended(ILogger logger, Uri baseUrl)
        {
            _clientLogging = new ClientLogging(logger);
            BaseAddress = baseUrl;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(HttpRequestMessage request,
            CancellationToken token = default)
        {
            ClientLogging.LogRequest(request);
            var response = await SendAsync(request, token);
            ClientLogging.LogResponse(response);
            return response;
        }
    }
}