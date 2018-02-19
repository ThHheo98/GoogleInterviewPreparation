using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.Misc
{
    public class ReverseStackRecursion
    {
        [TestCase]
        public void Test()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            Utils.PrintCollection(new List<int>(stack));
            StackReverse(stack);
            Utils.PrintCollection(new List<int>(stack));
        }

        private void StackReverse(Stack<int> stack)
        {
            if (stack.Count > 0)
            {
                var t = stack.Pop();
                StackReverse(stack);
                InsertAtBottom(stack, t);
            }
        }

        private void InsertAtBottom(Stack<int> s, int t)
        {
            if (s.Count == 0)
            {
                s.Push(t);
            }
            else
            {
                var r = s.Pop();
                InsertAtBottom(s, t);
                s.Push(r);
            }
        }
    }
}