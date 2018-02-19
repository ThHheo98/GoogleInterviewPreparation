using System.Collections.Generic;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class MyQueueDequeueCostly<T>
    {
        private readonly Stack<T> _inc;
        private readonly Stack<T> _out;

        public MyQueueDequeueCostly()
        {
            _inc = new Stack<T>();
            _out = new Stack<T>();
        }

        public int Count
        {
            get { return _inc.Count + _out.Count; }
        }

        public void Enqueue(T item)
        {
            _inc.Push(item);
        }

        public T Dequeue()
        {
            Shift();
            return _out.Pop();
        }

        public T Peek()
        {
            Shift();
            return _out.Peek();
        }

        private void Shift()
        {
            if (_out.Count == 0)
            {
                while (_inc.Count > 0)
                {
                    _out.Push(_inc.Pop());
                }
            }
        }
    }
}