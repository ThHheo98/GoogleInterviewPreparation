using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    //http://stackoverflow.com/questions/5471731/in-order-successor-in-binary-search-tree
    public class Test46
    {
        private Node InOrderSuccessor(Node n)
        {
            // 1. The leftmost child of the right child, 
            //    if your current node has a right child. 
            //    If the right child has no left child, the right child is your inorder successor.
            // 2. Navigate up the parent ancestor nodes, 
            //    and when you find a parent whose left child 
            //    is the node you're currently at, 
            //    the parent is the inorder successor of your original node.
            if (n == null) return null;
            //case 1
            if (n.Parent == null || n.Right != null)
                return LeftMostChild(n.Right);

            //case 2
            // 2. Navigate up the parent ancestor nodes, 
            //    and when you find a parent whose left child 
            //    is the node you're currently at, 
            //    the parent is the inorder successor of your original node.
            Node q = n;
            Node x = n.Parent;
            while (x != null && x.Left != q) // whose left child is the node you're currently at, 
            {
                q = x;
                x = x.Parent;
            }
            return x;
        }

        private Node LeftMostChild(Node n)
        {
            if (n == null)
            {
                return null;
            }

            while (n.Left != null)
            {
                n = n.Left;
            }
            return n;
        }

        private Node AddNewNode(int data)
        {
            var node = new Node {Data = data};
            return node;
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
            Node root = AddNewNode(20);
            root.Right = AddNewNode(22);
            root.Left = AddNewNode(8);

            root.Left.Parent = root;
            root.Right.Parent = root;

            root.Left.Left = AddNewNode(4);
            root.Left.Right = AddNewNode(12);

            root.Left.Left.Parent = root.Left;
            root.Left.Right.Parent = root.Left;

            root.Left.Right.Left = AddNewNode(10);
            root.Left.Right.Right = AddNewNode(14);

            root.Left.Right.Left.Parent = root.Left.Right;
            root.Left.Right.Right.Parent = root.Left.Right;

            Node tmp = root.Left.Right.Left; // 10
            Node successor = InOrderSuccessor(tmp);
            Assert.AreEqual(12, successor.Data);

            tmp = root; // 20
            successor = InOrderSuccessor(tmp);
            Assert.AreEqual(22, successor.Data);

            tmp = root.Left.Right.Right; // 20
            successor = InOrderSuccessor(tmp);
            Assert.AreEqual(20, successor.Data);
        }

        private class Node
        {
            public int Data;
            public Node Left;
            public Node Parent;
            public Node Right;
        }
    }
}