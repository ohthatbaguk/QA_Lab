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
            var newStack = new StackExtended();
            var firstStack = newStack.CreateStack<int>(-67,45);
            var secondStack = newStack.CreateStack<int>(-74,89);
            var resultStack = newStack.FindEqualElementsInStacks(firstStack, secondStack);
            newStack.PrintElementsInStack(resultStack);

            Console.WriteLine();
            //Task2
            var newQueue = new QueueExtended();
            var queue = newQueue.CreateQueue(-15,45);
            Console.WriteLine("The index of max element: " + newQueue.FindMaxIndexInQueue(queue));
            Console.WriteLine("The index of min element: " + newQueue.FindMinIndexInQueue(queue));
            Console.WriteLine("Result of calculating: " + newQueue.CalculateAmount(queue));

            Console.WriteLine();
            //Task3
            CircularLinkedListExtended list = new CircularLinkedListExtended();
            var linkedList = list.FillList(45);
            Console.Write("Init state of list: ");
            list.PrintList(linkedList);
            Console.WriteLine("\nThe last of us: " + list.FindTheLastOfAlive(linkedList,2));

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