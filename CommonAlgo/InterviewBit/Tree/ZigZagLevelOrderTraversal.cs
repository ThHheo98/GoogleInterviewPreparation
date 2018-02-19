using System.Collections.Generic;

namespace CommonAlgo.InterviewBit.Tree
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/zigzag-level-order-traversal-bt/
    /// </summary>
    public class ZigZagLevelOrderTraversal
    {
        public List<List<int>> ZigzagLevelOrder(TreeNodeIb a)
        {
            if (a == null)
                return null;
            var res = new List<List<int>>();

            var q = new Queue<TreeNodeIb>();
            q.Enqueue(a);
            q.Enqueue(null); // sentinal

            var dir = false; // dir = false => add on back if dir == true then add on front

            var cur = new LinkedList<int>();

            while (q.Count > 0)
            {
                var p = q.Dequeue();

                if (p == null)
                {
                    dir = !dir;

                    if (q.Count > 0)
                        q.Enqueue(null);

                    res.Add(new List<int>(cur));
                    cur.Clear();
                    continue;
                }

                if (p.left != null)
                    q.Enqueue(p.left);

                if (p.right != null)
                    q.Enqueue(p.right);

                if (dir)
                    cur.AddFirst(p.val);
                else
                    cur.AddLast(p.val);
            }

            return res;
        }
    }
}
