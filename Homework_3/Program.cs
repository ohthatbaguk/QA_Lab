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
        }
    }
}