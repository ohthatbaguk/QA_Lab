using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Homework2.BaseEntities;
using Homework2.Factories;
using Homework2.Report;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int minUserCount = 1;
            const int maxUserCount = 4;
            var factory = new UserFactory();
            var employees = factory.GetEmployees(new Faker().Random.Int(minUserCount, maxUserCount));
            var candidates = factory.GetCandidates(new Faker().Random.Int(minUserCount, maxUserCount));


            var empRep = new EmployeeReportGenerator();
            empRep.Report(new List<BaseUser>(employees));

            Console.WriteLine();

            var canRep = new СandidateReportGenerator();
            canRep.Report(new List<BaseUser>(candidates));

            Console.WriteLine();

            employees.First().Description();
            candidates.First().Description();
        }
    }
}