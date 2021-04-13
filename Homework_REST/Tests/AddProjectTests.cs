using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Asserts;
using Homework_REST.Extensions;
using Homework_REST.Factories;
using Homework_REST.Models;
using Homework_REST.ResponseResult;
using Homework_REST.Services;
using Homework_REST.Steps;
using Xunit;
using Xunit.Abstractions;

namespace Homework_REST.Tests
{
    public class AddProjectTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AddProjectTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
   
        }

        [Fact(DisplayName = "POST index.php?/api/v2/add_project when returns 200")]
        public async Task AddProject_WhenAddProject_ShouldReturnOK()
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            var projectModel = AddProjectFactory.GetProjectModel();
            
            //Act
            var response = await ProjectService.AddProject(client, projectModel);
            var projectId = ProjectService.GetProjectId(response);
            var project = await ProjectSteps.GetProject(client, projectId);
            
            _testOutputHelper.WriteLine(ResultResponse.Result(project));
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            ProjectAssert.ValidateProjectResult(projectModel,project);
        }

        [Theory(DisplayName = "POST index.php?/api/v2/add_project when required field missing returns 400")]
        [MemberData(nameof(Mocks.ProjectMissingValues), MemberType = typeof(Mocks))]
        public async Task AddProject_WhenRequiredFieldMissing_ShouldReturnBadRequest(
            RequestProjectModel requestProjectModel)
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            
            //Act
            var response = await ProjectService.AddProject(client, requestProjectModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
            
        }
        
        [Fact(DisplayName = "POST index.php?/api/v2/add_project when unauthorized returns 401")]
        public async Task AddProject_WhenAddProject_ShouldReturnUnauthorized()
        {
            //Arrange
            var client = Extension.EmptyAuthorization();
            var projectModel = AddProjectFactory.GetProjectModel();
            
            //Act
            var response = await ProjectService.AddProject(client, projectModel);

            _testOutputHelper.WriteLine(ResultResponse.Result(response));
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            
        }
    }
}