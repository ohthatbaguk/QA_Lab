using System.Net;
using System.Threading.Tasks;
using Allure.Xunit.Attributes;
using FluentAssertions;
using Homework_REST.Asserts;
using Homework_REST.Base;
using Homework_REST.Extensions;
using Homework_REST.Factories;
using Homework_REST.Mock;
using Homework_REST.Models.Message;
using Homework_REST.Models.SuiteModel;
using Homework_REST.Utils;
using Xunit;
using Xunit.Abstractions;
using ErrorMessage = Homework_REST.Constants.Message.ErrorMessage;

namespace Homework_REST.Tests.Suite
{
    public class AddSuiteTests : BaseTest
    {
        public AddSuiteTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [AllureXunit(DisplayName = "POST index.php?/api/v2/add_suite/{project_id} returns 200")]
        public async Task AddSuite_ShouldReturnOK()
        {
            //Arrange
            SetAuthorization();

            var suiteModel = SuiteFactory.GetSuiteModel();
            var projectModel = ProjectFactory.GetProjectModel();
            
            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectSteps.GetProjectId(project);

            //Act
            var response = await SuiteService.AddSuite(projectId, suiteModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseSuite = NewtonsoftJsonSerializer.Deserialize<ResponseSuiteModel>(response);
            SuiteAssert.ValidateSuiteResult(suiteModel, responseSuite);

        }

        [AllureXunitTheory(DisplayName = 
            "POST index.php?/api/v2/add_suite/{project_id} when required field has incorrect value returns 400")]
        [MemberData(nameof(SuiteMocks.IncorrectValuesForAddSuite), MemberType = typeof(SuiteMocks))]
        public async Task AddSuite_WhenSuite_ShouldReturnBadRequest(string serializedProject, string typeOfError)
        {
            //Arrange
            SetAuthorization();

            var projectModel = ProjectFactory.GetProjectModel();
            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectSteps.GetProjectId(project);
            var suiteModel = NewtonsoftJsonSerializer.DefaultDeserialize<RequestSuiteModel>(serializedProject);

            //Act
            var response = await SuiteService.AddSuite(projectId, suiteModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            
            var responseMessage = NewtonsoftJsonSerializer.Deserialize<Error>(response);
            ErrorAssert.ValidateErrorMessage(responseMessage, typeOfError);
            
        }

        [AllureXunit(DisplayName = "POST index.php?/api/v2/add_suite/{project_id} when unauthorized returns 401")]
        public async Task AddSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            SetAuthorization();
            ClientExtended.ClearAuthorization();

            var suiteModel = SuiteFactory.GetSuiteModel();
            const int projectId = 123;

            //Act
            var response = await SuiteService.AddSuite(projectId, suiteModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            
            var responseMessage = NewtonsoftJsonSerializer.Deserialize<Error>(response);
            ErrorAssert.ValidateErrorMessage(responseMessage, ErrorMessage.FailedAuthentication);
        }
    }
}