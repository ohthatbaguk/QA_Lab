using System;
using System.Linq;
using Bogus;
using Homework2.Factories;
using Homework2.Interface;

namespace Homework2.Report
{
    public class EmployeeReportGenerator : IReportGenerator
    {
        public void Report()
        {
            const int minUserCount = 1;
            const int maxUserCount = 4;
            var factory = new UserFactory();
            var emp = factory.GetEmployees(new Faker().Random.Int(minUserCount, maxUserCount));
            var result = emp.OrderBy(u => u.UserId)
                .ThenByDescending(u => u.Company.Name)
                .ThenByDescending(u => u.Job.Salary);
            Console.WriteLine("UserId || Company Name || Users Full Name || Salary");
            foreach (var user in result)
            {
                Console.WriteLine($"{user.UserId} || {user.Company.Name} || {user.FullName} || {user.Job.Salary}");
            }
        }
    }
}