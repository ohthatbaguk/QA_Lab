using System;
using System.Collections;
using System.Collections.Generic;
using Homework_3.Utils;

namespace Homework_3.Collections
{
    public class QueueExtended
    {
        public Queue<int> CreateQueue()
        {
            var randomQueue = new RandomUtils();
            var queue = randomQueue.CreateRandomIntQueue();
            return queue;
        }

        private ArrayList CreateArrayFromQueue(Queue<int> queue)
        {
            var listOfNumbersFromQueue = new ArrayList();
            listOfNumbersFromQueue.AddRange(queue);
            return listOfNumbersFromQueue;
        }

        public int FindMaxIndexInQueue(Queue<int> queue)
        {
            var indexMax = 0;
            var list = CreateArrayFromQueue(queue);
            for (var i = 0; i < list.Count; i++)
            {
                if ((int) list[i] > (int) list[indexMax])
                    indexMax = i;
            }

            return indexMax;
        }

        public int FindMinIndexInQueue(Queue<int> queue)
        {
            var indexMin = 0;
            var list = CreateArrayFromQueue(queue);
            for (var i = 0; i < list.Count; i++)
            {
                if ((int) list[i] < (int) list[indexMin])
                    indexMin = i;
            }

            return indexMin;
        }

        public int CalculateAmount(Queue<int> queue)
        {
            ArrayList list = CreateArrayFromQueue(queue);
            var result = 0;
            var indexOfMinElement = FindMinIndexInQueue(queue);
            var indexOfMaxElement = FindMaxIndexInQueue(queue);
            if (indexOfMinElement > indexOfMaxElement)
            {
                var temp = indexOfMinElement;
                indexOfMinElement = indexOfMaxElement;
                indexOfMaxElement = temp;
            }

            for (var i = indexOfMinElement; i <= indexOfMaxElement; i++)
            {
                result += (int) list[i];
            }

            return result;
        }
    }
}