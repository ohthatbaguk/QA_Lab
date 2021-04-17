using System.Net.Http;
using FluentAssertions;
using Homework_REST.Models.ProjectModel;
using Homework_REST.Utils;

namespace Homework_REST.Asserts
{
    public static class ProjectAssert
    {
        public static void ValidateProjectResult(
            RequestProjectModel projectModel,
            HttpResponseMessage responseMessage)
        {
            var project = NewtonsoftJsonSerializer.Deserialize<ResponseProjectModel>(responseMessage);

            project.Announcement.Should().Be(projectModel.Announcement);
            project.Name.Should().Be(projectModel.Name);
            project.Id.Should().NotBe(null);
            project.ShowAnnouncement.Should().Be(projectModel.ShowAnnouncement);
            project.Url.Should().Contain(Startup.AppSettings.Services.TestRailApp.AppUrl);
        }
    }
}