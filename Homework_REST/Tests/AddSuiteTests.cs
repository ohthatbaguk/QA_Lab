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
    public class AddSuiteTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AddSuiteTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
   
        }
        
        [Fact(DisplayName = "POST index.php?/api/v2/add_suite/{project_id} when suite returns 200")]
        public async Task AddSuite_WhenSuite_ShouldReturnOK()
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            const int projectId = 651;

            var suiteModel = AddSuiteFactory.GetSuiteModel();
            
            //Act
            var response = await ProjectService.AddSuite(client, projectId, suiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
        
        [Theory(DisplayName = "POST index.php?/api/v2/add_suite/{project_id} when required field missing returns 400")]
        [MemberData(nameof(Mocks.SuiteMissingValues), MemberType = typeof(Mocks))]
        public async Task AddSuite_WhenSuite_ShouldReturnBadRequest( RequestSuiteModel requestSuiteModel)
        {
            //Arrange
            var client = Extension.CreateHttpClient();
            const int projectId = 651;
            
            //Act
            var response = await ProjectService.AddSuite(client, projectId, requestSuiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
        
        [Fact(DisplayName = "POST index.php?/api/v2/add_suite/{project_id} when unauthorized returns 401")]
        public async Task AddSuite_WhenSuite_ShouldReturnUnauthorized()
        {
            //Arrange
            var client = Extension.EmptyAuthorization();
            const int projectId = 651;

            var suiteModel = AddSuiteFactory.GetSuiteModel();
            
            //Act
            var response = await ProjectService.AddSuite(client, projectId, suiteModel);
            
            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
            _testOutputHelper.WriteLine(ResultResponse.Result(response));
        }
    }
}