using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Base;
using Homework_REST.ResponseResult;
using Homework_REST.Services;
using Xunit;
using Xunit.Abstractions;

namespace Homework_REST.Tests
{
    public class DeleteProjectTests : BaseTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private const int ProjectId = 764;
        public DeleteProjectTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact(DisplayName = "POST index.php?/api/v2/delete_project/{projectId} returns 200")]
        public async Task DeleteProject_WhenDeleteProject_ShouldReturnOK()
        {
            //Arrange
            var client = CreateHttpClient();

            //Act
            var response = await ProjectService.DeleteProject(client, ProjectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact(DisplayName = 
            "POST index.php?/api/v2/delete_project/{projectId} when projectId has an incorrect value returns 400")]
        public async Task DeleteProject_WhenProjectIdHasIncorrectValue_ShouldReturnBadRequest()
        {
            //Arrange
            var client = CreateHttpClient();
            const int projectId = 0; 

            //Act
            var response = await ProjectService.DeleteProject(client, projectId);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact(DisplayName = 
            "POST index.php?/api/v2/delete_project/{projectId} when projectId has an incorrect format returns 400")]
        public async Task DeleteProject_WhenProjectIdHasIncorrectFormat_ShouldReturnBadRequest()
        {
            //Arrange
            var client = CreateHttpClient();
            const string projectId = "qwerty";

            //Act
            var response = await ProjectService.DeleteProject(client, projectId);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}