using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CommonAlgo.CrackingTheCodingInterview.Ch14_Java
{
    public class CircularArray<T> : IEnumerable<T>
    {
        private readonly T[] _items;
        private int _head;

        public CircularArray(int size)
        {
            _items = new T[size];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.Cast<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int Convert(int i)
        {
            if (i < 0)
            {
                i += _items.Length;
            }
            return (_head + i)%_items.Length;
        }

        public void Rotate(int shiftRight)
        {
            _head = Convert(shiftRight);
        }

        public T Get(int i)
        {
            if (i < 0 || i >= _items.Length)
            {
                throw new IndexOutOfRangeException("");
            }
            return _items[Convert(i)];
        }

        public void Set(int i, T item)
        {
            _items[Convert(i)] = item;
        }
    }
}