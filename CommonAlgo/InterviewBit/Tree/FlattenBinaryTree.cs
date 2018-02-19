using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/flatten-binary-tree-to-linked-list/
    ///     http://www.programcreek.com/2013/01/leetcode-flatten-binary-tree-to-linked-list/
    ///     http://qa.geeksforgeeks.org/3976/flattening-a-binary-tree
    /// </summary>
    public class FlattenBinaryTree
    {
        public void Flatten2()
        {
            var a = new TreeNodeIb(3) { left = new TreeNodeIb(1), right = new TreeNodeIb(5) };
            var s = new Stack<TreeNodeIb>();
            var p = a;

            while (p != null || s.Count > 0)
            {
                if (p.right != null)
                    s.Push(p.right);

                if (p.left != null)
                {
                    p.right = p.left;
                    p.left = null;
                }
                else
                {
                    if (s.Count > 0)
                    {
                        var tmp = s.Pop();
                        p.right = tmp;
                    }
                }
                p = p.right;
            }
        }

        [TestCase]
        public void Flatten()
        {
            var root = new TreeNodeIb(3) { left = new TreeNodeIb(1), right = new TreeNodeIb(3) };
            if (root == null)
                return;

            var node = root;
            while (node != null)
            {
                // Attatches the right sub-tree to the rightmost leaf of the left sub-tree:
                if (node.left != null)
                {
                    var rightMost = node.left;
                    while (rightMost.right != null)
                        rightMost = rightMost.right;
                    rightMost.right = node.right;

                    // Makes the left sub-tree to the right sub-tree:
                    node.right = node.left;
                    node.left = null;
                }

                // Flatten the rest of the tree:
                node = node.right;
            }
        }
    }
}
