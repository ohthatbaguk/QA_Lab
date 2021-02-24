using System;
using System.Collections.Generic;

namespace Homework_3.Utils
{
    public class RandomUtils
    {
        readonly Random _random = new Random();

        public Queue<int> CreateRandomIntQueue(int elementsCount = 10)
        {
            var queue = new Queue<int>();
            const int maxValue = int.MaxValue;
            const int minValue = int.MinValue;
            for (var i = 0; i < elementsCount; i++)
            {
                queue.Enqueue(_random.Next(minValue, maxValue));
            }

            return queue;
        }   
        public Stack<int> CreateRandomIntStack(int elementsCount = 10)
        {
            var stack = new Stack<int>();
            const int maxValue = int.MaxValue;
            const int minValue = int.MinValue;
            for (var i = 0; i < elementsCount; i++)
            {
                stack.Push(_random.Next(minValue, maxValue));
            }

            return stack;
        }
    }
}