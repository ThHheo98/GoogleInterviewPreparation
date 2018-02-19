using System;
using System.Diagnostics;
using CommonAlgo.ADT.Interfaces;

namespace CommonAlgo.ADT.Stacks
{
    public class ResizingArrayStack<T> : IStack<T> where T : IComparable
    {
        private int _current;
        private T[] _items;

        public ResizingArrayStack()
        {
            _items = new T[2];
            _current = -1;
        }

        #region Implementation of IStack<T>

        public T Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty");

            T foo = _items[_current];
            _current--;
            if (_current > 0 && _current == _items.Length/4) Resize(_items.Length/2);
            return foo;
        }

        public void Push(T item)
        {
            if (_current == _items.Length - 1) Resize(2*_items.Length);

            _items[_current + 1] = item;
            _current++;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
            return _items[_current];
        }

        public bool IsEmpty()
        {
            return _current == -1;
        }

        public int ItemCount
        {
            get { return _current + 1; }
        }

        private void Resize(int capacity)
        {
            if (capacity < _current + 1)
            {
                Debug.WriteLine("Capacity cannot be less than array size!");
            }
            var tmp = new T[capacity];
            for (int i = 0; i < _current + 1; i++)
            {
                tmp[i] = _items[i];
            }
            _items = tmp;
        }

        #endregion
    }
}