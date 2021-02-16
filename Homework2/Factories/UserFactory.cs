using System;
using System.Collections.Generic;
using Bogus;
using Homework2.BaseEntities;
using Homework2.Interface;
using Homework2.Models;

namespace Homework2.Factories
{
    public class UserFactory 
    {
        public List<Candidate> GetCandidates(int userCount = 1)
        {
            return new Faker<Candidate>()
                .RuleFor(u => u.UserId, f => Guid.NewGuid())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.Surname, f => f.Name.LastName())
                .RuleFor(u => u.JobDescription, f => "It is a set of quality assurance processes")
                .RuleFor(u => u.JobTitle, f => "AQA")
                .RuleFor(u => u.JobSalary, f => f.Random.Int(300,500)).Generate(userCount);
        }
        
        public List<Employee> GetEmployees(int userCount = 1)
        {
            return new Faker<Employee>()
                .RuleFor(u => u.UserId, f => Guid.NewGuid())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.Surname, f => f.Name.LastName())
                .RuleFor(u => u.JobDescription, f => "It is a set of quality assurance processes")
                .RuleFor(u => u.JobTitle, f => "QA")
                .RuleFor(u => u.CompanyName, f => f.Company.CompanyName())
                .RuleFor(u => u.CompanyCountry, f => f.Address.Country())
                .RuleFor(u => u.CompanyCity, f => f.Address.City())
                .RuleFor(u => u.CompanyCity, f => f.Address.StreetName())
                .RuleFor(u => u.JobSalary, f => f.Random.Int(500, 1000)).Generate(userCount);

        }
    }
}