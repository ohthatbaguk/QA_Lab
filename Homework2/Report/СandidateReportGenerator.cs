using System;
using System.Linq;
using Bogus;
using Homework2.Factories;
using Homework2.Interface;

namespace Homework2.Report
{
    public class СandidateReportGenerator : IReportGenerator
    {
        public void Report()
        {
            const int minUserCount = 1;
            const int maxUserCount = 4;
            var factory = new UserFactory();
            var emp = factory.GetCandidates(new Faker().Random.Int(minUserCount, maxUserCount));
            var result = from user in emp
                orderby user.UserId, user.FullName, user.Job.Title, user.Job.Salary
                select user;
            Console.WriteLine("UserId || Company Name || Users Full Name || Salary");
            foreach (var user in result)
            {
                Console.WriteLine($"{user.UserId} || {user.FullName} ||{user.Job.Title} || {user.Job.Salary}");
            }
        }
    }
}