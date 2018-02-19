using System;
using System.Collections.Generic;
using System.Linq;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class StackWithMin<T> : Stack<T> where T : IComparable
    {
        //for resharper
        private void MinStack() { }
        private readonly Stack<T> _min = new Stack<T>();

        public T Min()
        {
            if (_min.Count == 0)
            {
                throw new StackIsEmptyException("Stack is empty");
            }
            return _min.Peek();
        }

        public new void Push(T item)
        {
            if (Count > 0)
            {
                if (item.CompareTo(Min()) <= 0)
                {
                    _min.Push(item);
                }
            }
            else
            {
                _min.Push(item);
            }
        }

        public new T Pop()
        {
            if (Count == 0)
            {
                throw new StackIsEmptyException("Stack is empty");
            }

            var pop = base.Pop();
            if (pop.Equals(Min()))
            {
                _min.Pop();
            }
            return pop;
        }
    }

    public class SetOfStack<T> where T : IComparable
    {
        private readonly IList<Stack<T>> _list;
        private readonly int _stackMaxCapacity;
        private int _count;

        public SetOfStack(int stackMaxCapacity)
        {
            _count = 0;
            _list = new List<Stack<T>> {new Stack<T>()};
            _stackMaxCapacity = stackMaxCapacity;
        }

        public int Count
        {
            get { return _count; }
        }


        public void Push(T item)
        {
            Stack<T> stack = GetLastStack();
            if (stack != null && stack.Count < _stackMaxCapacity)
            {
                stack.Push(item);
            }
            else
            {
                var stack1 = new Stack<T>();
                stack1.Push(item);
                _list.Add(stack1);
            }

            _count++;
        }

        private Stack<T> GetLastStack()
        {
            return _list.Last();
        }

        public T Pop()
        {
            Stack<T> t = GetLastStack();
            _count--;
            T pop = t.Pop();
            if (t.Count == 0) _list.RemoveAt(_list.Count - 1);
            return pop;
        }

//        public T PopAt(int stackIndex)
//        {
//            if (stackIndex < 1 || stackIndex > _array.Length)
//                throw new InvalidStackIndexException(string.Format("Invalid stack index!"));
//
//            if (_array[stackIndex-1].Count == 0)
//                throw new StackIsEmptyException(string.Format("Stack with index {0} is empty!", stackIndex));
//            _count--;
//            return _array[stackIndex-1].Pop();
//        }

        public T Peek()
        {
            Stack<T> t = GetLastStack();
            return t.Pop();
        }
    }
}