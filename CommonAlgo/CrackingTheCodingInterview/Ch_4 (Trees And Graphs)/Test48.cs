using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    /// <summary>
    ///     Find Subtree T2 in T1 (T1 has a million of nodes)
    /// </summary>
    public class Test48
    {
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

            Assert.IsTrue(ContainsTree(bigTree, subTree));
            Assert.IsFalse(ContainsTree(subTree, bigTree));
        }

        private bool ContainsTree(Node t1, Node t2)
        {
            return t2 == null // null is subtree of any tree always
                   || SubTree(t1, t2);
        }

        private bool SubTree(Node r1, Node r2)
        {
            if (r1 == null)
            {
                return false;
            }
            if (r1.Data == r2.Data)
            {
                if (IsTreeMatch(r1, r2))
                    return true;
            }
            return SubTree(r1.Left, r2) || SubTree(r1.Right, r2);
        }

        private bool IsTreeMatch(Node r1, Node r2)
        {
            if (r2 == null && r1 == null) return true;

            if (r2 == null || r1 == null) return false;

            if (r1.Data != r2.Data) return false;

            return IsTreeMatch(r1.Left, r2.Left) && IsTreeMatch(r1.Right, r2.Right);
        }

        private class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
        }
    }
}