using Bogus;
using Homework_REST.Models.ProjectModel;

namespace Homework_REST.Factories
{
    public static class ProjectFactory
    {
        public static Faker<RequestProjectModel> GetProjectModel()
        {
            return new Faker<RequestProjectModel>()
                .RuleFor(p => p.Name, f => f.Lorem.Word())
                .RuleFor(p => p.Announcement, f => f.Lorem.Sentence(7))
                .RuleFor(p => p.ShowAnnouncement, f => f.Random.Bool());
        }
    }
}