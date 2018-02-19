using System;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class _3StackInArray<T> where T : IComparable
    {
        private readonly T[] _array;
        private readonly int _capacity;
        private readonly int _stackCount;

        private readonly int[] _stackLengths;

        public _3StackInArray(int stackCount, int capacity)
        {
            if (stackCount < 1) throw new ArgumentOutOfRangeException("stackCount");
            if (capacity < 1) throw new ArgumentOutOfRangeException("capacity");

            _capacity = capacity;
            _stackCount = stackCount;
            _array = new T[_stackCount*capacity];
            _stackLengths = new int[_stackCount];
        }

        public int CountOfStacks
        {
            get { return _stackCount; }
        }

        private int GetCurrentIndexByStackIndex(int stackIndex)
        {
            if (stackIndex <= 0 || stackIndex > 3) throw new ArgumentOutOfRangeException("stackIndex");
            return _capacity*(stackIndex - 1) + _stackLengths[stackIndex - 1];
        }

        public void Push(T data, int stackIndex)
        {
            CheckStackIsFull(stackIndex);
            int index = GetCurrentIndexByStackIndex(stackIndex);
            _array[index] = data;
            IncreaseCurrentItemIndex(stackIndex);
        }

        private void CheckStackIsFull(int stackIndex)
        {
            if (_stackLengths[stackIndex - 1] == _capacity)
                throw new FullStackException(string.Format("Stack with index {0} is full!", stackIndex));
        }

        private void CheckStackIsEmpty(int stackIndex)
        {
            if (_stackLengths[stackIndex - 1] == 0)
                throw new StackIsEmptyException(string.Format("Stack with index {0} is empty!", stackIndex));
        }

        private void IncreaseCurrentItemIndex(int stackIndex)
        {
            _stackLengths[stackIndex - 1]++;
        }

        private void DecreaseCurrentItemIndex(int stackIndex)
        {
            _stackLengths[stackIndex - 1]--;
        }

        public T Pop(int stackIndex)
        {
            CheckStackIsEmpty(stackIndex);
            int index = GetCurrentIndexByStackIndex(stackIndex) - 1;
            T result = _array[index];
            DecreaseCurrentItemIndex(stackIndex);
            return result;
        }

        public T Peek(int stackIndex)
        {
            CheckStackIsEmpty(stackIndex);
            int index = GetCurrentIndexByStackIndex(stackIndex) - 1;
            return _array[index];
        }
    }
}