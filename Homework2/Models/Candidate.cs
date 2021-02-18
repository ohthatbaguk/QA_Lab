using System;
using Homework2.BaseEntities;
using Homework2.Interface;

namespace Homework2.Models
{
    public class Candidate : BaseUser, IDescriptionable
    {
        public Job Job { get; set; }

        public void Description()
        {
            Console.WriteLine(
                $"Hello, I am {FullName}. I want to be a {Job.Title}, {Job.Description} with a salary from {Job.Salary}.");
        }
    }
}