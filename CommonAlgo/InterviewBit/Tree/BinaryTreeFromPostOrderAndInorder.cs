using System.Collections.Generic;

namespace CommonAlgo.InterviewBit.Tree
{
    public class BinaryTreeFromPostOrderAndInorder
    {
        private static int Find(List<int> arr, int start, int end, int val)
        {
            for (var i = start;
                i <= end;
                i++)
            {
                if (arr[i] == val)
                    return i;
            }
            return -1;
        }

        private static TreeNodeIb Build(List<int> inOrder, List<int> postOrder, int inStart, int inEnd,
            int postStart, int postEnd)
        {
            if (inStart > inEnd || postStart > postEnd)
                return null;

            var node = new TreeNodeIb(postOrder[postEnd]);

            var findIndex = Find(inOrder, inStart, inEnd, node.val);

            node.left = Build(inOrder, postOrder, inStart, findIndex - 1,
                postStart, postStart + findIndex - (inStart + 1));
            node.right = Build(inOrder, postOrder, findIndex + 1, inEnd, postStart + findIndex - inStart,
                postEnd - 1);

            return node;
        }

        public TreeNodeIb BuildTree(List<int> inOrder, List<int> postOrder)
        {
            if (inOrder == null)
                return null;
            if (postOrder == null)
                return null;
            if (inOrder.Count == 0 || postOrder.Count == 0)
                return null;

            if (inOrder.Count != postOrder.Count)
                return null;

            var inOrderLen = inOrder.Count;
            var postOrderLen = postOrder.Count;

            return Build(inOrder, postOrder, 0, inOrderLen - 1, 0, postOrderLen - 1);
        }
    }
}
