using System.Collections.Generic;

namespace CommonAlgo.InterviewBit.Tree
{
    internal class PostOrderTraversal
    {
        public List<int> Test(TreeNodeIb a)
        {
            var s = new Stack<TreeNodeIb>();

            var r = new List<int>();

            TreeNodeIb lastVisited = null;

            while (s.Count != 0 || a != null)
            {
                if (a != null)
                {
                    s.Push(a);
                    a = a.left;
                }
                else
                {
                    // If the popped item has a right child and the right child is not
                    // processed yet, then make sure right child is processed before root
                    var p = s.Peek();
                    if (p.right != null && p.right != lastVisited)
                    {
                        a = p.right;
                    }
                    else
                    {
                        lastVisited = s.Pop();
                        r.Add(lastVisited.val);
                    }
                }
            }

            return r;
        }
    }
}
