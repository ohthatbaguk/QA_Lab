using System.Collections;
using System.Collections.Generic;

namespace Homework_3.JosephsTask
{
    public class CircularLinkedList<T> : IEnumerable<T>
    {
        public Node<T> Head;
        public Node<T> Tail;
        int _count;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (Head == null)
            {
                Head = node;
                Tail = node;
                Tail.Next = Head;
            }
            else
            {
                node.Next = Head;
                Tail.Next = node;
                Tail = node;
            }

            _count++;
        }

        public bool Remove(T data)
        {
            Node<T> current = Head;
            Node<T> previous = null;

            if (IsEmpty) return false;

            do
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current == Tail)
                            Tail = previous;
                    }
                    else
                    {
                        if (_count == 1)
                        {
                            Head = Tail = null;
                        }
                        else
                        {
                            Head = current.Next;
                            Tail.Next = current.Next;
                        }
                    }

                    _count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            } while (current != Head);

            return false;
        }

        public int Count
        {
            get { return _count; }
        }

        public bool IsEmpty => _count == 0;

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = Head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            } while (current != Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }
    }
}