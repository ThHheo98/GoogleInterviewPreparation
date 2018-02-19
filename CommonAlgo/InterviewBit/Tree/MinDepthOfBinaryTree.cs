using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    public class MinDepthOfBinaryTree
    {
        [TestCase]
        public int minDepth(TreeNodeIb a)
        {
            if (a == null)
                return 0;

            var q = new Queue<TreeNodeIb>();
            var qc = new Queue<int>();

            q.Enqueue(a);
            qc.Enqueue(1);

            while (q.Count > 0)
            {
                var p = q.Dequeue();
                var cnt = qc.Dequeue();

                if (p.left == null && p.right == null)
                    return cnt;

                if (p.left != null)
                {
                    q.Enqueue(p.left);
                    qc.Enqueue(cnt + 1);
                }

                if (p.right != null)
                {
                    q.Enqueue(p.right);
                    qc.Enqueue(cnt + 1);
                }
            }

            return 0;
        }
    }
}
