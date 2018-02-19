using System.Collections.Generic;

namespace CommonAlgo.InterviewBit.Tree
{
    public class PreorderTraversal
    {
        public List<int> Test(TreeNodeIb a)
        {
            if (a == null) return null;
            var s = new Stack<TreeNodeIb>();
            var r = new List<int>();

            s.Push(a);

            while (s.Count > 0)
            {
                var p = s.Pop();
                r.Add(p.val);
                if (p.right != null)
                    s.Push(p.right);
                if (p.left != null)
                    s.Push(p.left);
            }

            return r;
        }
    }
}
