using System;
using System.Net.Http;
using System.Text;
using Homework_REST.Constants;
using Homework_REST.Utils;

namespace Homework_REST.Services
{
    public static class HttpRequestBuilder
    {
        public static HttpRequestMessage Build(string uri, HttpMethod method, object payload = default)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(uri, UriKind.Relative),
                Method = method,
                Content = new StringContent(NewtonsoftJsonSerializer.Serialize(payload),
                    Encoding.UTF8, ContentType.MediaType)
            };
            return request;
        }
    }
}