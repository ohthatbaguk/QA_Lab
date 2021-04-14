using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Base;
using Homework_REST.Mock;
using Homework_REST.ResponseResult;
using Homework_REST.Services;
using Homework_REST.Steps;
using Xunit;
using Xunit.Abstractions;

namespace Homework_REST.Tests
{
    public class GetProjectTests : BaseTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private const int ProjectId = 625;

        public GetProjectTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact(DisplayName = "GET index.php?/api/v2/get_project/{projectId} when unauthorized returns 401")]
        public async Task GetProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            var client = EmptyAuthorization();
            
            //Act
            var response = await ProjectService.GetProject(client, ProjectId);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
            
        }

        [Fact(DisplayName = "GET index.php?/api/v2/get_project/{projectId} returns 200")]
        public async Task GetProject_ShouldReturnOK()
        {
            //Arrange
            var client = CreateHttpClient();

            //Act
            var response = await ProjectSteps.GetProject(client, ProjectId);

            //Assert
           response.StatusCode.Should().Be(HttpStatusCode.OK);
           _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
        
        [Fact(DisplayName =
            "GET index.php?/api/v2/get_project/{projectId} when projectId has an incorrect value returns 400")]
        public async Task GetProject_WhenGetProject_ShouldReturnBadRequest()
        {
            //Arrange
            var client = CreateHttpClient();
            const int id = 01;
            
            //Act
            var response = await ProjectService.GetProject(client, id);
          
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
        
        [Theory(DisplayName = 
            "GET index.php?/api/v2/get_project/{projectId} when projectId missing value returns 400")]
        [MemberData(nameof(Mocks.IncorrectAndMissingValues), MemberType = typeof(Mocks))]
        public async Task GetProject_WhenProjectIdMissingValue_ShouldReturnBadRequest(int id)
        {
            //Arrange
            var client = CreateHttpClient();
            
            //Act
            var response = await ProjectService.GetProject(client, id);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
        
        [Fact(DisplayName = 
            "GET index.php?/api/v2/get_project/{projectId} when projectId has an incorrect format returns 400")]
        public async Task GetProject_WhenProjectIdHasIncorrectFormat_ShouldReturnBadRequest()
        {
            //Arrange
            var client = CreateHttpClient();
            const string id = "qwerty";

            //Act
            var response = await ProjectService.GetProject(client, id);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
    }
}