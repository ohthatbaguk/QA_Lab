using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework_3.Collections
{
    public class StackExtended
    {
        public Stack<int> CreateStack<T>(int min, int max)
        {
            var stack = new Stack<int>();
            var random = new Random();
            var maxValue = max;
            var minValue = min;
            for (var i = 0; i < random.Next(); i++)
            {
                stack.Push(random.Next(minValue, maxValue));
            }

            return stack;
        }

        private ArrayList CreateArrayWithDigits<T>(Stack<T> stack)
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