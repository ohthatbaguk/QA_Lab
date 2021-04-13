using System.Net.Http;
using FluentAssertions;
using Homework_REST.Models;
using Newtonsoft.Json;

namespace Homework_REST.Asserts
{
    public static class ProjectAssert
    {
        public static void ValidateProjectResult(
            RequestProjectModel projectModel,
            HttpResponseMessage responseMessage)
        {
            var response = responseMessage.Content.ReadAsStringAsync().Result;

            var project = JsonConvert.DeserializeObject<ResponseProjectModel>(response);

            project.Announcement.Should().Be(projectModel.Announcement);
            project.Name.Should().Be(projectModel.Name);
            project.Id.Should().NotBe(null);
            project.ShowAnnouncement.Should().Be(projectModel.ShowAnnouncement);
            project.Url.Should().NotBe(null);
        }
    }
}