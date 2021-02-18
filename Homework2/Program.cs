using System;
using System.Linq;
using Bogus;
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
            employees.First().Description();
            candidates.First().Description();

            Console.WriteLine();

            var empRep = new EmployeeReportGenerator();
            empRep.Report();

            Console.WriteLine();

            var canRep = new СandidateReportGenerator();
            canRep.Report();
        }
    }
}