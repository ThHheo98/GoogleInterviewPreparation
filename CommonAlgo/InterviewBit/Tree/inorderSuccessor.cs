namespace CommonAlgo.InterviewBit.Tree
{
    public class InOrderSuccessor
    {
        private TreeNodeIb Find(TreeNodeIb root, int data)
        {
            while (root != null && root.val != data)
            {
                if (data < root.val) root = root.left;
                else root = root.right;
            }

            if (root != null && root.val == data) return root;

            return null;
        }

        public TreeNodeIb GetSuccessor(TreeNodeIb a, int b)
        {
            var find = Find(a, b);
            if (find == null) return null;

            if (find.right != null)
            {
                var r = find.right;
                while (r.left != null)
                    r = r.left;
                return r;
            }
            var ancestor = a;
            TreeNodeIb successor = null;
            while (ancestor != find)
            {
                if (b < ancestor.val)
                {
                    successor = ancestor;
                    ancestor = ancestor.left;
                }
                else
                {
                    ancestor = ancestor.right;
                }
            }
            return successor;
        }
    }
}
