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
            responseSuiteModel.CompletedOn.Should().Be(null);
            responseSuiteModel.IsMaster.Should().Be(false);
            responseSuiteModel.IsBaseline.Should().Be(false);
            responseSuiteModel.IsCompleted.Should().Be(false);

        }
    }
}