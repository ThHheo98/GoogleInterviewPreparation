using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Graphs
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int val;

        public TreeNode(int x)
        {
            val = x;
            left = right = null;
        }
    }

    public class LevelTraversal
    {
        [Test]
        public void LevelOrder()
        {
            var A = new TreeNode(2)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(5),
                    right = new TreeNode(6)
                },
                right = new TreeNode(4)
                {
                    left = new TreeNode(7),
                    right = new TreeNode(8)
                }
            };
            var ans = new List<List<int>>();
            bfs(ans, A);
            foreach (var a in ans)
            {
                foreach (var i in a)
                    Console.Write(i + " ");
                Console.WriteLine();
            }
        }

        private void bfs(List<List<int>> ans, TreeNode root)
        {
            if (root == null)
                return;
            var q = new Queue<MyClass>();
            q.Enqueue(new MyClass(root, 0));
            while (q.Count > 0)
            {
                var i = q.Dequeue();
                if (i.node.left != null)
                    q.Enqueue(new MyClass(i.node.left, i.lvl + 1));
                if (i.node.right != null)
                    q.Enqueue(new MyClass(i.node.right, i.lvl + 1));
                if (i.lvl >= ans.Count)
                    ans.Add(new List<int>());
                ans[i.lvl].Add(i.node.val);
            }
        }

        private class MyClass
        {
            public readonly int lvl;
            public readonly TreeNode node;

            public MyClass(TreeNode n, int lvl)
            {
                this.lvl = lvl;
                node = n;
            }
        }
    }
}
