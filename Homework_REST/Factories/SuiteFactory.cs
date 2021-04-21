using Bogus;
using Homework_REST.Models.SuiteModel;

namespace Homework_REST.Factories
{
    public class SuiteFactory
    {
        public static Faker<RequestSuiteModel> GetSuiteModel()
        {
            return new Faker<RequestSuiteModel>()
                .RuleFor(s => s.Name, f => f.Lorem.Word())
                .RuleFor(s => s.Description, f => f.Lorem.Sentence(7));
        }
    }
}