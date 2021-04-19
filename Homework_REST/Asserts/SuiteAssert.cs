using FluentAssertions;
using Homework_REST.Models.SuiteModel;

namespace Homework_REST.Asserts
{
    public static class SuiteAssert
    {
        public static void ValidateSuiteResult(
            RequestSuiteModel requestSuiteModel,
            ResponseSuiteModel responseSuiteModel)
        {
            responseSuiteModel.Description.Should().Be(requestSuiteModel.Description);
            responseSuiteModel.Name.Should().Be(requestSuiteModel.Name);
            responseSuiteModel.Url.Should().Contain(Startup.AppSettings.Services.TestRailApp.AppUrl);
            responseSuiteModel.Id.Should().NotBe(null);
        }
    }
}