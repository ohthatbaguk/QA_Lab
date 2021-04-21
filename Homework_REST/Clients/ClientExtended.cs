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
            _clientLogging.LogRequest(request);
            var response = await SendAsync(request, token);
            _clientLogging.LogResponse(response);
            return response;
        }
    }
}