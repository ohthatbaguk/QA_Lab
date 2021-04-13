using System.Net;
using System.Net.Http;
using Homework_REST.Exceptions;

namespace Homework_REST.Extensions
{
    public static class RestResponseExtensions
    {
        public static void VerifyResponseStatusCode(
            this HttpResponseMessage response,
            HttpStatusCode expectedStatusCode, string message)
        {
            if (response.StatusCode == expectedStatusCode) return;
            throw new PreconditionFailedException(
                
                $"Invalid response status code. Expected to be {expectedStatusCode} but found {response.StatusCode}" +  $"\n{message}");
        }
    }
}