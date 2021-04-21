using System.Net;
using System.Threading.Tasks;
using Allure.Xunit.Attributes;
using FluentAssertions;
using Homework_REST.Asserts;
using Homework_REST.Base;
using Homework_REST.Extensions;
using Homework_REST.Factories;
using Homework_REST.Mock.Project;
using Homework_REST.Steps;
using Xunit;
using Xunit.Abstractions;
using ErrorMessage = Homework_REST.Constants.Message.ErrorMessage;

namespace Homework_REST.Tests.Project
{
    public class DeleteProjectTests : BaseTest
    {
        public DeleteProjectTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [AllureXunit(DisplayName = "POST index.php?/api/v2/delete_project/{projectId} returns 200")]
        public async Task DeleteProject_WhenProject_ShouldReturnOK()
        {
            //Arrange
            SetAuthorization();

            var projectModel = ProjectFactory.GetProjectModel();
            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectSteps.GetProjectId(project);

            //Act
            var response = await ProjectService.DeleteProject(projectId);
            var getProject = await ProjectSteps.GetProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [AllureXunitTheory(DisplayName =
            "POST index.php?/api/v2/delete_project/{projectId} when projectId has an incorrect format returns 400")]
        [MemberData(nameof(ProjectMocks.IncorrectIdForProject), MemberType = typeof(ProjectMocks))]
        public async Task DeleteProject_WhenProjectIdHasIncorrectFormat_ShouldReturnBadRequest(int projectId)
        {
            //Arrange
            SetAuthorization();

            //Act
            var response = await ProjectService.DeleteProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var responseMessage = response.GetErrors();
            ErrorAssert.ValidateErrorMessage(responseMessage, ErrorMessage.IncorrectProjectId);
        }

        [AllureXunit(DisplayName = "POST index.php?/api/v2/delete_project/{projectId} when unauthorized returns 401")]
        public async Task DeleteProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            ClientExtended.ClearAuthorization();

            var projectModel = ProjectFactory.GetProjectModel();
            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectSteps.GetProjectId(project);

            //Act
            var response = await ProjectService.DeleteProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

            var errorMessage = response.GetErrors();
            ErrorAssert.ValidateErrorMessage(errorMessage, ErrorMessage.FailedAuthentication);
        }

        [AllureXunit(DisplayName =
            "POST index.php?/api/v2/delete_project/{projectId} when delete project has already been deleted returns 400 ")]
        public async Task DeleteProject_WhenDeleteProjectHasAlreadyBeenDeleted_ShouldReturnBadRequest()
        {
            //Arrange
            SetAuthorization();

            var projectModel = ProjectFactory.GetProjectModel();
            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectSteps.GetProjectId(project);
            await ProjectService.DeleteProject(projectId);

            //Act
            var response = await ProjectService.DeleteProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}