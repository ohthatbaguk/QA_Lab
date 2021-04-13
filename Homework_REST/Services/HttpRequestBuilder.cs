using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Homework_REST.Services
{
    public static class HttpRequestBuilder 
    {
        public static HttpRequestMessage Build(string uri, HttpMethod method, object payload = default)
        {
            var json = JsonConvert.SerializeObject(payload);
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(uri, UriKind.Relative),
                Method = method,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
            return request;
        }
    }
}