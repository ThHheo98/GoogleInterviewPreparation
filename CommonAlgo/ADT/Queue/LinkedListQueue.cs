using System;
using CommonAlgo.ADT.Interfaces;

namespace CommonAlgo.ADT.Queue
{
    public class LinkedListQueue<T> : IQueue<T> where T : IComparable
    {
        private int _count;
        private Element _head;
        private Element _tail;

        public T Dequeue()
        {
            if (IsEmpty()) throw new InvalidOperationException("LinkedListQueue is empty!");
            Element t = _head;

            _head = _head.Next;
            t.Next = null;

            _count--;
            return t.Item;
        }

        public void Enqueue(T item)
        {
            var element = new Element {Item = item};
            if (IsEmpty())
            {
                _head = element;
                _tail = _head;
            }
            else
            {
                _tail.Next = element;
                _tail = _tail.Next;
            }
            _count++;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public int Count
        {
            get { return _count; }
        }

        private class Element
        {
            public T Item { get; set; }
            public Element Next { get; set; }
        }
    }
}