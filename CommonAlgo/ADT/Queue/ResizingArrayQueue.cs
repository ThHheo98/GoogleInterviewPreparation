using System;
using CommonAlgo.ADT.Interfaces;

namespace CommonAlgo.ADT.Queue
{
    public class ResizingArrayQueue<T> : IQueue<T> where T : IComparable
    {
        private T[] _array;
        private int _capacity;
        private int _count;
        private int _head;
        private int _tail;

        public ResizingArrayQueue()
        {
            _capacity = 2;
            _array = new T[_capacity];

            _count = 0;
            _head = -1;
            _tail = 0;
        }

        public T Dequeue()
        {
            if (IsEmpty()) throw new InvalidOperationException("Dequeue");

            T t = _array[++_head%_capacity];
            _count--;
            return t;
        }

        public void Enqueue(T item)
        {
            if (_count == _capacity) Resize(2*_array.Length);
            _array[_tail++%_capacity] = item;
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

        private void Resize(int capacity)
        {
            var tmp = new T[capacity];

            for (int j = 0; j < _array.Length; j++)
            {
                tmp[j] = _array[j];
            }
            _array = tmp;
            _capacity = capacity;
        }
    }
}