using FluentAssertions;
using Homework_REST.Models.ProjectModel;

namespace Homework_REST.Asserts
{
    public static class ProjectAssert
    {
        public static void ValidateProjectResult(
            RequestProjectModel requestProjectModel,
            ResponseProjectModel responseProjectModel)
        {
            responseProjectModel.Announcement.Should().Be(requestProjectModel.Announcement);
            responseProjectModel.Name.Should().Be(requestProjectModel.Name);
            responseProjectModel.Id.Should().NotBe(null);
            responseProjectModel.ShowAnnouncement.Should().Be(requestProjectModel.ShowAnnouncement);
            responseProjectModel.Url.Should().Contain(Startup.AppSettings.Services.TestRailApp.AppUrl);
        }
    }
}