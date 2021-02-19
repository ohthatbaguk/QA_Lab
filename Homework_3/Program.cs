using System;
using System.Collections.Generic;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers1 = new Stack<int>();
            Stack<int> numbers2 = new Stack<int>();
            Stack<int> numbers3 = new Stack<int>();

            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                numbers1.Push(random.Next(1, 20));
                numbers2.Push(random.Next(1, 20));
            }

            foreach (var n in numbers1)
            {
                Console.Write($"{n} ");
            }

            Console.WriteLine();

            foreach (var n in numbers2)
            {
                Console.Write($"{n} ");
            }

            while (numbers1.Count > 0 || numbers2.Count > 0)
            {
                if (numbers2.Count == 0 || numbers1.Count != 0)
                    numbers3.Push(numbers1.Pop());
                else
                {
                    numbers3.Push(numbers2.Pop());
                }
            }

            Console.WriteLine();

            foreach (var n in numbers3)
            {
                Console.Write($"{n} ");
            }
        }
    }
}