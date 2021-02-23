using System;
using System.Collections;
using System.Collections.Generic;
using Homework_3.Utils;

namespace Homework_3.Collections
{
    public class StackExtended
    {
        public Stack<int> CreateStack<T>()
        {
            var randomStack = new RandomUtils();
            var stack = randomStack.CreateRandomIntStack();
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