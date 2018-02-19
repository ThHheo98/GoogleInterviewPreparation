namespace CommonAlgo.InterviewBit.Tree
{
    public class SymmetricBinaryTree
    {
        private bool IsSymmetricSubtree(TreeNodeIb a, TreeNodeIb b)
        {
            if (a == null && b == null) return true;
            if (a != null && b == null) return false;
            if (a == null && b != null) return false;

            var r = a.val == b.val;

            return r && IsSymmetricSubtree(a.left, b.right) && IsSymmetricSubtree(a.right, b.left);
        }

        public int IsSymmetric(TreeNodeIb a)
        {
            if (a == null) return 1;
            if (a.right == null && a.left == null) return 1;
            if (a.left != null && a.right == null) return 0;
            if (a.right != null && a.left == null) return 0;

            return IsSymmetricSubtree(a.left, a.right) ? 1 : 0;
        }
    }
}
