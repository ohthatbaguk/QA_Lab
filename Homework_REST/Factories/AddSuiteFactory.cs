using Homework_REST.Models;

namespace Homework_REST.Factories
{
    public class AddSuiteFactory
    {
        public static RequestSuiteModel GetSuiteModel()
        {
            return new RequestSuiteModel
            {
                Name = "Suite Nat",
                Description = "La la la"
            };
        }

        public static RequestSuiteModel UpdateSuiteModel()
        {
            return new RequestSuiteModel
            {
                Name = "Update Suite",
                Description = "Ho ho ho"
            };
        }
    }
}