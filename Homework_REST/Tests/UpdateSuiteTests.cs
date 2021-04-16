using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Base;
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
        
        private const int SuiteId = 410;

        [Fact(DisplayName = "POST index.php?/api/v2/update_suite/{suiteId} when suite returns 200")]
        public async Task UpdateSuite_WhenSuite_ShouldReturnOK()
        {
            //Arrange
            await SetAuthorization();
            
            var suiteModel = AddSuiteFactory.GetSuiteModel();
            
            //Act
            var response = await ProjectService.UpdateSuite(SuiteId, suiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Fact(DisplayName = "POST index.php?/api/v2/update_suite/{suiteId} when unauthorized returns 401")]
        public async Task UpdateSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            await SetAuthorization();
            
            var suiteModel = AddSuiteFactory.GetSuiteModel();
            
            //Act
            var response = await ProjectService.UpdateSuite(SuiteId, suiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
        
        [Fact(DisplayName = "POST index.php?/api/v2/update_suite/{suiteId} when suite Name has an incorrect format returns 400")]
        public async Task UpdateSuite_WhenNameHasIncorrectFormat_ShouldReturnBadRequest()
        {
            //Arrange
            await SetAuthorization();
            const string suiteId = "qwerty";

            var suiteModel = AddSuiteFactory.GetSuiteModel();
            
            //Act
            var response = await ProjectService.UpdateSuite(suiteId, suiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Theory(DisplayName = 
            "POST index.php?/api/v2/update_suite/{suiteId} when field more than max length returns 400")]
        [MemberData(nameof(Mocks.MoreThanMaxLengthValues), MemberType = typeof(Mocks))]
        public async Task UpdateSuite_WhenFieldMoreThanMaxLengthValue_ShouldReturnBadRequest(
            RequestSuiteModel requestSuiteModel)
        {
            //Arrange
            await SetAuthorization();

            //Act
            var response = await ProjectService.UpdateSuite(SuiteId, requestSuiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}