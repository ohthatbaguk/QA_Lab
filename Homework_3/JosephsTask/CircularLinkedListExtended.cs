using System;

namespace Homework_3.JosephsTask
{
    public class CircularLinkedListExtended
    {
        public CircularLinkedList<int> FillList(int numberOfHumans = 45)
        {
            CircularLinkedList<int> list = new CircularLinkedList<int>();
            var i = 1;
            while (i <= numberOfHumans)
            {
                list.Add(i);
                i++;
            }

            return list;
        }

        public int FindTheLastOfAlive(CircularLinkedList<int> listOfHumans, int step = 2)
        {
            int number = 0;
            for (int i = 1; i <= listOfHumans.Count; i++)
            {
                number = (number + step) % i;
            }

            return number + 1;
        }

        public void PrintList(CircularLinkedList<int> list)
        {
            foreach (var element in list)
            {
                Console.Write(element + " ");
            }
        }
    }
}