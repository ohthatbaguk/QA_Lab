using Homework_REST.Models;
using Homework_REST.Models.SuiteModel;
using Homework_REST.Utils;
using Homework_REST.ValidationConstants;

namespace Homework_REST.Factories
{
    public class AddSuiteFactory
    {
        public static RequestSuiteModel GetSuiteModel()
        {
            return new RequestSuiteModel
            {
                Name = RandomUtils.GenerateString(Constants.RequestProjectModel.NotesMaxLength),
                Description = RandomUtils.GenerateString(Constants.RequestProjectModel.NotesMaxLength)
            };
        }
    }
}