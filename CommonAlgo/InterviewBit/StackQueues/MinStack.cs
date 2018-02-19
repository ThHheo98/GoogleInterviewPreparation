using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.StackQueues
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/min-stack/
    ///     https://discuss.leetcode.com/topic/4953/share-my-java-solution-with-only-one-stack/11
    /// </summary>
    public class MinStack
    {
        private readonly Stack<Item> st;

        public MinStack()
        {
            st = new Stack<Item>();
        }

        [Test]
        public void Test()
        {
        }

        public void push(int x)
        {
            var min = st.Count > 0 ? x : Math.Min(x, st.Peek().min);
            st.Push(new Item(x, min));
        }

        public void pop()
        {
            if (st.Count > 0)
                st.Pop();
        }

        public int top()
        {
            return st.Count > 0 ? -1 : st.Peek().val;
        }

        public int getMin()
        {
            return st.Count > 0 ? -1 : st.Peek().min;
        }

        private class Item
        {
            public readonly int min;
            public readonly int val;

            public Item(int val, int min)
            {
                this.val = val;
                this.min = min;
            }
        }
    }
}
