using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Extensions;
using Homework_REST.Factories;
using Homework_REST.Models;
using Homework_REST.ResponseResult;
using Homework_REST.Services;
using Xunit;
using Xunit.Abstractions;

namespace Homework_REST.Tests
{
    public class UpdateSuiteTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UpdateSuiteTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
   
        }
        
        [Fact(DisplayName = "POST index.php?/api/v2/update_suite/{suiteId} when suite returns 200")]
        public async Task UpdateSuite_WhenSuite_ShouldReturnOK()
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            const int suiteId = 410;

            var suiteModel = AddSuiteFactory.UpdateSuiteModel();
            
            //Act
            var response = await ProjectService.UpdateSuite(client, suiteId, suiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
        
        [Fact(DisplayName = "POST index.php?/api/v2/update_suite/{suiteId} when unauthorized returns 401")]
        public async Task UpdateSuite_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            var client = Extension.EmptyAuthorization();
            const int suiteId = 410;

            var suiteModel = AddSuiteFactory.UpdateSuiteModel();
            
            //Act
            var response = await ProjectService.UpdateSuite(client, suiteId, suiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
        
        [Fact(DisplayName = "POST index.php?/api/v2/update_suite/{suiteId} when suite Name has an incorrect format returns 400")]
        public async Task UpdateSuite_WhenNameHasIncorrectFormat_ShouldReturnBadRequest()
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            const string suiteId = "qwerty";

            var suiteModel = AddSuiteFactory.UpdateSuiteModel();
            
            //Act
            var response = await ProjectService.UpdateSuite(client, suiteId, suiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
        
        [Theory(DisplayName = 
            "POST index.php?/api/v2/update_suite/{suiteId} when field more than max length returns 400")]
        [MemberData(nameof(Mocks.MoreThanMaxLengthValues), MemberType = typeof(Mocks))]
        public async Task UpdateSuite_WhenFieldMoreThanMaxLengthValue_ShouldReturnBadRequest(
            RequestSuiteModel requestSuiteModel)
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            const int suiteId = 410;
            
            //Act
            var response = await ProjectService.UpdateSuite(client, suiteId, requestSuiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
    }
}