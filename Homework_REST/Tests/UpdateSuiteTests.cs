using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Homework_REST.Extensions;
using Homework_REST.Factories;
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
    }
}