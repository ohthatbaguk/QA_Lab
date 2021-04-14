using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Homework_REST.Utils;
using Microsoft.Extensions.Logging;

namespace Homework_REST.Clients
{
    public sealed class ClientExtended : ClientLogging
    {
        public ClientExtended(ILogger logger) : base(logger)
        {
        }
        
        public static async Task<HttpResponseMessage> ExecuteAsync(HttpClient client, 
            HttpRequestMessage request, CancellationToken token = default)
        {
            //LogRequest(request);
            var response = await client.SendAsync(request, token);
            //LogResponse(response);
            return response;
        }

    
    }
}