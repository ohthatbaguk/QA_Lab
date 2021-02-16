using System;
using Homework2.BaseEntities;
using Homework2.Interface;

namespace Homework2.Models
{
    public class Candidate : BaseUser, IDescriptionable
    {
        public Candidate()
        {
        }

        public void Description()
        {
            Console.WriteLine($"Hello, I am {FullName} I want to be a {JobTitle}, {JobDescription} with a salary from {JobSalary}.");
        }
    }
}