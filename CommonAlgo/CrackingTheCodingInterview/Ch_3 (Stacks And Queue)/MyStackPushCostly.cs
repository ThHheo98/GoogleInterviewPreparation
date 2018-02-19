using System.Collections.Generic;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class MyStackPushCostly<T>
    {
        /* Method 1 (By making push operation costly)
         * This method makes sure that newly entered element is 
         * always at the front of ‘q1′, 
         * so that pop operation just dequeues from ‘q1′. 
         * ‘q2′ is used to put every new element at front of ‘q1′.

        push(s, x) // x is the element to be pushed and s is stack
            1) Enqueue x to q2
            2) One by one dequeue everything from q1 and enqueue to q2.
            3) Swap the names of q1 and q2         
         * Swapping of names is done to avoid 
         * one more movement of all elements         
         * from q2 to q1. 

        pop(s)
            1) Dequeue an item from q1 and return it.
         */
        private Queue<T> _inc = new Queue<T>();
        private Queue<T> _out = new Queue<T>();

        public void Push(T item)
        {
            _out.Enqueue(item);
            while (_inc.Count > 0)
            {
                _out.Enqueue(_inc.Dequeue());
            }
            SwapQueue();
        }

        private void SwapQueue()
        {
            Queue<T> t = _inc;
            _inc = _out;
            _out = t;
        }

        public T Peek()
        {
            return _inc.Peek();
        }

        public T Pop()
        {
            return _inc.Dequeue();
        }
    }
}