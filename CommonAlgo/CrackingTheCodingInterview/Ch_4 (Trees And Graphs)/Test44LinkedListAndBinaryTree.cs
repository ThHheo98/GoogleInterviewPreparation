using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test44LinkedListAndBinaryTree
    {
        [TestCase]
        public void Test44()
        {
            var a = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            TreeNode minimalBst = CreateMinimalBst(a);
            var result = new List<List<int>>();
            CreateListOfEachNodeDFS(minimalBst, result, 0);

            foreach (var list in result)
            {
                foreach (int i in list)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            IEnumerable<IEnumerable<int>> listOfEachNodeBfs = CreateListOfEachNodeBFS(minimalBst);
            foreach (var @is in listOfEachNodeBfs)
            {
                foreach (int i in @is)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        private void CreateListOfEachNodeDFS(TreeNode root, List<List<int>> lists, int level)
        {
            if (root == null) return;

            List<int> list;
            if (lists.Count == level)
            {
                list = new List<int>();
                lists.Add(list);
            }
            else
            {
                list = lists[level];
            }
            list.Add(root.Data);
            CreateListOfEachNodeDFS(root.Left, lists, level + 1);
            CreateListOfEachNodeDFS(root.Right, lists, level + 1);
        }

        private IEnumerable<IEnumerable<int>> CreateListOfEachNodeBFS(TreeNode root)
        {
            var result = new List<List<TreeNode>>();
            var current = new List<TreeNode>();
            if (root != null)
            {
                current.Add(root);
            }

            while (current.Count > 0)
            {
                result.Add(current);
                List<TreeNode> parents = current;
                current = new List<TreeNode>();
                foreach (TreeNode parent in parents)
                {
                    if (parent.Left != null)
                    {
                        current.Add(parent.Left);
                    }
                    if (parent.Right != null)
                    {
                        current.Add(parent.Right);
                    }
                }
            }
            IEnumerable<IEnumerable<int>> enumerable = result.Select(list => list.Select(node => node.Data));
            return enumerable;
        }

        private TreeNode CreateMinimalBst(int[] a)
        {
            return CreateMinimalBst(a, 0, a.Length - 1);
        }

        private static TreeNode CreateMinimalBst(int[] a, int l, int h)
        {
            if (h < l) return null;
            int m = l + (h - l)/2;
            var node = new TreeNode
            {
                Data = a[m],
                Left = CreateMinimalBst(a, l, m - 1),
                Right = CreateMinimalBst(a, m + 1, h)
            };
            return node;
        }

        private class TreeNode
        {
            public int Data;
            public TreeNode Left;
            public TreeNode Right;
        }
    }
}