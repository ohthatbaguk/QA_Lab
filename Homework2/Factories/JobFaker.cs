using Bogus;
using Homework2.Models;

namespace Homework2.Factories
{
    public class JobFaker
    {
        private const int MinSalary = 500;
        private const int MaxSalary = 800;

        public Faker<Job> GetJob()
        {
            return new Faker<Job>()
                .RuleFor(u => u.Title, f => f.Name.JobTitle())
                .RuleFor(u => u.Description, f => f.Name.JobDescriptor())
                .RuleFor(u => u.Salary, f => f.Random.Int(MinSalary, MaxSalary));
        }
    }
}