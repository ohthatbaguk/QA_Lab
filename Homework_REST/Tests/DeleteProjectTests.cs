using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Extensions;
using Homework_REST.Services;
using Xunit;
using Xunit.Abstractions;

namespace Homework_REST.Tests
{
    public class DeleteProjectTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public DeleteProjectTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Fact(DisplayName = "POST index.php?/api/v2/delete_project/{projectId} returns 200")]
        public async Task DeleteProject_WhenDeleteProject_ShouldReturnOK()
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            const int projectId = 625;

            //Act
            var response = await ProjectService.DeleteProject(client, projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact(DisplayName = 
            "POST index.php?/api/v2/delete_project/{projectId} when projectId has an incorrect value returns 400")]
        public async Task DeleteProject_WhenProjectIdHasIncorrectValue_ShouldReturnBadRequest()
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            const int projectId = 0;

            //Act
            var response = await ProjectService.DeleteProject(client, projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact(DisplayName = 
            "POST index.php?/api/v2/delete_project/{projectId} when projectId has an incorrect format returns 400")]
        public async Task DeleteProject_WhenProjectIdHasIncorrectFormat_ShouldReturnBadRequest1()
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            const string projectId = "qwerty";

            //Act
            var response = await ProjectService.DeleteProject(client, projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}