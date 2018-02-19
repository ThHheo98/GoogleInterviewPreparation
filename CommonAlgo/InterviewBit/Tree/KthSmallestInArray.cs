using System.Collections.Generic;

namespace CommonAlgo.InterviewBit.Tree
{
    public class KthSmallestInArray
    {
        public int Kthsmallest(TreeNodeIb a, int b)
        {
            var s = new Stack<TreeNodeIb>();

            // add sentinal
            s.Push(null);

            //move to left extremen (minimum) 
            var t = a;
            while (t != null)
            {
                s.Push(t);
                t = t.left;
            }

            TreeNodeIb res = null;

            while (s.Count > 0)
            {
                res = s.Pop();

                b--;
                if (b == 0)
                    break;

                if (res.right != null)
                {
                    /* push the left subtree of right subtree */
                    var tmp = res.right;
                    while (tmp != null)
                    {
                        s.Push(tmp);
                        tmp = tmp.left;
                    }
                }
            }

            return res != null ? res.val : -1;
        }
    }
}
