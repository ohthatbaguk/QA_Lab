using Bogus;
using Homework2.Factories;

namespace Homework2.Models
{
    public class Job : JobFaker
    
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Salary { get; set; }
    }
    
    
}