using System;
using System.Collections.Generic;
using Homework_3.Collections;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            NewStack newStack = new NewStack();
            Stack<int> firstStack = newStack.CreateStack<int>();
            Stack<int> secondStack = newStack.CreateStack<int>();
            Stack<int> resultStack = newStack.FindEqualElementsInStacks(firstStack, secondStack);
            newStack.PrintElementsInStack(resultStack);
            
            Console.WriteLine();
            
            NewQueue newQueue = new NewQueue();
            var queue = newQueue.CreateQueue();
            Console.WriteLine("The index of max element: " + newQueue.FindMaxElementInQueue(queue));
            Console.WriteLine("The index of min element: " + newQueue.FindMinElementInQueue(queue));
            Console.WriteLine("Result of calculating: " + newQueue.CalculateAmount(queue));
        }
    }
}