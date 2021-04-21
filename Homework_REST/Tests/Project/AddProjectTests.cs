using System.Net;
using System.Threading.Tasks;
using Allure.Xunit.Attributes;
using FluentAssertions;
using Homework_REST.Asserts;
using Homework_REST.Base;
using Homework_REST.Extensions;
using Homework_REST.Factories;
using Homework_REST.Mock;
using Homework_REST.Mock.Project;
using Homework_REST.Models.Message;
using Homework_REST.Models.ProjectModel;
using Homework_REST.Utils;
using Xunit;
using Xunit.Abstractions;
using ErrorMessage = Homework_REST.Constants.Message.ErrorMessage;

namespace Homework_REST.Tests.Project
{
    public class AddProjectTests : BaseTest
    {
        public AddProjectTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [AllureXunit(DisplayName = "POST index.php?/api/v2/add_project returns 200")]
        public async Task AddProject_ShouldReturnOK()
        {
            //Arrange
            SetAuthorization();
            var projectModel = ProjectFactory.GetProjectModel().Generate();

            //Act
            var response = await ProjectService.AddProject(projectModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var responseProject = NewtonsoftJsonSerializer.Deserialize<ResponseProjectModel>(response);
            ProjectAssert.ValidateProjectResult(projectModel, responseProject);
        }

        [AllureXunitTheory(DisplayName =
            "POST index.php?/api/v2/add_project when required field has incorrect value returns 400")]
        [MemberData(nameof(ProjectMocks.IncorrectValues), MemberType = typeof(ProjectMocks))]
        public async Task AddProject_WhenRequiredFieldHasIncorrectData_ShouldReturnBadRequest(
            string serializedProject, string typeOfError)
        {
            //Arrange
            SetAuthorization();

            //Act
            var projectModel = NewtonsoftJsonSerializer.DefaultDeserialize<RequestProjectModel>(serializedProject);
            var response = await ProjectService.AddProject(projectModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var errorResponse = NewtonsoftJsonSerializer.Deserialize<Error>(response);
            ErrorAssert.ValidateErrorMessage(errorResponse, typeOfError);
        }

        [AllureXunit(DisplayName = "POST index.php?/api/v2/add_project when unauthorized returns 401")]
        public async Task AddProject_WhenUnauthorized_ShouldReturnUnauthorized()
        {
            //Arrange
            ClientExtended.ClearAuthorization();

            var projectModel = ProjectFactory.GetProjectModel().Generate();

            //Act
            var response = await ProjectService.AddProject(projectModel);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);

            var errorMessage = NewtonsoftJsonSerializer.Deserialize<Error>(response);
            ErrorAssert.ValidateErrorMessage(errorMessage, ErrorMessage.FailedAuthentication);
        }
    }
}