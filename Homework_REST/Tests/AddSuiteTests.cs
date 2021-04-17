using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Base;
using Homework_REST.Extensions;
using Homework_REST.Factories;
using Homework_REST.Mock;
using Homework_REST.Models.SuiteModel;
using Xunit;
using Xunit.Abstractions;

namespace Homework_REST.Tests
{
    public class AddSuiteTests : BaseTest
    {
        public AddSuiteTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact(DisplayName = "POST index.php?/api/v2/add_suite/{project_id} when suite returns 200")]
        public async Task AddSuite_ShouldReturnOK()
        {
            //Arrange
            await SetAuthorization();

            var suiteModel = SuiteFactory.GetSuiteModel();
            var projectModel = ProjectFactory.GetProjectModel();
            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectService.GetProjectId(project);

            //Act
            var response = await ProjectService.AddSuite(projectId, suiteModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Theory(DisplayName = "POST index.php?/api/v2/add_suite/{project_id} when required field missing returns 400")]
        [MemberData(nameof(SuiteMocks.SuiteMissingValues), MemberType = typeof(SuiteMocks))]
        public async Task AddSuite_WhenSuite_ShouldReturnBadRequest(RequestSuiteModel suiteModel)
        {
            //Arrange
            await SetAuthorization();

            var projectModel = ProjectFactory.GetProjectModel();
            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectService.GetProjectId(project);

            //Act
            var response = await ProjectService.AddSuite(projectId, suiteModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact(DisplayName = "POST index.php?/api/v2/add_suite/{project_id} when unauthorized returns 401")]
        public async Task AddSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            await SetAuthorization();
            ClientExtended.ClearAuthorization();

            var suiteModel = SuiteFactory.GetSuiteModel();
            const int projectId = 123;

            //Act
            var response = await ProjectService.AddSuite(projectId, suiteModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Theory(DisplayName =
            "POST index.php?/api/v2/add_suite/{project_id} when field more than max length returns 400")]
        [MemberData(nameof(SuiteMocks.MoreThanMaxLengthValues), MemberType = typeof(SuiteMocks))]
        public async Task AddSuite_WhenFieldMoreThanMaxLengthValue_ShouldReturnBadRequest(
            RequestSuiteModel suiteModel)
        {
            //Arrange
            await SetAuthorization();

            var projectModel = ProjectFactory.GetProjectModel();

            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectService.GetProjectId(project);

            //Act
            var response = await ProjectService.AddSuite(projectId, suiteModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}