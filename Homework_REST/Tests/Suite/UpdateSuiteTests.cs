using System.Net;
using System.Threading.Tasks;
using Allure.Xunit.Attributes;
using FluentAssertions;
using Homework_REST.Asserts;
using Homework_REST.Base;
using Homework_REST.Extensions;
using Homework_REST.Factories;
using Homework_REST.Mock;
using Homework_REST.Mock.Suite;
using Homework_REST.Models.Message;
using Homework_REST.Models.SuiteModel;
using Homework_REST.Utils;
using Xunit;
using Xunit.Abstractions;
using ErrorMessage = Homework_REST.Constants.Message.ErrorMessage;

namespace Homework_REST.Tests.Suite
{
    public class UpdateSuiteTests : BaseTest
    {
        public UpdateSuiteTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [AllureXunit(DisplayName = "POST index.php?/api/v2/update_suite/{suiteId} returns 200")]
        public async Task UpdateSuite_ShouldReturnOK()
        {
            //Arrange
            SetAuthorization();

            var suiteModel = SuiteFactory.GetSuiteModel().Generate();
            var projectModel = ProjectFactory.GetProjectModel().Generate();

            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectSteps.GetProjectId(project);

            var suite = await SuiteService.AddSuite(projectId, suiteModel);
            var suiteId = SuiteSteps.GetSuiteId(suite);
            var updateSuiteModel = SuiteFactory.GetSuiteModel().Generate();

            //Act
            var response = await SuiteService.UpdateSuite(suiteId, updateSuiteModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseSuite = NewtonsoftJsonSerializer.Deserialize<ResponseSuiteModel>(response);
            SuiteAssert.ValidateSuiteResult(updateSuiteModel, responseSuite);
        }

        [AllureXunit(DisplayName = "POST index.php?/api/v2/update_suite/{suiteId} when unauthorized returns 401")]
        public async Task UpdateSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            SetAuthorization();
            ClientExtended.ClearAuthorization();

            var suiteModel = SuiteFactory.GetSuiteModel().Generate();
            const int suiteId = 123;

            //Act
            var response = await SuiteService.UpdateSuite(suiteId, suiteModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            var errorResponse = NewtonsoftJsonSerializer.Deserialize<Error>(response);
            ErrorAssert.ValidateErrorMessage(errorResponse, ErrorMessage.FailedAuthentication);
        }

        [AllureXunitTheory(DisplayName =
            "POST index.php?/api/v2/update_suite/{suiteId} when suite Name has an incorrect format returns 400")]
        [MemberData(nameof(SuiteMocks.IncorrectIdForSuite), MemberType = typeof(SuiteMocks))]
        public async Task UpdateSuite_WhenNameHasIncorrectFormat_ShouldReturnBadRequest(string suiteId,
            string typeOfError)
        {
            //Arrange
            SetAuthorization();

            var suiteModel = SuiteFactory.GetSuiteModel().Generate();

            //Act
            var response = await SuiteService.UpdateSuite(suiteId, suiteModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var errorResponse = NewtonsoftJsonSerializer.Deserialize<Error>(response);
            ErrorAssert.ValidateErrorMessage(errorResponse, typeOfError);
        }

        [AllureXunitTheory(DisplayName =
            "POST index.php?/api/v2/update_suite/{suiteId} when field more than max length returns 400")]
        [MemberData(nameof(SuiteMocks.IncorrectValuesForUpdateSuite), MemberType = typeof(SuiteMocks))]
        public async Task UpdateSuite_WhenFieldMoreThanMaxLengthValue_ShouldReturnBadRequest(
            string serializedSuite, string typeOfError)
        {
            //Arrange
            SetAuthorization();

            var projectModel = ProjectFactory.GetProjectModel().Generate();
            var suiteModel = SuiteFactory.GetSuiteModel().Generate();

            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectSteps.GetProjectId(project);

            var suite = await SuiteService.AddSuite(projectId, suiteModel);
            var suiteId = SuiteSteps.GetSuiteId(suite);
            var updateSuiteModel = NewtonsoftJsonSerializer.DefaultDeserialize<RequestSuiteModel>(serializedSuite);

            //Act
            var response = await SuiteService.UpdateSuite(suiteId, updateSuiteModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var errorResponse = NewtonsoftJsonSerializer.Deserialize<Error>(response);
            ErrorAssert.ValidateErrorMessage(errorResponse, typeOfError);
        }
    }
}