using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Extensions;
using Homework_REST.ResponseResult;
using Homework_REST.Services;
using Homework_REST.Steps;
using Xunit;
using Xunit.Abstractions;

namespace Homework_REST.Tests
{
    public class GetProjectTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public GetProjectTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact(DisplayName = "GET index.php?/api/v2/get_project/{projectId} when unauthorized returns 401")]
        public async Task GetProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange

            var client = Extension.EmptyAuthorization();
            const int projectId = 625;
            
            //Act
            var response = await ProjectService.GetProject(client, projectId);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
            
        }

        [Fact(DisplayName = "GET index.php?/api/v2/get_project/{projectId} returns 200")]
        public async Task GetProject_ShouldReturnOK()
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            const int projectId = 625;
            
            //Act
            var response = await ProjectSteps.GetProject(client, projectId);

            //Assert
           response.StatusCode.Should().Be(HttpStatusCode.OK);
           _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
        
        [Fact(DisplayName = "GET index.php?/api/v2/get_project/{projectId} when projectId has an incorrect value")]
        public async Task GetProject_WhenGetProject_ShouldReturnBadRequest()
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            const int projectId = 01;
            
            //Act
            var response = await ProjectService.GetProject(client, projectId);
          
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
        
        [Fact(DisplayName = 
            "GET index.php?/api/v2/get_project/{projectId} when projectId has an incorrect format returns 400")]
        public async Task GetProject_WhenProjectIdHasIncorrectFormat_ShouldReturnBadRequest1()
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            const string projectId = "qwerty";

            //Act
            var response = await ProjectService.GetProject(client, projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
        
        [Fact(DisplayName = 
            "GET index.php?/api/v2/get_project/{projectId} when projectId missing value returns 400")]
        public async Task GetProject_WhenProjectIMissingValue_ShouldReturnBadRequest1()
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            const string projectId = null;

            //Act
            var response = await ProjectService.GetProject(client, projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
        
    }
}