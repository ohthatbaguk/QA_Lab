using System;
using System.Net.Http.Headers;
using System.Text;
using Homework_REST.Clients;

namespace Homework_REST.Extensions
{
    public static class ClientExtensions
    {
        public static void SetAuthorization(this ClientExtended clientExtended, string token)
        {
            ClearAuthorization(clientExtended);
            var encoding = Encoding.UTF8;
            clientExtended.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(encoding.GetBytes(token)));
        }

        public static void ClearAuthorization(this ClientExtended clientExtended)
        {
            clientExtended.DefaultRequestHeaders.Authorization = null;
        }
    }
}