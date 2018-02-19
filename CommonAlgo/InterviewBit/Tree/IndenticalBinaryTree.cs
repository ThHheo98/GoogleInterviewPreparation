using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    public class IndenticalBinaryTree
    {
        [TestCase(Result = 1)]
        public int IsSameTree(TreeNodeIb a, TreeNodeIb b)
        {
            if (a == null && b == null) return 1;
            if (a != null && b == null) return 0;
            if (a == null && b != null) return 0;

            var r = a.val == b.val && IsSameTree(a.left, b.left) == 1
                    && IsSameTree(a.right, b.right) == 1;
            return r ? 1 : 0;
        }
    }
}
