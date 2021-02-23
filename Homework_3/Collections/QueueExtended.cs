using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework_3.Collections
{
    public class QueueExtended
    {
        public Queue<int> CreateQueue(int min, int max)
        {
            var queue = new Queue<int>();
            var random = new Random();
            var maxValue = max;
            var minValue = min;
            for (var i = 0; i < random.Next(); i++)
            {
                queue.Enqueue(random.Next(minValue, maxValue));
            }

            return queue;
        }

        public ArrayList CreateArrayFromQueue(Queue<int> queue)
        {
            var listOfNumbersFromQueue = new ArrayList();
            listOfNumbersFromQueue.AddRange(queue);
            return listOfNumbersFromQueue;
        }

        public int FindMaxIndexInQueue(Queue<int> queue)
        {
            var imax = 0;
            var list = CreateArrayFromQueue(queue);
            for (var i = 0; i < list.Count; i++)
            {
                if ((int) list[i] > (int) list[imax])
                    imax = i;
            }

            return imax;
        }

        public int FindMinIndexInQueue(Queue<int> queue)
        {
            var imin = 0;
            var list = CreateArrayFromQueue(queue);
            for (var i = 0; i < list.Count; i++)
            {
                if ((int) list[i] < (int) list[imin])
                    imin = i;
            }

            return imin;
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