using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace Homework_REST.Utils
{
    public class ClientLogging
    {
        private readonly ILogger _logger;

        public ClientLogging(ILogger logger)
        {
            _logger = logger;
        }

        public void LogRequest(HttpRequestMessage request)
        {
            _logger.LogInformation($"{request.Method} request to : {request.RequestUri}");

            var body = request.Content.ReadAsStringAsync().Result;

            if (body != null)
            {
                _logger.LogInformation(
                    $"body : {FormatRequestBody(body)}");
            }
        }

        public void LogResponse(HttpResponseMessage response)
        {
            _logger.LogInformation($"Request finished with status code : {response.StatusCode}");


            if (!string.IsNullOrEmpty(response.Content.ReadAsStringAsync().Result))
            {
                _logger.LogInformation(FormatRequestBody(response.Content.ReadAsStringAsync().Result));
            }
        }

        private static string FormatRequestBody(string body)
        {
            return JToken.Parse(body).ToString(Formatting.Indented);
        }
    }
}