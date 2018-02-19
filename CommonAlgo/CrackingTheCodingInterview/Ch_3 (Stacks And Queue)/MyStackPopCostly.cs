using System.Collections.Generic;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class MyStackPopCostly<T>
    {
        /*
         * push(s,  x)  
         * 1) Enqueue x to q1 (assuming size of q1 is unlimited).

         * pop(s)    
         * 1) One by one dequeue everything except the last element from q1 and enqueue to q2.  
         * 2) Dequeue the last item of q1, the dequeued item is result, store it.  
         * 3) Swap the names of q1 and q2  
         * 4) Return the item stored in step 2.
         * Swapping of names is done to avoid one more movement of all elements from q2 to q1.
         
         */
        private Queue<T> _inc = new Queue<T>();
        private Queue<T> _out = new Queue<T>();

        public void Push(T item)
        {
            _inc.Enqueue(item);
        }

        private void SwapQueue()
        {
            Queue<T> t = _inc;
            _inc = _out;
            _out = t;
        }

        public T Peek()
        {
            ShiftQueue();
            T r = _inc.Peek();
            SwapQueue();
            return r;
        }

        private void ShiftQueue()
        {
            while (_inc.Count > 1)
            {
                _out.Enqueue(_inc.Dequeue());
            }
        }

        public T Pop()
        {
            ShiftQueue();
            T r = _inc.Dequeue();
            SwapQueue();
            return r;
        }
    }
}