using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Asserts;
using Homework_REST.Base;
using Homework_REST.Extensions;
using Homework_REST.Factories;
using Homework_REST.Mock;
using Xunit;
using Xunit.Abstractions;

namespace Homework_REST.Tests
{
    public class GetProjectTests : BaseTest
    {
        public GetProjectTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact(DisplayName = "GET index.php?/api/v2/get_project/{projectId} when unauthorized returns 401")]
        public async Task GetProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            await SetAuthorization();
            ClientExtended.ClearAuthorization();

            const int projectId = 123;

            //Act
            var response = await ProjectService.GetProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact(DisplayName = "GET index.php?/api/v2/get_project/{projectId} returns 200")]
        public async Task GetProject_ShouldReturnOK()
        {
            //Arrange
            await SetAuthorization();

            var projectModel = ProjectFactory.GetProjectModel();
            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectService.GetProjectId(project);

            //Act
            var response = await ProjectSteps.GetProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            ProjectAssert.ValidateProjectResult(projectModel, response);
        }

        [Theory(DisplayName =
            "GET index.php?/api/v2/get_project/{projectId} when projectId has incorrect value value returns 400")]
        [MemberData(nameof(ProjectMocks.IncorrectProjectId), MemberType = typeof(ProjectMocks))]
        public async Task GetProject_WhenProjectIdMissingValue_ShouldReturnBadRequest(int id)
        {
            //Arrange
            await SetAuthorization();

            //Act
            var response = await ProjectService.GetProject(id);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}