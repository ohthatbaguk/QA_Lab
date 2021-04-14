using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_REST.Clients
{
    public sealed class ClientExtended
    {
        public static async Task<HttpResponseMessage> ExecuteAsync(HttpClient client, 
            HttpRequestMessage request, CancellationToken token = default)
        {
            var response = await client.SendAsync(request, token);
            return response;
        }
    }
}