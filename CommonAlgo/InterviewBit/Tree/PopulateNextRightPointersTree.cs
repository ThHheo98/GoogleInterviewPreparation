using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/populate-next-right-pointers-tree/
    /// </summary>
    public class PopulateNextRightPointersTree
    {
        [TestCase]
        public void Connect()
        {
            var root = new TreeLinkNode(10);

            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (root == null)
                return;

            var q = new Queue<TreeLinkNode>();
            q.Enqueue(root);
            q.Enqueue(null);

            while (q.Count > 0)
            {
                var p = q.Dequeue();

                if (p == null)
                {
                    if (q.Count > 0)
                        q.Enqueue(null);

                    continue;
                }

                var nextNode = q.Peek();
                p.next = nextNode;

                if (p.left != null)
                    q.Enqueue(p.left);
                if (p.right != null)
                    q.Enqueue(p.right);
            }
        }

        public class TreeLinkNode
        {
            public TreeLinkNode left, right, next;
            private int val;

            public TreeLinkNode(int x)
            {
                val = x;
            }
        }
    }
}
