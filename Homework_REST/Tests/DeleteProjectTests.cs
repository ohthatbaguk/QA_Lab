using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Base;
using Xunit;
using Xunit.Abstractions;

namespace Homework_REST.Tests
{
    public class DeleteProjectTests : BaseTest
    {
        public DeleteProjectTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }
        
        private const int ProjectId = 764;
        
        [Fact(DisplayName = "POST index.php?/api/v2/delete_project/{projectId} returns 200")]
        public async Task DeleteProject_WhenDeleteProject_ShouldReturnOK()
        {
            //Arrange
            await SetAuthorization();

            //Act
            var response = await ProjectService.DeleteProject(ProjectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact(DisplayName = 
            "POST index.php?/api/v2/delete_project/{projectId} when projectId has an incorrect value returns 400")]
        public async Task DeleteProject_WhenProjectIdHasIncorrectValue_ShouldReturnBadRequest()
        {
            //Arrange
            await SetAuthorization();
            const int projectId = 0; 

            //Act
            var response = await ProjectService.DeleteProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact(DisplayName = 
            "POST index.php?/api/v2/delete_project/{projectId} when projectId has an incorrect format returns 400")]
        public async Task DeleteProject_WhenProjectIdHasIncorrectFormat_ShouldReturnBadRequest()
        {
            //Arrange
            await SetAuthorization();
            const string projectId = "qwerty";

            //Act
            var response = await ProjectService.DeleteProject(projectId);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}