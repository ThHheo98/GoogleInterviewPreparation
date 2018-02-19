using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/least-common-ancestor/
    ///     http://www.geeksforgeeks.org/lowest-common-ancestor-binary-tree-set-1/
    ///     http://articles.leetcode.com/lowest-common-ancestor-of-a-binary-tree-part-i/
    ///     http://articles.leetcode.com/lowest-common-ancestor-of-a-binary-tree-part-ii/
    ///     есть 2 решения
    ///     1) не очень эффективное по памяти, однако работает если мы не знаем точно что такой предок в дереве есть
    ///     2) более эффективный: но только если мы знаем что предок точно есть в дереве
    /// </summary>
    public class LowestCommonAncestor
    {
        [Test]
        public void LcaTest2()
        {
            var node = new TreeNodeIb(3)
            {
                left = new TreeNodeIb(5),
                right = new TreeNodeIb(1)
            };

            var r = lcaEff(node, 5, 1);
            Assert.IsTrue(r == 3);
        }

        // efficient
        public int lcaEff(TreeNodeIb a, int val1, int val2)
        {
            a = findLCA(a, val1, val2);
            if (a == null)
                return -1;
            return a.val;
        }

        public TreeNodeIb findLCA(TreeNodeIb node, int val1, int val2)
        {
            if (node == null)
                return null;
            if (node.val == val1 || node.val == val2)
                return node;

            var leftLCA = findLCA(node.left, val1, val2);
            var rightLCA = findLCA(node.right, val1, val2);

            if (leftLCA != null && rightLCA != null)
                return node;

            return leftLCA != null ? leftLCA : rightLCA;
        }

        #region Approach 1

        [TestCase]
        public void LcaTest1()
        {
            var node = new TreeNodeIb(3);
            node.left = new TreeNodeIb(5);
            node.right = new TreeNodeIb(1);

            var r = lca(node, 5, 1);
            Assert.IsTrue(r == 3);
        }

        public int lca(TreeNodeIb a, int val1, int val2)
        {
            var path1 = new List<int>();
            var path2 = new List<int>();
            if (!FindPath(a, path1, val1) || !FindPath(a, path2, val2))
                return -1;
            var i = 0;
            for (i = 0;
                i < path1.Count && i < path2.Count;
                i++)
            {
                if (path1[i] != path2[i])
                    break;
            }
            return path1[i - 1];
        }

        private static bool FindPath(TreeNodeIb node, List<int> path, int k)
        {
            if (node == null)
                return false;
            path.Add(node.val);
            if (node.val == k)
                return true;
            if (node.left != null && FindPath(node.left, path, k) ||
                node.right != null && FindPath(node.right, path, k))
                return true;
            path.RemoveAt(path.Count - 1);
            return false;
        }

        #endregion
    }
}
