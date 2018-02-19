using System.Collections.Generic;

namespace CommonAlgo.InterviewBit.Tree
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/inorder-traversal-of-cartesian-tree/
    ///     http://www.sanfoundry.com/java-program-implement-cartesian-tree/
    ///     http://www.geeksforgeeks.org/cartesian-tree/
    /// </summary>
    public class CartesianTree
    {
        /// <summary>
        ///     max heap
        /// </summary>
        /// <param name="a"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private TreeNodeIb build(List<int> a, int start, int end)
        {
            if (start > end) return null;

            var minIndex = -1;
            var min = int.MinValue;
            for (var i = start;
                i <= end;
                i++)
            {
                if (a[i] > min)
                {
                    minIndex = i;
                    min = a[i];
                }
            }

            var n = new TreeNodeIb(a[minIndex]);

            n.left = build(a, start, minIndex - 1);
            n.right = build(a, minIndex + 1, end);

            return n;
        }

        public TreeNodeIb buildTree(List<int> a)
        {
            if (a == null || a.Count == 0) return null;

            var n = a.Count;
            return build(a, 0, n - 1);
        }
    }
}
