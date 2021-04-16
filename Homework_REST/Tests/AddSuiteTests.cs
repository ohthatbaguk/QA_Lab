using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Base;
using Homework_REST.Factories;
using Homework_REST.Mock;
using Homework_REST.Models.SuiteModel;
using Homework_REST.ResponseResult;
using Homework_REST.Services;
using Xunit;
using Xunit.Abstractions;

namespace Homework_REST.Tests
{
    public class AddSuiteTests : BaseTest
    {
        public AddSuiteTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        private const int ProjectId = 651;

    
        [Fact(DisplayName = "POST index.php?/api/v2/add_suite/{project_id} when suite returns 200")]
        public async Task AddSuite_WhenSuite_ShouldReturnOK()
        {
            //Arrange
            await SetAuthorization();

            var suiteModel = AddSuiteFactory.GetSuiteModel();
            
            //Act
            var response = await ProjectService.AddSuite(ProjectId, suiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
        
        [Theory(DisplayName = "POST index.php?/api/v2/add_suite/{project_id} when required field missing returns 400")]
        [MemberData(nameof(Mocks.SuiteMissingValues), MemberType = typeof(Mocks))]
        public async Task AddSuite_WhenSuite_ShouldReturnBadRequest( RequestSuiteModel requestSuiteModel)
        {
            //Arrange
            await SetAuthorization();

            //Act
            var response = await ProjectService.AddSuite(ProjectId, requestSuiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact(DisplayName = "POST index.php?/api/v2/add_suite/{project_id} when unauthorized returns 401")]
        public async Task AddSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            await SetAuthorization();

            var suiteModel = AddSuiteFactory.GetSuiteModel();
            
            //Act
            var response = await ProjectService.AddSuite(ProjectId, suiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}