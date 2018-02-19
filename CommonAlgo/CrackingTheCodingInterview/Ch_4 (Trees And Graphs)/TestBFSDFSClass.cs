using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class TestBFSDFSClass
    {
        [TestCase]
        public void Test()
        {
            var a = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            var root = CreateMinimalBST(a);
            BFS(root);
            Console.WriteLine();
            DFS(root);
        }

        private Node CreateMinimalBST(int[] a)
        {
            return CreateMinimalBST(a, 0, a.Length - 1);
        }

        private Node CreateMinimalBST(int[] a, int l, int h)
        {
            if (h >= l)
            {
                int mid = l + (h - l)/2;
                var node = new Node();
                node.Data = a[mid];
                node.Right = CreateMinimalBST(a, mid + 1, h);
                node.Left = CreateMinimalBST(a, l, mid - 1);
                return node;
            }
            return null;
        }


        public void BFS(Node node)
        {
            var q = new Queue<Node>();
            q.Enqueue(node);
            while (q.Count > 0)
            {
                node = q.Dequeue();
                Console.WriteLine(node.Data);
                if (node.Left != null) q.Enqueue(node.Left);
                if (node.Right != null) q.Enqueue(node.Right);
            }
        }

        public void DFS(Node node)
        {
            var s = new Stack<Node>();
            s.Push(node);
            while (s.Count > 0)
            {
                node = s.Pop();
                Console.WriteLine(node.Data);
                if (node.Left != null) s.Push(node.Left);
                if (node.Right != null) s.Push(node.Right);
            }
        }


        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;

            public override string ToString()
            {
                return string.Format("Data: {0}", Data);
            }
        }
    }
}