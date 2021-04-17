using System.Net.Http;
using FluentAssertions;
using Homework_REST.Models.SuiteModel;
using Homework_REST.Utils;

namespace Homework_REST.Asserts
{
    public static class SuiteAssert
    {
        public static void ValidateSuiteResult(
            HttpResponseMessage responseMessage,
            RequestSuiteModel requestSuiteModel)
        {
            var suiteModel = NewtonsoftJsonSerializer.Deserialize<ResponseSuiteModel>(responseMessage);
            
            suiteModel.Description.Should().Be(requestSuiteModel.Description);
            suiteModel.Name.Should().Be(requestSuiteModel.Name);
            suiteModel.Url.Should().Contain(Startup.AppSettings.Services.TestRailApp.AppUrl);
            suiteModel.Id.Should().NotBe(null);
            
        }
    }
}