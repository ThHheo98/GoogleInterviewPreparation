using System.Collections.Generic;

namespace CommonAlgo.InterviewBit.Tree
{
    internal class InOrderTraversal
    {
        public List<int> InorderTraversal(TreeNodeIb a)
        {
            var s = new Stack<TreeNodeIb>();
            var r = new List<int>();
            while (s.Count != 0 || a != null)
            {
                if (a != null)
                {
                    s.Push(a);
                    a = a.left;
                }
                else
                {
                    a = s.Pop();
                    r.Add(a.val);
                    a = a.right;
                }
            }

            return r;
        }
    }
}
