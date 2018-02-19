using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/recover-binary-search-tree/
    ///     http://www.programcreek.com/2014/05/leetcode-recover-binary-search-tree-java/
    /// </summary>
    public class RecoverBst
    {
        private TreeNodeIb first;
        private TreeNodeIb pre;
        private TreeNodeIb second;

        private void inorder(TreeNodeIb root)
        {
            if (root == null)
                return;

            inorder(root.left);

            if (pre == null)
            {
                pre = root;
            }
            else
            {
                if (root.val < pre.val)
                {
                    if (first == null)
                        first = pre;

                    second = root;
                }

                pre = root;
            }
            inorder(root.right);
        }

        [TestCase]
        public List<int> RecoverTree(TreeNodeIb a)
        {
            inorder(a);

            var list = new List<int>();

            if (first != null && second != null)
            {
                list.Add(second.val);
                list.Add(first.val);
            }
            return list;
        }
    }
}
