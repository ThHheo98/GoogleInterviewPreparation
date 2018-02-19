using System;
using CommonAlgo.ADT.Interfaces;

namespace CommonAlgo.ADT.Stacks
{
    public class LinkedListStack<T> : IStack<T> where T : IComparable
    {
        private Element _first;
        private int _itemCount;

        public LinkedListStack()
        {
            _itemCount = 0;
            _first = null;
        }

        public T Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
            T item = _first.Item;
            _first = _first.Next;
            _itemCount--;
            return item;
        }

        public void Push(T item)
        {
            Element old = _first;
            _first = new Element
            {
                Item = item,
                Next = old
            };
            _itemCount++;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
            return _first.Item;
        }

        public bool IsEmpty()
        {
            return _itemCount == 0;
        }

        public int ItemCount
        {
            get { return _itemCount; }
        }

        private class Element
        {
            public Element Next { get; set; }
            public T Item { get; set; }
        }
    }
}