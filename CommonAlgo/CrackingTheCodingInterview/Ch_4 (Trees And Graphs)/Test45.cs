using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test45
    {
        /// <summary>
        ///     Для поиска
        /// </summary>
        /// <returns></returns>
        private void isbinarysearchtree()
        {
        }


        private Node AddNewNode(int data)
        {
            return new Node {Data = data};
        }

        [TestCase]
        public void Test()
        {
            Console.WriteLine("Inorder traversal");

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
            Node bst = AddNewNode(10);
            bst.Left = AddNewNode(6);
            bst.Right = AddNewNode(15);
            bst.Left.Left = AddNewNode(3);
            bst.Left.Right = AddNewNode(8);
            bst.Left.Left.Left = AddNewNode(2);
            int minValue = Int32.MinValue;
            bool isBst = IsBst(bst, ref minValue);
            Assert.IsTrue(isBst);
            Console.WriteLine(isBst ? "Is BST" : "Is NOT BST");

            /*
            *  Disbalanced tree
            *        10 
            *       /  \
            *      6   15
            *     / \
            *    3   300
            */
            Node notBst = AddNewNode(10);
            notBst.Left = AddNewNode(6);
            notBst.Right = AddNewNode(15);
            notBst.Left.Left = AddNewNode(3);
            notBst.Left.Right = AddNewNode(300);
            int minValue1 = Int32.MinValue;
            bool isBst2 = IsBst(notBst, ref minValue1);
            Assert.IsFalse(isBst2);
            Console.WriteLine(isBst2 ? "Is BST" : "Is NOT BST");

            Console.WriteLine("Max/Min method");
            bool isBst3 = IsBst2(bst, int.MinValue, int.MaxValue);
            Console.WriteLine(isBst3 ? "Is BST" : "Is NOT BST");
            bool isBst4 = IsBst2(notBst, int.MinValue, int.MaxValue);
            Console.WriteLine(isBst4 ? "Is BST" : "Is NOT BST");
        }


        private bool IsBst(Node root, ref int lastData)
        {
            if (root == null) return true;

            if (!IsBst(root.Left, ref lastData)) return false;

            if (root.Data < lastData) return false;
            lastData = root.Data;
            if (!IsBst(root.Right, ref lastData)) return false;
            return true;
        }

        /// <summary>
        ///     Min/Max Solution
        /// </summary>
        /// <returns></returns>
        private bool IsBst2(Node root, int min, int max)
        {
            if (root == null) return true;
            if (root.Data < min || root.Data > max)
                return false;
            return IsBst2(root.Left, min, root.Data) && IsBst2(root.Right, root.Data, max);
        }

        private class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
        }
    }
}