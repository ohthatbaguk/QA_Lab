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
using Homework_REST.Models.ProjectModel;
using Homework_REST.Utils;
using Xunit;
using Xunit.Abstractions;
using ErrorMessage = Homework_REST.Constants.Message.ErrorMessage;

namespace Homework_REST.Tests.Project
{
    public class GetProjectTests : BaseTest
    {
        public GetProjectTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [AllureXunit(DisplayName = "GET index.php?/api/v2/get_project/{projectId} when unauthorized returns 401")]
        public async Task GetProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            SetAuthorization();
            ClientExtended.ClearAuthorization();

            const int projectId = 123;

            //Act
            var response = await ProjectService.GetProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            
            var responseMessage = NewtonsoftJsonSerializer.Deserialize<Error>(response);
            ErrorAssert.ValidateErrorMessage(responseMessage, ErrorMessage.FailedAuthentication);
        }

        [AllureXunit(DisplayName = "GET index.php?/api/v2/get_project/{projectId} returns 200")]
        public async Task GetProject_ShouldReturnOK()
        {
            //Arrange
            SetAuthorization();

            var projectModel = ProjectFactory.GetProjectModel();
            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectSteps.GetProjectId(project);

            //Act
            var response = await ProjectSteps.GetProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var responseProject = NewtonsoftJsonSerializer.Deserialize<ResponseProjectModel>(response);
            ProjectAssert.ValidateProjectResult(projectModel, responseProject);
        }

        [AllureXunitTheory(DisplayName =
            "GET index.php?/api/v2/get_project/{projectId} when projectId has incorrect value value returns 400")]
        [MemberData(nameof(ProjectMocks.IncorrectId), MemberType = typeof(ProjectMocks))]
        public async Task GetProject_WhenProjectIdMissingValue_ShouldReturnBadRequest(int id)
        {
            //Arrange
            SetAuthorization();

            //Act
            var response = await ProjectService.GetProject(id);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            
            var responseMessage = NewtonsoftJsonSerializer.Deserialize<Error>(response);
            ErrorAssert.ValidateErrorMessage(responseMessage, ErrorMessage.InvalidProjectId);
        }
    }
}