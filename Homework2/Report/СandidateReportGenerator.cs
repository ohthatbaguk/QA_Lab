using System;
using System.Collections.Generic;
using System.Linq;
using Homework2.BaseEntities;
using Homework2.Interface;
using Homework2.Models;

namespace Homework2.Report
{
    public class СandidateReportGenerator : IReportGenerator
    {
        public void Report(List<BaseUser> candidates)
        {
            var createCand = candidates.OfType<Candidate>();
            var sortCand = createCand.OrderBy(c => c.UserId)
                .ThenBy(c => c.FullName)
                .ThenBy(c => c.Job.Title)
                .ThenBy(c => c.Job.Salary);
            Console.WriteLine("UserId || Company Name || Users Full Name || Salary");
            foreach (var user in sortCand)
            {
                Console.WriteLine($"{user.UserId} || {user.FullName} ||{user.Job.Title} || {user.Job.Salary}");
            }
        }
    }
}