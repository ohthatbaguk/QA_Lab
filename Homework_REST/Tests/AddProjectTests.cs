using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Asserts;
using Homework_REST.Base;
using Homework_REST.Extensions;
using Homework_REST.Factories;
using Homework_REST.Mock;
using Homework_REST.Models.ProjectModel;
using Xunit;
using Xunit.Abstractions;

namespace Homework_REST.Tests
{
    public class AddProjectTests : BaseTest
    {
        public AddProjectTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact(DisplayName = "POST index.php?/api/v2/add_project when returns 200")]
        public async Task AddProject_ShouldReturnOK()
        {
            //Arrange
            await SetAuthorization();
            var projectModel = ProjectFactory.GetProjectModel();

            //Act
            var response = await ProjectService.AddProject(projectModel);
            var projectId = ProjectService.GetProjectId(response);
            var project = await ProjectSteps.GetProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            ProjectAssert.ValidateProjectResult(projectModel, project);
        }

        [Theory(DisplayName = "POST index.php?/api/v2/add_project when required field missing returns 400")]
        [MemberData(nameof(ProjectMocks.ProjectMissingValues), MemberType = typeof(ProjectMocks))]
        [MemberData(nameof(ProjectMocks.ProjectIncorrectValues), MemberType = typeof(ProjectMocks))]
        public async Task AddProject_WhenRequiredFieldHasIncorretData_ShouldReturnBadRequest(
            RequestProjectModel requestProjectModel)
        {
            //Arrange
            await SetAuthorization();

            //Act
            var response = await ProjectService.AddProject(requestProjectModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact(DisplayName = "POST index.php?/api/v2/add_project when unauthorized returns 401")]
        public async Task AddProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            await SetAuthorization();
            ClientExtended.ClearAuthorization();

            var projectModel = ProjectFactory.GetProjectModel();

            //Act
            var response = await ProjectService.AddProject(projectModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}