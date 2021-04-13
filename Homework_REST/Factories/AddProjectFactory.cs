using Homework_REST.Models;

namespace Homework_REST.Factories
{
    public class AddProjectFactory
    {
        public static RequestProjectModel GetProjectModel()
        {
            return new RequestProjectModel
            {
                Name = "Project Nat",
                Announcement = "Bla bla bla",
                ShowAnnouncement = true,
            };
        }
    }
}