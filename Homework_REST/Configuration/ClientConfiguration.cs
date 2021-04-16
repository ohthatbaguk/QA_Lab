using System;
using Homework_REST.Clients;
using Microsoft.Extensions.Logging;

namespace Homework_REST.Configuration
{
    public static class ClientConfiguration
    {
        public static ClientExtended ConfigureHttpClient(ILoggerFactory loggerFactory)
        {
            var httpClient = new ClientExtended(loggerFactory.CreateLogger<ClientExtended>(),
                new Uri(Startup.AppSettings.AppUrl));

            return httpClient;
        }
    }
}