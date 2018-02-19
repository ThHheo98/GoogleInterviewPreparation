using System;
using CommonAlgo.ADT.Interfaces;
using CommonAlgo.ADT.Stacks;

namespace CommonAlgo.ADT.Queue
{
    public class TwoStackQueue<T> : IQueue<T> where T : IComparable
    {
        private readonly ResizingArrayStack<T> _inbox = new ResizingArrayStack<T>();
        private readonly ResizingArrayStack<T> _outbox = new ResizingArrayStack<T>();

        #region Implementation of IQueue<T>

        public T Dequeue()
        {
            if (_outbox.IsEmpty())
            {
                while (!_inbox.IsEmpty())
                {
                    _outbox.Push(_inbox.Pop());
                }
            }
            return _outbox.Pop();
        }

        public void Enqueue(T item)
        {
            _inbox.Push(item);
        }

        public bool IsEmpty()
        {
            return _inbox.ItemCount == 0 && _outbox.ItemCount == 0;
        }

        public int Count
        {
            get { return _inbox.ItemCount + _outbox.ItemCount; }
        }

        #endregion
    }
}