using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.ADT.Trees
{
    public class SimpleTree<TKey, TValue> : ITree<TKey, TValue> where TKey : IComparable where TValue : IComparable
    {
        private Node _root;

        public SimpleTree()
        {
            _root = null;
        }

        public void Traverse(TraverseOrder traverseOrder)
        {
            switch (traverseOrder)
            {
                case TraverseOrder.PreOrder: // прямой
                    PreOrderPrint(_root);
                    break;
                case TraverseOrder.InOrder:
                    InOrderPrint(_root);
                    break;
                case TraverseOrder.InOrderReverse:
                    InOrderPrintReverse(_root);
                    break;
                case TraverseOrder.PostOrder:
                    PostOrderPrint(_root);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("traverseOrder");
            }
        }

        public void Add(TKey key, TValue item)
        {
            _root = Add(_root, key, item);
        }

        public void Remove(TValue item)
        {
            throw new NotImplementedException();
        }

        public TValue Find(TKey key)
        {
            Node t = _root;
            while (t != null)
            {
                if (t.Key.CompareTo(key) == 0) return t.Item;

                t = key.CompareTo(t.Key) < 0 ? t.Left : t.Right;
            }
            return default(TValue);
        }

        /// <summary>
        ///     remove a value from the tree, if it exists
        /// </summary>
        /// <param name="key">key such that value.compareTo(key) == 0 for the node to remove</param>
        public void Remove(TKey key)
        {
            _root = Remove(_root, key);
        }

        public TKey GetMaximumKey()
        {
            return GetMaximumKeyInternal(_root);
        }

        public TKey GetMinimumKey()
        {
            return GetMinimumKeyInternal(_root);
        }

        public TValue GetMinimumValue()
        {
            return GetMinimumValue(_root);
        }

        public TValue GetMaximumValue()
        {
            return GetRightmost(_root);
        }

        public TKey Floor(TKey key)
        {
            Node x = Floor(_root, key);
            if (x == null) return default(TKey);
            return x.Key;
        }

        public TKey Ceil(TKey key)
        {
            Node x = Ceil(_root, key);
            if (x == null) return default(TKey);
            return x.Key;
        }

        public void BFS()
        {
            BFS(_root);
        }

        public void DFS()
        {
            DFS(_root);
        }

        private void InOrderPrintReverse(Node node)
        {
            if (node == null) return;
            InOrderPrintReverse(node.Left);
            Console.Write(node + " ");
            InOrderPrintReverse(node.Right);
        }

        private void PreOrderPrint(Node node)
        {
            if (node == null)
                return;
            Console.Write(node + " ");
            PreOrderPrint(node.Left);
            PreOrderPrint(node.Right);
        }

        private void InOrderPrint(Node node)
        {
            if (node == null)
                return;
            InOrderPrint(node.Left);
            Console.Write(node + " ");
            InOrderPrint(node.Right);
        }

        private void PostOrderPrint(Node node)
        {
            if (node == null)
                return;
            PostOrderPrint(node.Left);
            PostOrderPrint(node.Right);
            Console.Write(node + " ");
        }

        private void BFS(Node node)
        {
            var queue = new Queue<Node>();

            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                node = queue.Dequeue();
                Console.Write(node + " ");
                if (node.Left != null) 
                    queue.Enqueue(node.Left);
                if (node.Right != null) 
                    queue.Enqueue(node.Right);
            }
        }

        private void DFS(Node node)
        {
            var stack = new Stack<Node>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                node = stack.Pop();
                Console.Write(node + " ");

                if (node.Right != null)
                    stack.Push(node.Right);
                if (node.Left != null)
                    stack.Push(node.Left);
            }
        }


        private Node Floor(Node node, TKey key)
        {
            if (node == null) return null;
            int cmp = key.CompareTo(node.Key);
            if (cmp == 0) return node;
            if (cmp < 0)
            {
                return Floor(node.Left, key);
            }
            Node t = Floor(node.Right, key);
            if (t != null) return t;
            return node;
        }

        private Node Ceil(Node node, TKey key)
        {
            if (node == null) return null;
            int cmp = key.CompareTo(node.Key);
            if (cmp == 0) return node;
            if (cmp > 0)
            {
                return Ceil(node.Right, key);
            }
            Node t = Ceil(node.Left, key);
            if (t != null) return t;
            return node;
        }

        private Node Add(Node root, TKey key, TValue item)
        {
            if (root == null) return new Node(item, key);

            int cmp = root.Key.CompareTo(key);

            if (cmp == 0)
                root.Item = item;
            else if (cmp < 0)
                root.Right = Add(root.Right, key, item);
            else
                root.Left = Add(root.Left, key, item);
            return root;
        }

        private TKey GetMaximumKeyInternal(Node node)
        {
            Node right = node.Right;
            if (right == null)
                return node.Key;
            return GetMaximumKeyInternal(right);
        }

        private TKey GetMinimumKeyInternal(Node node)
        {
            Node left = node.Left;
            if (left == null)
                return node.Key;
            return GetMinimumKeyInternal(left);
        }

        private Node Remove(Node node, TKey key)
        {
            if (node == null) // key not in tree
                return null;

            int cmp = node.Key.CompareTo(key);
            if (cmp == 0) // we found the node // remove this node
            {
                if (node.Left == null) return node.Right; // replace this node with right child
                if (node.Right == null) return node.Left; // replace with left child
                // replace the value in this node with the value in the
                // rightmost node of the left subtree
                node.Item = GetRightmost(node.Left);
                // now remove the rightmost node in the left subtree,
                // by calling "remove" recursively
                node.Left = Remove(node.Left, node.Key);
                // return node;  -- done below
            }
            else // we not found the node, then we should go deeper :)
                // remove from left or right subtree
            {
                if (cmp > 0) // remove from left subtree
                    node.Right = Remove(node.Right, key);
                else // remove from right subtree
                    node.Left = Remove(node.Left, key);
            }
            return node;
        }

        private TValue GetRightmost(Node node)
        {
            Node right = node.Right;
            if (right == null)
                return node.Item;
            return GetRightmost(right);
        }

        private TValue GetMinimumValue(Node node)
        {
            Node left = node.Left;
            if (left == null)
                return node.Item;
            return GetMinimumValue(left);
        }

        private class Node : IComparable
        {
            public Node(TValue item, TKey key)
            {
                Left = null;
                Right = null;
                Item = item;
                Key = key;
            }

            public TKey Key { get; set; }
            public TValue Item { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            #region Overrides of Object

            public int CompareTo(object obj)
            {
                var value = (TValue) obj;
                return value.CompareTo(Item);
            }

            public override string ToString()
            {
                return string.Format("{0} ", Key, Item);
            }

            #endregion
        }
    }

    public class SimpleTreeTestClass
    {
        [Test]
        public void SimpleTreeTest()
        {
            var q = new SimpleTree<int, string>();
            q.Add(1, "test1");
            q.Add(2, "test2");
            string item = q.Find(1);
            Assert.AreEqual(item, "test1");
            item = q.Find(2);
            Assert.AreEqual(item, "test2");
            q.Remove(1);
            item = q.Find(1);
            Assert.AreEqual(null, item);
            item = q.Find(2);
            Assert.AreEqual("test2", item);
        }

        [Test]
        public void SimpleTreeGetMaxMinKeyTest()
        {
            var t = new SimpleTree<int, string>();
            t.Add(1, "test1");
            t.Add(2, "test2");

            int maximumKey = t.GetMaximumKey();
            Assert.AreEqual(2, maximumKey);

            int minKey = t.GetMinimumKey();
            Assert.AreEqual(1, minKey);
        }

        [Test]
        public void SimpleTreeGetMaxMinValueValue()
        {
            var t = new SimpleTree<int, int>();
            t.Add(1, 123);
            t.Add(2, 999);

            int maximumValue = t.GetMaximumValue();
            Assert.AreEqual(999, maximumValue);

            int minimumValue = t.GetMinimumValue();
            Assert.AreEqual(123, minimumValue);
        }

        [Test]
        public void SimpleTreeFloorCeilValue()
        {
            var t = new SimpleTree<int, int>();
            t.Add(6, 123);
            t.Add(8, 123);
            t.Add(4, 123);
            t.Add(1, 123);
            t.Add(3, 123);

            int ceil = t.Ceil(7); // nearest upper
            Assert.AreEqual(8, ceil);

            int floor = t.Floor(7); // nearest bottom
            Assert.AreEqual(6, floor);
        }

        [Test]
        public void SimpleTreeTraversing()
        {
            var t = new SimpleTree<int, int>();
            t.Add(6, 123);
            t.Add(9, 123);
            t.Add(3, 123);
            t.Add(4, 123);
            t.Add(1, 123);
            t.Add(7, 123);
            t.Add(10, 123);

            t.Traverse(TraverseOrder.PreOrder);
            Console.WriteLine();
            t.Traverse(TraverseOrder.InOrder);
            Console.WriteLine();
            t.Traverse(TraverseOrder.InOrderReverse);
            Console.WriteLine();
            t.Traverse(TraverseOrder.PostOrder);
            Console.WriteLine();
        }


        [Test]
        public void SimpleTreeDFS()
        {
            var t = new SimpleTree<int, int>();
            t.Add(6, 123);
            t.Add(9, 123);
            t.Add(3, 123);
            t.Add(4, 123);
            t.Add(1, 123);
            t.Add(7, 123);
            t.Add(10, 123);

            t.DFS();
        }

        [Test]
        public void SimpleTreeBFS()
        {
            var t = new SimpleTree<int, int>();
            t.Add(6, 123);
            t.Add(9, 123);
            t.Add(3, 123);
            t.Add(4, 123);
            t.Add(1, 123);
            t.Add(7, 123);
            t.Add(10, 123);

            t.BFS();
        }
    }
}