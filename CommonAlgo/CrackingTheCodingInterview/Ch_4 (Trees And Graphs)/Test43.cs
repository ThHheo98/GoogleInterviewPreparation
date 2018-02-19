using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    /// <summary>
    ///     Task create minimal BST
    /// </summary>
    public class Test43
    {
        [TestCase]
        public void Test()
        {
            var a = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            TreeNode<int> bst = CreateMinimalBST(a, 0, a.Length - 1);
            PrintInOrder(bst);
            Console.WriteLine();
        }

        private TreeNode<int> CreateMinimalBST(int[] a, int low, int high)
        {
            if (high < low) return null;
            int m = low + (high - low)/2;
            var node = new TreeNode<int>
            {
                data = a[m],
                left = CreateMinimalBST(a, low, m - 1),
                right = CreateMinimalBST(a, m + 1, high)
            };
            return node;
        }

        private static void PrintInOrder(TreeNode<int> root)
        {
            if (root == null) return; // recursion base

            PrintInOrder(root.left);
            Console.Write(root.data + " ");
            PrintInOrder(root.right);
        }
    }

    public class TreeNode<T>
    {
        public T data;
        public TreeNode<T> left;
        public TreeNode<T> right;
    }
}