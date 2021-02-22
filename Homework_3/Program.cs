using System;
using Homework_3.Collections;
using Homework_3.JosephsTask;
using Homework_3.SortingPractice;

namespace Homework_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1
            var newStack = new NewStack();
            var firstStack = newStack.CreateStack<int>();
            var secondStack = newStack.CreateStack<int>();
            var resultStack = newStack.FindEqualElementsInStacks(firstStack, secondStack);
            newStack.PrintElementsInStack(resultStack);

            Console.WriteLine();
            //Task2
            var newQueue = new NewQueue();
            var queue = newQueue.CreateQueue();
            Console.WriteLine("The index of max element: " + newQueue.FindMaxElementInQueue(queue));
            Console.WriteLine("The index of min element: " + newQueue.FindMinElementInQueue(queue));
            Console.WriteLine("Result of calculating: " + newQueue.CalculateAmount(queue));

            Console.WriteLine();
            //Task3
            List list = new List();
            var linkedList = list.FillList();
            Console.Write("Init state of list: ");
            list.PrintList(linkedList);
            Console.WriteLine("\nThe last of us: " + list.FindTheLastOfAlive(linkedList));

            Console.WriteLine();
            //Task4
            var bubbleSort = new BubbleSort();
            var array = bubbleSort.FillArray();
            Console.Write("Initial array state: ");
            bubbleSort.PrintElementsInArray(array);

            Console.WriteLine();

            bubbleSort.DoBubbleSort(array);
            Console.Write("After sorting array state: ");
            bubbleSort.PrintElementsInArray(array);

            Console.WriteLine();

            var array1 = bubbleSort.FillArray();
            Console.Write("Initial array state: ");
            bubbleSort.PrintElementsInArray(array1);

            Console.WriteLine();

            bubbleSort.DoQuickSort(array1, 0, (array.Count - 1));
            Console.Write("After sorting array state: ");
            bubbleSort.PrintElementsInArray(array1);
        }
    }
}