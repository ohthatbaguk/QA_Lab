using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Asserts;
using Homework_REST.Base;
using Homework_REST.Factories;
using Homework_REST.Mock;
using Xunit;
using Xunit.Abstractions;

namespace Homework_REST.Tests
{
    public class DeleteProjectTests : BaseTest
    {
        public DeleteProjectTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact(DisplayName = "POST index.php?/api/v2/delete_project/{projectId} returns 200")]
        public async Task DeleteProject_WhenProject_ShouldReturnOK()
        {
            //Arrange
            await SetAuthorization();

            var projectModel = ProjectFactory.GetProjectModel();
            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectService.GetProjectId(project);

            //Act
            var response = await ProjectService.DeleteProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            ProjectAssert.ValidateProjectResult(projectModel, project);
        }

        [Theory(DisplayName =
            "POST index.php?/api/v2/delete_project/{projectId} when projectId has an incorrect format returns 400")]
        [MemberData(nameof(ProjectMocks.IncorrectProjectId), MemberType = typeof(ProjectMocks))]
        public async Task DeleteProject_WhenProjectIdHasIncorrectFormat_ShouldReturnBadRequest(int projectId)
        {
            //Arrange
            await SetAuthorization();

            //Act
            var response = await ProjectService.DeleteProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact(DisplayName = "POST index.php?/api/v2/delete_project/{projectId} when unauthorized returns 401")]
        public async Task DeleteProject_WhenUnauthorized_ShouldReturnOK()
        {
            //Arrange
            await SetAuthorization();

            var projectModel = ProjectFactory.GetProjectModel();
            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectService.GetProjectId(project);

            //Act
            var response = await ProjectService.DeleteProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            ProjectAssert.ValidateProjectResult(projectModel, project);
        }
    }
}