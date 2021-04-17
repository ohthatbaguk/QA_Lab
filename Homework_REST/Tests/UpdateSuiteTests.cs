using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Asserts;
using Homework_REST.Base;
using Homework_REST.Extensions;
using Homework_REST.Factories;
using Homework_REST.Mock;
using Homework_REST.Models.SuiteModel;
using Xunit;
using Xunit.Abstractions;

namespace Homework_REST.Tests
{
    public class UpdateSuiteTests : BaseTest
    {
        public UpdateSuiteTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact(DisplayName = "POST index.php?/api/v2/update_suite/{suiteId} when suite returns 200")]
        public async Task UpdateSuite_ShouldReturnOK()
        {
            //Arrange
            await SetAuthorization();
            
            var suiteModel = SuiteFactory.GetSuiteModel();
            var projectModel = ProjectFactory.GetProjectModel();
            
            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectService.GetProjectId(project);
            
            var suite = await ProjectService.AddSuite(projectId, suiteModel);
            var suiteId = ProjectService.GetSuiteId(suite);
            var updateSuiteModel = SuiteFactory.GetSuiteModel();

            //Act
            var response = await ProjectService.UpdateSuite(suiteId, updateSuiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            SuiteAssert.ValidateSuiteResult(response, updateSuiteModel);
        }
        
        [Fact(DisplayName = "POST index.php?/api/v2/update_suite/{suiteId} when unauthorized returns 401")]
        public async Task UpdateSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            await SetAuthorization();
            ClientExtended.ClearAuthorization();
            
            var suiteModel = SuiteFactory.GetSuiteModel();
            const int suiteId = 123;
            
            //Act
            var response = await ProjectService.UpdateSuite(suiteId, suiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Theory(DisplayName = 
            "POST index.php?/api/v2/update_suite/{suiteId} when suite Name has an incorrect format returns 400")]
        [MemberData(nameof(SuiteMocks.IncorrectSuiteId), MemberType = typeof(SuiteMocks))]
        public async Task UpdateSuite_WhenNameHasIncorrectFormat_ShouldReturnBadRequest(int suiteId)
        {
            //Arrange
            await SetAuthorization();

            var suiteModel = SuiteFactory.GetSuiteModel();
            
            //Act
            var response = await ProjectService.UpdateSuite(suiteId, suiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Theory(DisplayName = 
            "POST index.php?/api/v2/update_suite/{suiteId} when field more than max length returns 400")]
        [MemberData(nameof(SuiteMocks.MoreThanMaxLengthValues), MemberType = typeof(SuiteMocks))]
        public async Task UpdateSuite_WhenFieldMoreThanMaxLengthValue_ShouldReturnBadRequest(
            RequestSuiteModel requestSuiteModel)
        {
            //Arrange
            await SetAuthorization();
            
            var projectModel = ProjectFactory.GetProjectModel();
            var suiteModel = SuiteFactory.GetSuiteModel();
            
            var project = await ProjectService.AddProject(projectModel);
            var projectId = ProjectService.GetProjectId(project);
            
            var suite = await ProjectService.AddSuite(projectId, suiteModel);
            var suiteId = ProjectService.GetSuiteId(suite);

            //Act
            var response = await ProjectService.UpdateSuite(suiteId, requestSuiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}