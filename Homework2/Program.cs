using System;

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid g = Guid.NewGuid();
            Console.WriteLine(g);
            Console.WriteLine(Guid.NewGuid());
        }
    }
}