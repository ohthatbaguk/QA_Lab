using System.Net;
using System.Net.Http;
using Homework_REST.Exceptions;
using Homework_REST.Models.Message;
using Homework_REST.Models.ProjectModel;
using Homework_REST.Models.SuiteModel;
using Homework_REST.Utils;

namespace Homework_REST.Extensions
{
    public static class ResponseExtensions
    {
        public static void VerifyResponseStatusCode(
            this HttpResponseMessage response,
            HttpStatusCode expectedStatusCode, string message)
        {
            if (response.StatusCode == expectedStatusCode) return;
            throw new PreconditionFailedException(
                $"Invalid response status code. Expected to be {expectedStatusCode} but found {response.StatusCode}" +
                $"\n{message}");
        }

        public static Error GetErrors(this HttpResponseMessage responseMessage)
        {
            return NewtonsoftJsonSerializer.Deserialize<Error>(responseMessage);
        }

        public static ResponseSuiteModel GetResponseSuiteModel(this HttpResponseMessage responseMessage)
        {
            return NewtonsoftJsonSerializer.Deserialize<ResponseSuiteModel>(responseMessage);
        }

        public static ResponseProjectModel GetResponseProjectModel(this HttpResponseMessage responseMessage)
        {
            return NewtonsoftJsonSerializer.Deserialize<ResponseProjectModel>(responseMessage);
        }
    }
}