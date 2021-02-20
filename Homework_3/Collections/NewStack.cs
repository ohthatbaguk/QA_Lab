using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework_3.Collections
{
    public class NewStack
    {
        public Stack<int> CreateStack<T>()
        {
            Stack<int> stack = new Stack<int>();
            Random random = new Random();
            int MaxValue = 10;
            int MinValue = 1;
            for (int i = 0; i < 10; i++)
            {
                stack.Push(random.Next(MinValue,MaxValue)); 
            }
            return stack;
        }

        public ArrayList CreateArrayWithDigits<T>(Stack<T> stack)
        {
            ArrayList digitsList = new ArrayList();
            digitsList.AddRange(stack);
            return digitsList;
        }

        public Stack<int> FindEqualElementsInStacks(Stack<int> firstStack, Stack<int> secondStack)
        {
            ArrayList firstList = CreateArrayWithDigits(firstStack);
            ArrayList secondList = CreateArrayWithDigits(secondStack);
            Stack<int> resultStack = new Stack<int>();
            foreach (var digit in firstList)
            {
                if (secondList.Contains(digit))
                {
                    resultStack.Push((int) digit);
                }
            }

            return resultStack;
        }

        public void PrintElementsInStack<T>(Stack<T> stack)
        {
            foreach (var element in stack)
            {
                Console.Write(element + " ");
            }
        }
    }
}