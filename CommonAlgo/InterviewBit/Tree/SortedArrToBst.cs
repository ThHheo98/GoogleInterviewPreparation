using System.Collections.Generic;

namespace CommonAlgo.InterviewBit.Tree
{
    public class SortedArrToBst
    {
        private TreeNodeIb sortedArrayToBSTRec(List<int> a, int start, int finish)
        {
            if (start > finish)
                return null;

            var m = start + (finish - start) / 2;

            var left = sortedArrayToBSTRec(a, start, m - 1);
            var root = new TreeNodeIb(a[m]);
            var right = sortedArrayToBSTRec(a, m + 1, finish);

            root.left = left;
            root.right = right;

            return root;
        }

        public TreeNodeIb SortedArrayToBST(List<int> a)
        {
            var n = a.Count;

            return sortedArrayToBSTRec(a, 0, n - 1);
        }
    }
}
