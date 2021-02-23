using Bogus;
using Homework2.Models;

namespace Homework2.Factories
{
    public class CompanyFaker
    {
        public Faker<Company> GetCompany()
        {
            return new Faker<Company>()
                .RuleFor(u => u.Name, f => f.Company.CompanyName())
                .RuleFor(u => u.Country, f => f.Address.Country())
                .RuleFor(u => u.City, f => f.Address.City())
                .RuleFor(u => u.Street, f => f.Address.StreetName());
        }
    }
}