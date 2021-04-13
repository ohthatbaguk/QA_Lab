using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Homework_REST.Configuration;

namespace Homework_REST.Extensions
{
    public static class Extension
    {
        public static HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(Configurator.AppUrl)
            };

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                EncodeCredential(Configurator.Username, Configurator.Password));

            return httpClient;
        }
        
        private static string EncodeCredential(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            var encoding = Encoding.UTF8;
            var credential = $"{username}:{password}";

            return Convert.ToBase64String(encoding.GetBytes(credential)); 
        }

        public static HttpClient EmptyAuthorization()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(Configurator.AppUrl)
            };

            httpClient.DefaultRequestHeaders.Authorization = null;
            
            return httpClient;
        }
    }
}