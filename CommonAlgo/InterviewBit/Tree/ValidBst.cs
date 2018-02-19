namespace CommonAlgo.InterviewBit.Tree
{
    internal class ValidBst
    {
        public bool IsSubtreeLesser(TreeNodeIb a, int data)
        {
            if (a == null)
                return true;
            if (
                a.val < data &&
                IsSubtreeLesser(a.left, data)
                && IsSubtreeLesser(a.right, data)
            )
                return true;

            return false;
        }

        public bool IsSubtreeGreater(TreeNodeIb a, int data)
        {
            if (a == null)
                return true;
            if (
                a.val > data &&
                IsSubtreeGreater(a.left, data) &&
                IsSubtreeGreater(a.right, data)
            )
                return true;

            return false;
        }

        public int isValidBST(TreeNodeIb a)
        {
            if (a == null)
                return 1;

            var r = IsSubtreeLesser(a.left, a.val)
                    && IsSubtreeGreater(a.right, a.val)
                    && isValidBST(a.left) == 1
                    && isValidBST(a.right) == 1;

            return r ? 1 : 0;
        }
    }
}
