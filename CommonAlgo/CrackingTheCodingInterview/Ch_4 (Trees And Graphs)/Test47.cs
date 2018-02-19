using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    /// <summary>
    ///     Find Common Ancestor of Two Nodes (IMPORTANT)
    /// </summary>
    public class Test47
    {
        private bool Covers(Node root, Node n)
        {
            if (root == null) return false;
            if (root == n) return true;
            return Covers(root.Left, n) || Covers(root.Right, n);
        }

        private Node GetCommonAncestorHelper(Node root, Node p, Node q)
        {
            bool isPOnLeft = Covers(root.Left, p);
            bool isQOnLeft = Covers(root.Left, q);

            if (isPOnLeft != isQOnLeft) return root;

            Node childSide = isPOnLeft ? root.Left : root.Right;
            return GetCommonAncestorHelper(childSide, p, q);
        }

        private Node GetCommonAncestor(Node root, Node p, Node q)
        {
            if (!Covers(root, p) || !Covers(root, q))
            {
                return null;
            }
            return GetCommonAncestorHelper(root, p, q);
        }

        private Node AddNewNode(int data)
        {
            var node = new Node {Data = data};
            return node;
        }

        [TestCase]
        public void TestSolution2()
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
            root.Left.Left = AddNewNode(4);
            root.Left.Right = AddNewNode(12);
            root.Left.Right.Left = AddNewNode(10);
            root.Left.Right.Right = AddNewNode(14);

            Node t = GetCommonAncestor(root, root.Right, root.Left);
            Assert.AreEqual(root, t); // 20

            t = GetCommonAncestor(root, root.Left.Left, root.Left.Right);
            Assert.AreEqual(root.Left, t); // 8
        }

        private Result GetCommonAncestorResult(Node root, Node p, Node q)
        {
            if (root == null)
                return new Result(null, false);

            if (root == p && root == q)
            {
                return new Result(root, true);
            }

            Result rx = GetCommonAncestorResult(root.Left, p, q);
            if (rx.IsAncestor)
            {
                return rx;
            }

            Result ry = GetCommonAncestorResult(root.Right, p, q);
            if (ry.IsAncestor)
            {
                return ry;
            }
            if (rx.Node != null && ry.Node != null)
            {
                return new Result(root, true);
            }

            if (root == p || root == q)
            {
                bool isAncestor = rx.Node != null || ry.Node != null;
                return new Result(root, isAncestor);
            }
            return new Result(rx.Node ?? ry.Node, false);
        }

        private Node CommonAncestor(Node root, Node p, Node q)
        {
            Result r = GetCommonAncestorResult(root, p, q);
            return r.IsAncestor ? r.Node : null;
        }

        [TestCase]
        public void TestSolution3()
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
            root.Left.Left = AddNewNode(4);
            root.Left.Right = AddNewNode(12);
            root.Left.Right.Left = AddNewNode(10);
            root.Left.Right.Right = AddNewNode(14);

            Node t = CommonAncestor(root, root.Right, root.Left);
            Assert.AreEqual(root, t); // 20

            t = CommonAncestor(root, root.Left.Left, root.Left.Right);
            Assert.AreEqual(root.Left, t); // 8
        }

        private class Node
        {
            public int Data;
            public Node Left;
            public Node Parent;
            public Node Right;
        }

        private class Result
        {
            public readonly bool IsAncestor;
            public readonly Node Node;

            public Result(Node n, bool isAncestor)
            {
                Node = n;
                IsAncestor = isAncestor;
            }
        }
    }
}