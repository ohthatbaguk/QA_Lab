using Homework_REST.Models;
using Homework_REST.Models.ProjectModel;
using Homework_REST.Utils;
using Homework_REST.ValidationConstants;

namespace Homework_REST.Factories
{
    public static class AddProjectFactory
    {
        public static RequestProjectModel GetProjectModel()
        {
            return new RequestProjectModel
            {
                Name = "Project Nat",
                Announcement = RandomUtils.GenerateString(Constants.RequestProjectModel.NotesMaxLength),
                ShowAnnouncement = true
            };
        }
    }
}