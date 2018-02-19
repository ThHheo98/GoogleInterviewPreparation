using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test41Inefficient
    {
        private int Height(Node node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        private bool IsBalanced(Node root)
        {
            if (root == null)
            {
                return true;
            }
            int leftHeight = Height(root.Left);
            int rightHeight = Height(root.Right);

            if (Math.Abs(leftHeight - rightHeight) <= 1
                && IsBalanced(root.Left)
                && IsBalanced(root.Right)
                )
                return true;

            return false;
        }

        private Node AddNewNode(int data)
        {
            return new Node {Data = data};
        }

        /// <summary>
        ///     Time O(N^2) inefficient solution
        /// </summary>
        [TestCase]
        public void Test()
        {
            /*
             *  Disbalanced tree
             *        10 
             *       /  \
             *      6   15
             *     / \
             *    3   8
             *   / 
             *  2
             */
            Node disbalancedTree = AddNewNode(10);
            disbalancedTree.Left = AddNewNode(6);
            disbalancedTree.Right = AddNewNode(15);
            disbalancedTree.Left.Left = AddNewNode(3);
            disbalancedTree.Left.Right = AddNewNode(8);
            disbalancedTree.Left.Left.Left = AddNewNode(2);
            bool isBalanced = IsBalanced(disbalancedTree);
            Console.WriteLine(isBalanced ? "Is Balanced" : "Is NOT Balanced");

            /*
            *  Disbalanced tree
            *        10 
            *       /  \
            *      6   15
            *     / \
            *    3   8
            */
            Node balancedTree = AddNewNode(10);
            balancedTree.Left = AddNewNode(6);
            balancedTree.Right = AddNewNode(15);
            balancedTree.Left.Left = AddNewNode(3);
            balancedTree.Left.Right = AddNewNode(8);
            bool balanced = IsBalanced(balancedTree);
            Console.WriteLine(balanced ? "Is Balanced" : "Is NOT Balanced");
        }

        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
        }
    }


    /// <summary>
    ///     Check tree is balanced by time O(N)
    ///     and space O(log N)(recursion)
    /// </summary>
    public class Test41Efficient
    {
        private int Height(Node node)
        {
            if (node == null)
                return 0;

            int leftHeight = Height(node.Left);
            if (leftHeight == -1) return -1;
            int rightHeight = Height(node.Right);
            if (rightHeight == -1) return -1;

            int diffOfHeight = Math.Abs(leftHeight - rightHeight);
            if (diffOfHeight > 1)
                return -1;
            return 1 + Math.Max(leftHeight, rightHeight);
        }

        private bool IsBalanced(Node root)
        {
            int height = Height(root);
            return height != -1;
        }

        private Node AddNewNode(int data)
        {
            return new Node {Data = data};
        }

        /// <summary>
        ///     Time O(N^2) inefficient solution
        /// </summary>
        [TestCase]
        public void Test()
        {
            /*
             *  Disbalanced tree
             *        10 
             *       /  \
             *      6   15
             *     / \
             *    3   8
             *   / 
             *  2
             */
            Node disbalancedTree = AddNewNode(10);
            disbalancedTree.Left = AddNewNode(6);
            disbalancedTree.Right = AddNewNode(15);
            disbalancedTree.Left.Left = AddNewNode(3);
            disbalancedTree.Left.Right = AddNewNode(8);
            disbalancedTree.Left.Left.Left = AddNewNode(2);
            bool isBalanced = IsBalanced(disbalancedTree);
            Console.WriteLine(isBalanced ? "Is Balanced" : "Is NOT Balanced");

            /*
            *  Disbalanced tree
            *        10 
            *       /  \
            *      6   15
            *     / \
            *    3   8
            */
            Node balancedTree = AddNewNode(10);
            balancedTree.Left = AddNewNode(6);
            balancedTree.Right = AddNewNode(15);
            balancedTree.Left.Left = AddNewNode(3);
            balancedTree.Left.Right = AddNewNode(8);
            bool balanced = IsBalanced(balancedTree);
            Console.WriteLine(balanced ? "Is Balanced" : "Is NOT Balanced");
        }

        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
        }
    }
}