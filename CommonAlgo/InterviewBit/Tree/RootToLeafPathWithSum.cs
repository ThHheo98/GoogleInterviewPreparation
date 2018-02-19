using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/root-to-leaf-paths-with-sum/
    /// </summary>
    public class RootToLeafPathWithSum
    {
        private void ps(TreeNodeIb root, List<List<int>> res, List<int> cur, int sum)
        {
            if (root.left == null && root.right == null && sum == 0)
                res.Add(new List<int>(cur));

            if (root.left != null)
            {
                cur.Add(root.left.val);
                ps(root.left, res, cur, sum - root.left.val);
                cur.RemoveAt(cur.Count - 1);
            }

            if (root.right != null)
            {
                cur.Add(root.right.val);
                ps(root.right, res, cur, sum - root.right.val);
                cur.RemoveAt(cur.Count - 1);
            }
        }

        [TestCase]
        public List<List<int>> PathSum(TreeNodeIb root, int sum)
        {
            var r = new List<List<int>>();
            if (root == null)
                return r;

            var cur = new List<int>();

            cur.Add(root.val);
            ps(root, r, cur, sum - root.val);

            return r;
        }
    }
}
