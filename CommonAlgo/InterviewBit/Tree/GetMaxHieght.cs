using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/max-depth-of-binary-tree/
    /// </summary>
    public class GetMaxDepth
    {
        private int getHeight(TreeNodeIb r)
        {
            if (r == null)
                return 0;

            return 1 + Math.Max(getHeight(r.left), getHeight(r.right));
        }

        [TestCase]
        public int MaxDepth(TreeNodeIb a)
        {
            if (a == null)
                return 0;

            return getHeight(a);
        }
    }
}
