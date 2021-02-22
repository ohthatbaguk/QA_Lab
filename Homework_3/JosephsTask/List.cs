using System;

namespace Homework_3.JosephsTask
{
    public class List
    {
        private int numberOfHumans = 67;
        public CircularLinkedList<int> FillList()
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

        public int FindTheLastOfAlive(CircularLinkedList<int> listOfHumans)
        {
            int number = 0, step = 2;
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