using System.Collections.Generic;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class MyQueueEnqueueCostly<T>
    {
        private readonly Stack<T> _inc;
        private readonly Stack<T> _out;

        public MyQueueEnqueueCostly()
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
            while (_inc.Count > 0)
            {
                _out.Push(_inc.Pop());
            }

            _inc.Push(item);
            while (_out.Count > 0)
            {
                _inc.Push(_out.Pop());
            }
        }


        public T Peek()
        {
            return _inc.Peek();
        }

        public T Dequeue()
        {
            return _inc.Pop();
        }
    }
}