using System.Collections;
using System.Collections.Generic;
using Homework_3.Collections;

namespace Homework_3.JosephsTask
{
    public class CircularLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _count;

        public int Count => _count;

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            if (_head == null)
            {
                _head = node;
                _tail = node;
                _tail.Next = _head;
            }
            else
            {
                node.Next = _head;
                _tail.Next = node;
                _tail = node;
            }

            _count++;
        }

        public bool Remove(T data)
        {
            Node<T> current = _head;
            Node<T> previous = null;

            if (IsEmpty)
            {
                return false;
            }

            do
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current == _tail)
                            _tail = previous;
                    }
                    else
                    {
                        if (_count == 1)
                        {
                            _head = _tail = null;
                        }
                        else
                        {
                            _head = current.Next;
                            _tail.Next = current.Next;
                        }
                    }

                    _count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            } while (current != _head);

            return false;
        }

        private bool IsEmpty => _count == 0;

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            } while (current != _head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }
    }
}