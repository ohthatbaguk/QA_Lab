using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework_3.Collections
{
    public class NewStack
    {
        public Stack<int> CreateStack<T>()
        {
            var stack = new Stack<int>();
            var random = new Random();
            const int maxValue = 10;
            const int minValue = 1;
            for (var i = 0; i < 10; i++)
            {
                stack.Push(random.Next(minValue,maxValue)); 
            }
            return stack;
        }

        public ArrayList CreateArrayWithDigits<T>(Stack<T> stack)
        {
            var digitsList = new ArrayList();
            digitsList.AddRange(stack);
            return digitsList;
        }

        public Stack<int> FindEqualElementsInStacks(Stack<int> firstStack, Stack<int> secondStack)
        {
            var firstList = CreateArrayWithDigits(firstStack);
            var secondList = CreateArrayWithDigits(secondStack);
            var resultStack = new Stack<int>();
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