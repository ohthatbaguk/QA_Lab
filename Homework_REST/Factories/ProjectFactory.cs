using Bogus;
using Homework_REST.Models.ProjectModel;

namespace Homework_REST.Factories
{
    public static class ProjectFactory
    {
        public static RequestProjectModel GetProjectModel()
        {
            return new RequestProjectModel
            {
                Name = new Faker().Company.Random.Word(),
                Announcement = new Faker().Lorem.Sentence(3),
                ShowAnnouncement = true
            };
        }
    }
}