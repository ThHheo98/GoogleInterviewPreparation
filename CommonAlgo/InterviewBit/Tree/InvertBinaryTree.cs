using System.Collections.Generic;

namespace CommonAlgo.InterviewBit.Tree
{
    public class InvertBinaryTree
    {
        private TreeNodeIb NonRecInvert(TreeNodeIb r)
        {
            var q = new Queue<TreeNodeIb>();

            if (r != null)
                q.Enqueue(r);

            while (q.Count > 0)
            {
                var p = q.Dequeue();
                if (p.left != null)
                    q.Enqueue(p.left);
                if (p.right != null)
                    q.Enqueue(p.right);

                var t = p.left;
                p.left = p.right;
                p.right = t;
            }

            return r;
        }

        public TreeNodeIb Invert(TreeNodeIb r)
        {
            if (r == null)
                return null;

            r.left = Invert(r.left);
            r.right = Invert(r.right);

            var t = r.left;
            r.left = r.right;
            r.right = t;

            return r;
        }
    }
}
