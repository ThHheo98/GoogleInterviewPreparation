using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    /// <summary>
    ///     http://www.geeksforgeeks.org/construct-tree-from-given-inorder-and-preorder-traversal/ // тут некорректная
    ///     реализация, она падает на ninterviewbit
    ///     http://algorithms.tutorialhorizon.com/make-a-binary-tree-from-given-inorder-and-preorder-traveral/ // тут
    ///     некорректная реализация, она падает на ninterviewbit
    /// </summary>
    public class InOrderAndPreOrderTraversalAreGivenBuildBst
    {
        private class Solution
        {
            private int find(List<int> preOrder, int start, int end, int val)
            {
                for (var i = start;
                    i <= end;
                    i++)
                {
                    if (preOrder[i] == val)
                        return i;
                }
                return -1;
            }

            private TreeNodeIb build(List<int> preOrder, List<int> inOrder, int start, int end, int preOrderIndex)
            {
                if (start > end)
                    return null;

                var val = preOrder[preOrderIndex];

                var root = new TreeNodeIb(val);

                if (start == end)
                    return root;

                var index = find(inOrder, start, end, root.val);

                root.left = build(preOrder, inOrder, start, index - 1, preOrderIndex + 1);
                root.right = build(preOrder, inOrder, index + 1, end, preOrderIndex + index - start + 1);

                return root;
            }

            [TestCase]
            public void BuildTree()
            {
                var preOrder = new List<int> { 1, 2, 3, 4, 5 };
                var inOrder = new List<int> { 3, 2, 4, 1, 5 };

                var n = preOrder.Count;
                var v = build(preOrder, inOrder, 0, n - 1, 0);

                Console.WriteLine(v.val);
            }
        }
    }
}
