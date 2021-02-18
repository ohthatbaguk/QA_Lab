using System;
using Homework2.BaseEntities;
using Homework2.Interface;

namespace Homework2.Models
{
    public class Employee : BaseUser, IDescriptionable
    {
        public Job Job { get; set; }
        public Company Company { get; set; }

        public void Description()
        {
            Console.WriteLine(
                $"Hello, I am {FullName}, {Job.Title} in {Company.Name}, {Company.Country}, {Company.City}, {Company.Street} and my salary {Job.Salary}");
        }
    }
}