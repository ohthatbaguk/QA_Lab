using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Homework_REST.Configuration;

namespace Homework_REST.Base
{
    public class BaseTest
    {
        private static readonly HttpClient Client = new HttpClient
        {
            BaseAddress =  new Uri(Configurator.AppUrl)
        };
        
        protected static HttpClient CreateHttpClient()
        {
           Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                EncodeCredential(Configurator.Username, Configurator.Password));

            return Client;
        }

        protected static HttpClient EmptyAuthorization()
        {
            Client.DefaultRequestHeaders.Authorization = null;
            
            return Client;
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
    }
}