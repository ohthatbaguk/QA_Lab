using Bogus;
using Homework_REST.Models;
using Homework_REST.Models.SuiteModel;
using Homework_REST.Utils;

namespace Homework_REST.Factories
{
    public class SuiteFactory
    {
        public static RequestSuiteModel GetSuiteModel()
        {
            return new RequestSuiteModel
            {
                Name = new Faker().Company.Random.Word(),
                Description = new Faker().Lorem.Sentence(3)
            };
        }
    }
}