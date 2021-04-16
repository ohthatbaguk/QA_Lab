using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Base;
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
        
        private const int ProjectId = 625;
        
        [Fact(DisplayName = "GET index.php?/api/v2/get_project/{projectId} when unauthorized returns 401")]
        public async Task GetProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            await SetAuthorization();
            
            //Act
            var response = await ProjectService.GetProject(ProjectId);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact(DisplayName = "GET index.php?/api/v2/get_project/{projectId} returns 200")]
        public async Task GetProject_ShouldReturnOK()
        {
            //Arrange
            await SetAuthorization();

            //Act
            var response = await ProjectSteps.GetProject(ProjectId);

            //Assert
           response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact(DisplayName =
            "GET index.php?/api/v2/get_project/{projectId} when projectId has an incorrect value returns 400")]
        public async Task GetProject_WhenGetProject_ShouldReturnBadRequest()
        {
            //Arrange
            await SetAuthorization();
            const int id = 01;
            
            //Act
            var response = await ProjectService.GetProject(id);
          
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Theory(DisplayName = 
            "GET index.php?/api/v2/get_project/{projectId} when projectId missing value returns 400")]
        [MemberData(nameof(Mocks.IncorrectAndMissingValues), MemberType = typeof(Mocks))]
        public async Task GetProject_WhenProjectIdMissingValue_ShouldReturnBadRequest(int id)
        {
            //Arrange
            await SetAuthorization();
            
            //Act
            var response = await ProjectService.GetProject(id);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact(DisplayName = 
            "GET index.php?/api/v2/get_project/{projectId} when projectId has an incorrect format returns 400")]
        public async Task GetProject_WhenProjectIdHasIncorrectFormat_ShouldReturnBadRequest()
        {
            //Arrange
            await SetAuthorization();
            const string id = "qwerty";

            //Act
            var response = await ProjectService.GetProject(id);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}