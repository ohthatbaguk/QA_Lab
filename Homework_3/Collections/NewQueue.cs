using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework_3.Collections
{
    public class NewQueue
    {
        public Queue<int> CreateQueue()
        {
            var queue = new Queue<int>();
            Random random = new Random();
            var MaxValue = 100;
            var MinValue = 1;
            for (var i = 0; i < 20; i++)
            {
                queue.Enqueue(random.Next(MinValue, MaxValue));
            }

            return queue;
        }

        public ArrayList CreateArrayFromQueue(Queue<int> queue)
        {
            var listOfNumbersFromQueue = new ArrayList();
            listOfNumbersFromQueue.AddRange(queue);
            return listOfNumbersFromQueue;
        }

        public int FindMaxElementInQueue(Queue<int> queue)
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

        public int FindMinElementInQueue(Queue<int> queue)
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
            var imin = FindMinElementInQueue(queue);
            var imax = FindMaxElementInQueue(queue);
            if (imin > imax)
            {
                var temp = imin;
                imin = imax;
                imax = temp;
            }

            for (var i = imin; i <= imax; i++)
            {
                result += (int) list[i];
            }

            return result;
        }   
    }
}