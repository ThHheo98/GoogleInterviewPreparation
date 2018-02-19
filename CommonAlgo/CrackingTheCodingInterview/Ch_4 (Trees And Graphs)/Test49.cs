using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test49
    {
        private void FindSum(Node node, int sum, int[] path, int level)
        {
            if (node == null)
            {
                return;
            }

            path[level] = node.Data;
            int t = 0;
            for (int i = level; i >= 0; i--)
            {
                t += path[i];
                if (t == sum)
                {
                    Print(path, i, level);
                }
            }

            FindSum(node.Left, sum, path, level + 1);
            FindSum(node.Right, sum, path, level + 1);

            path[level] = int.MinValue;
        }

        private void FindSum(Node node, int sum)
        {
            int d = GetDepth(node);
            var path = new int[d];
            FindSum(node, sum, path, 0);
        }

        private int GetDepth(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return 1 + Math.Max(GetDepth(node.Left), GetDepth(node.Right));
        }

        private void Print(int[] path, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.WriteLine(path[i] + " ");
            }
            Console.WriteLine();
        }

        private Node AddNewNode(int data)
        {
            return new Node
            {
                Data = data
            };
        }

        [TestCase]
        public void Test()
        {
            /*
                        20
             *         /  \
             *        8   22
                     / \
             *      4  12
             *        /  \
             *       10  14 
             */
            Node bigTree = AddNewNode(20); // big tree
            bigTree.Right = AddNewNode(22);
            bigTree.Left = AddNewNode(8);
            bigTree.Left.Left = AddNewNode(4);
            bigTree.Left.Right = AddNewNode(12);
            bigTree.Left.Right.Left = AddNewNode(10);
            bigTree.Left.Right.Right = AddNewNode(14);

            Node subTree = bigTree.Left.Right;

            FindSum(bigTree, 12);
            FindSum(bigTree, 22);
        }

        private class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
        }
    }
}