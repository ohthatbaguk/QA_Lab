using System;
using System.Linq;
using Bogus;
using Homework2.Factories;
using Homework2.Models;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
           var factory = new UserFactory();
           var employees = factory.GetEmployees(new Faker().Random.Int(1, 4));
           var candidates = factory.GetCandidates(new Faker().Random.Int(1, 4));
           candidates.First().Description();
           employees.First().Description();

           




        }
    }
}