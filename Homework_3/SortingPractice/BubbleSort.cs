using System;
using System.Collections;

namespace Homework_3.SortingPractice
{
    public class BubbleSort
    {
        public ArrayList FillArray()
        {
            var list = new ArrayList();
            var random = new Random();
            const int maxValue = 10;
            const int minValue = 1;
            for (var i = 0; i < 25; i++)
            {
                list.Add(random.Next(minValue, maxValue));
            }

            return list;
        }

        public void DoBubbleSort(ArrayList array)
        {
            for (var i = 0; i < array.Count; i++)
            {
                for (var j = 0; j < (array.Count - i - 1); j++)
                {
                    if ((int) array[j] > (int) array[j + 1])
                    {
                        var temp = (int) array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public void DoQuickSort(ArrayList array, int l, int r)
        {
            int left = l, right = r, middle = (int) array[(left + right) / 2];

            while (left <= right)
            {
                while ((int) array[left] < middle)
                {
                    left++;
                }

                while ((int) array[right] > middle)
                {
                    right--;
                }

                if (left <= right)
                {
                    var temp = (int) array[left];
                    array[left] = (int) array[right];
                    array[right] = temp;

                    left++;
                    right--;
                }
            }

            if (l < right)
                DoQuickSort(array, l, right);
            if (r > left)
                DoQuickSort(array, left, r);
        }

        public void PrintElementsInArray(ArrayList array)
        {
            foreach (var element in array)
            {
                Console.Write(element + " ");
            }
        }
    }
}