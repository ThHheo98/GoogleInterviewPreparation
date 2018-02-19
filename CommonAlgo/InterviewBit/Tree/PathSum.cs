using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/path-sum/
    /// </summary>
    public class PathSum
    {
        private bool hasSum(TreeNodeIb root, int sum)
        {
            if (root == null) return sum == 0;

            var subSum = sum - root.val;

            if (subSum == 0 && root.left == null && root.right == null) return true;

            var r = false;

            if (root.left != null)
                r = r || hasSum(root.left, subSum);
            if (root.right != null)
                r = r || hasSum(root.right, subSum);

            return r;
        }

        [TestCase]
        public int HasPathSum(TreeNodeIb root, int sum)
        {
            if (root == null) return 0;

            var r = hasSum(root, sum);

            return r ? 1 : 0;
        }
    }
}
