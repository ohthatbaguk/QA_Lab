using System;
using System.Collections.Generic;
using Bogus;

namespace Homework2.BaseEntities
{
    public abstract class BaseUser
    {
        public object UserId { get; set; }
        public string FirstName { get; set; }
        public string FullName => FirstName + " " + Surname;
        public string Surname { get; set; }
        public string JobTitle { get; set; }
        public int JobSalary { get; set; }
        public string JobDescription { get; set; }
        
    }
}