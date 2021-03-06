﻿using System;
using System.Collections.Generic;
using Bogus;
using Homework2.Models;

namespace Homework2.Factories
{
    public class UserFactory
    {
        public List<Candidate> GetCandidates(int userCount = 1)
        {
            return new Faker<Candidate>()
                .RuleFor(u => u.UserId, f => Guid.NewGuid())
                .RuleFor(u => u.FullName, f => f.Name.FullName())
                .RuleFor(u => u.Job, f => new JobFaker().GetJob().Generate())
                .Generate(userCount);
        }

        public List<Employee> GetEmployees(int userCount = 1)
        {
            return new Faker<Employee>()
                .RuleFor(u => u.UserId, f => Guid.NewGuid())
                .RuleFor(u => u.FullName, f => f.Name.FullName())
                .RuleFor(u => u.Company, f => new CompanyFaker().GetCompany())
                .RuleFor(u => u.Job, f => new JobFaker().GetJob().Generate())
                .Generate(userCount);
        }
    }
}