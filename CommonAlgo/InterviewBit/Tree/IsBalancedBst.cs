using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    public class TreeNodeIb
    {
        public TreeNodeIb left;
        public TreeNodeIb right;
        public int val;

        public TreeNodeIb(int val)
        {
            this.val = val;
        }
    }

    public class IsBalancedBst
    {
        private int GetHeight(TreeNodeIb root)
        {
            if (root == null)
                return -1;
            return 1 + Math.Max(GetHeight(root.right), GetHeight(root.left));
        }

        [TestCase]
        public int IsBalanced()
        {
            var a = new TreeNodeIb(1);
            var r = IsBalanced1(a);
            return r ? 1 : 0;
        }

        private bool IsBalanced1(TreeNodeIb a)
        {
            if (a == null)
                return true;

            var lh = GetHeight(a.left);
            var rh = GetHeight(a.right);

            var abs1 = Math.Abs(lh - rh);

            var r = abs1 <= 1;

            return r && IsBalanced1(a.left) && IsBalanced1(a.right);
        }
    }
}
