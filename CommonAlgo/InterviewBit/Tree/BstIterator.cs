using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    public class BstIterator
    {
        private readonly Stack<TreeNodeIb> _stack = new Stack<TreeNodeIb>();
        private TreeNodeIb _curr;

        public BstIterator(TreeNodeIb root)
        {
            _curr = root;
        }

        public bool HasNext()
        {
            return _curr != null || _stack.Count > 0;
        }

        public int Next()
        {
            while (true)
            {
                if (_curr != null)
                {
                    _stack.Push(_curr);
                    _curr = _curr.left;
                    continue;
                }

                if (_stack.Count > 0)
                {
                    _curr = _stack.Peek();
                    var ans = _curr.val;
                    _stack.Pop();
                    _curr = _curr.right;
                    return ans;
                }
                break;
            }
            return int.MinValue;
        }

        [TestCase]
        public void Main()
        {
            var root = new TreeNodeIb(2) { left = new TreeNodeIb(1) };

            var i = new BstIterator(root);
            while (i.HasNext())
                Console.WriteLine(i.HasNext());
        }
    }
}
