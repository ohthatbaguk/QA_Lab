using System;
using Homework2.BaseEntities;
using Homework2.Interface;

namespace Homework2.Models
{
    public class Employee : BaseUser,IDescriptionable
    {
        
        public string CompanyName { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyStreet { get; set; }
        public Employee()
        {
        }

        public void Description()
        {
            Console.WriteLine($"Hello, I am {FullName}, {JobTitle} in {CompanyName},{CompanyCountry}, " +
                              $"{CompanyCity}, {CompanyStreet} and my salary {JobSalary}.");
        }
    }
}