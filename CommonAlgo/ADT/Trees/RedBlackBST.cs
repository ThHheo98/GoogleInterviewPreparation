using System;
using System.Collections.Generic;

namespace CommonAlgo.ADT.Trees
{
    public class RedBlackBst<TKey, TValue> where TKey : class, IComparable where TValue : class
    {
        private const bool Red = true;
        private const bool Black = false;

        private Node _root; // root of the BST

        // BST helper node data type

        /*************************************************************************
    *  Node helper methods
    *************************************************************************/
        // is node x red; false if x is null ?
        private bool isRed(Node x)
        {
            if (x == null) return false;
            return (x.Color == Red);
        }

        // number of node in subtree rooted at x; 0 if x is null
        private int Size(Node x)
        {
            if (x == null) return 0;
            return x.N;
        }


        /*************************************************************************
    *  Size methods
    *************************************************************************/

        // return number of key-value pairs in this symbol table
        public int Size()
        {
            return Size(_root);
        }

        // is this symbol table empty?
        public bool IsEmpty()
        {
            return _root == null;
        }

        /*************************************************************************
    *  Standard BST search
    *************************************************************************/

        // value associated with the given key; null if no such key
        public TValue Get(TKey key)
        {
            return Get(_root, key);
        }

        // value associated with the given key in subtree rooted at x; null if no such key
        private TValue Get(Node x, TKey key)
        {
            while (x != null)
            {
                int cmp = key.CompareTo(x.Key);
                if (cmp < 0) x = x.Left;
                else if (cmp > 0) x = x.Right;
                else return x.Val;
            }
            return null;
        }

        // is there a key-value pair with the given key?
        public bool Contains(TKey key)
        {
            return (Get(key) != null);
        }

        // is there a key-value pair with the given key in the subtree rooted at x?
        private bool Contains(Node x, TKey key)
        {
            return (Get(x, key) != null);
        }

        /*************************************************************************
    *  Red-black insertion
    *************************************************************************/

        // insert the key-value pair; overwrite the old value with the new value
        // if the key is already present
        public void Put(TKey key, TValue val)
        {
            _root = Put(_root, key, val);
            _root.Color = Black;
            // assert check();
        }

        // insert the key-value pair in the subtree rooted at h
        private Node Put(Node h, TKey key, TValue val)
        {
            if (h == null) return new Node(key, val, Red, 1);

            int cmp = key.CompareTo(h.Key);
            if (cmp < 0) h.Left = Put(h.Left, key, val);
            else if (cmp > 0) h.Right = Put(h.Right, key, val);
            else h.Val = val;

            // fix-up any right-leaning links
            if (isRed(h.Right) && !isRed(h.Left)) h = RotateLeft(h);
            if (isRed(h.Left) && isRed(h.Left.Left)) h = RotateRight(h);
            if (isRed(h.Left) && isRed(h.Right)) flipColors(h);
            h.N = Size(h.Left) + Size(h.Right) + 1;

            return h;
        }

        /*************************************************************************
    *  Red-black deletion
    *************************************************************************/

        // delete the key-value pair with the minimum key
        public void DeleteMin()
        {
            if (IsEmpty()) throw new InvalidOperationException("BST underflow");

            // if both children of root are black, set root to red
            if (!isRed(_root.Left) && !isRed(_root.Right))
                _root.Color = Red;

            _root = DeleteMin(_root);
            if (!IsEmpty()) _root.Color = Black;
            // assert check();
        }

        // delete the key-value pair with the minimum key rooted at h
        private Node DeleteMin(Node h)
        {
            if (h.Left == null)
                return null;

            if (!isRed(h.Left) && !isRed(h.Left.Left))
                h = MoveRedLeft(h);

            h.Left = DeleteMin(h.Left);
            return Balance(h);
        }


        // delete the key-value pair with the maximum key
        public void DeleteMax()
        {
            if (IsEmpty()) throw new InvalidOperationException("BST underflow");

            // if both children of root are black, set root to red
            if (!isRed(_root.Left) && !isRed(_root.Right))
                _root.Color = Red;

            _root = DeleteMax(_root);
            if (!IsEmpty()) _root.Color = Black;
            // assert check();
        }

        // delete the key-value pair with the maximum key rooted at h
        private Node DeleteMax(Node h)
        {
            if (isRed(h.Left))
                h = RotateRight(h);

            if (h.Right == null)
                return null;

            if (!isRed(h.Right) && !isRed(h.Right.Left))
                h = MoveRedRight(h);

            h.Right = DeleteMax(h.Right);

            return Balance(h);
        }

        // delete the key-value pair with the given key
        public void Delete(TKey key)
        {
            if (!Contains(key))
            {
                Console.WriteLine("symbol table does not contain " + key);
                return;
            }

            // if both children of root are black, set root to red
            if (!isRed(_root.Left) && !isRed(_root.Right))
                _root.Color = Red;

            _root = Delete(_root, key);
            if (!IsEmpty()) _root.Color = Black;
            // assert check();
        }

        // delete the key-value pair with the given key rooted at h
        private Node Delete(Node h, TKey key)
        {
            // assert contains(h, key);

            if (key.CompareTo(h.Key) < 0)
            {
                if (!isRed(h.Left) && !isRed(h.Left.Left))
                    h = MoveRedLeft(h);
                h.Left = Delete(h.Left, key);
            }
            else
            {
                if (isRed(h.Left))
                    h = RotateRight(h);
                if (key.CompareTo(h.Key) == 0 && (h.Right == null))
                    return null;
                if (!isRed(h.Right) && !isRed(h.Right.Left))
                    h = MoveRedRight(h);
                if (key.CompareTo(h.Key) == 0)
                {
                    Node x = Min(h.Right);
                    h.Key = x.Key;
                    h.Val = x.Val;
                    // h.val = get(h.right, min(h.right).key);
                    // h.key = min(h.right).key;
                    h.Right = DeleteMin(h.Right);
                }
                else h.Right = Delete(h.Right, key);
            }
            return Balance(h);
        }

        /*************************************************************************
    *  red-black tree helper functions
    *************************************************************************/

        // make a left-leaning link lean to the right
        private Node RotateRight(Node h)
        {
            // assert (h != null) && isRed(h.left);
            Node x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = x.Right.Color;
            x.Right.Color = Red;
            x.N = h.N;
            h.N = Size(h.Left) + Size(h.Right) + 1;
            return x;
        }

        // make a right-leaning link lean to the left
        private Node RotateLeft(Node h)
        {
            // assert (h != null) && isRed(h.right);
            Node x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = x.Left.Color;
            x.Left.Color = Red;
            x.N = h.N;
            h.N = Size(h.Left) + Size(h.Right) + 1;
            return x;
        }

        // flip the colors of a node and its two children
        private void flipColors(Node h)
        {
            // h must have opposite color of its two children
            // assert (h != null) && (h.left != null) && (h.right != null);
            // assert (!isRed(h) &&  isRed(h.left) &&  isRed(h.right))
            //     || (isRed(h)  && !isRed(h.left) && !isRed(h.right));
            h.Color = !h.Color;
            h.Left.Color = !h.Left.Color;
            h.Right.Color = !h.Right.Color;
        }

        // Assuming that h is red and both h.left and h.left.left
        // are black, make h.left or one of its children red.
        private Node MoveRedLeft(Node h)
        {
            // assert (h != null);
            // assert isRed(h) && !isRed(h.left) && !isRed(h.left.left);

            flipColors(h);
            if (isRed(h.Right.Left))
            {
                h.Right = RotateRight(h.Right);
                h = RotateLeft(h);
            }
            return h;
        }

        // Assuming that h is red and both h.right and h.right.left
        // are black, make h.right or one of its children red.
        private Node MoveRedRight(Node h)
        {
            // assert (h != null);
            // assert isRed(h) && !isRed(h.right) && !isRed(h.right.left);
            flipColors(h);
            if (isRed(h.Left.Left))
            {
                h = RotateRight(h);
            }
            return h;
        }

        // restore red-black tree invariant
        private Node Balance(Node h)
        {
            // assert (h != null);

            if (isRed(h.Right)) h = RotateLeft(h);
            if (isRed(h.Left) && isRed(h.Left.Left)) h = RotateRight(h);
            if (isRed(h.Left) && isRed(h.Right)) flipColors(h);

            h.N = Size(h.Left) + Size(h.Right) + 1;
            return h;
        }


        /*************************************************************************
    *  Utility functions
    *************************************************************************/

        // height of tree (1-node tree has height 0)
        public int Height()
        {
            return Height(_root);
        }

        private int Height(Node x)
        {
            if (x == null) return -1;
            return 1 + Math.Max(Height(x.Left), Height(x.Right));
        }

        /*************************************************************************
    *  Ordered symbol table methods.
    *************************************************************************/

        // the smallest key; null if no such key
        public TKey Min()
        {
            if (IsEmpty()) return null;
            return Min(_root).Key;
        }

        // the smallest key in subtree rooted at x; null if no such key
        private Node Min(Node x)
        {
            // assert x != null;
            if (x.Left == null) return x;
            return Min(x.Left);
        }

        // the largest key; null if no such key
        public TKey Max()
        {
            if (IsEmpty()) return null;
            return Max(_root).Key;
        }

        // the largest key in the subtree rooted at x; null if no such key
        private Node Max(Node x)
        {
            // assert x != null;
            if (x.Right == null) return x;
            return Max(x.Right);
        }

        // the largest key less than or equal to the given key
        public TKey Floor(TKey key)
        {
            Node x = Floor(_root, key);
            if (x == null) return null;
            return x.Key;
        }

        // the largest key in the subtree rooted at x less than or equal to the given key
        private Node Floor(Node x, TKey key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.Key);
            if (cmp == 0) return x;
            if (cmp < 0) return Floor(x.Left, key);
            Node t = Floor(x.Right, key);
            if (t != null) return t;
            return x;
        }

        // the smallest key greater than or equal to the given key
        public TKey Ceiling(TKey key)
        {
            Node x = Ceiling(_root, key);
            if (x == null) return null;
            return x.Key;
        }

        // the smallest key in the subtree rooted at x greater than or equal to the given key
        private Node Ceiling(Node x, TKey key)
        {
            if (x == null) return null;
            int cmp = key.CompareTo(x.Key);
            if (cmp == 0) return x;
            if (cmp > 0) return Ceiling(x.Right, key);
            Node t = Ceiling(x.Left, key);
            if (t != null) return t;
            return x;
        }


        // the key of rank k
        public TKey Select(int k)
        {
            if (k < 0 || k >= Size()) return null;
            Node x = Select(_root, k);
            return x.Key;
        }

        // the key of rank k in the subtree rooted at x
        private Node Select(Node x, int k)
        {
            // assert x != null;
            // assert k >= 0 && k < size(x);
            int t = Size(x.Left);
            if (t > k) return Select(x.Left, k);
            if (t < k) return Select(x.Right, k - t - 1);
            return x;
        }

        // number of keys less than key
        public int Rank(TKey key)
        {
            return Rank(key, _root);
        }

        // number of keys less than key in the subtree rooted at x
        private int Rank(TKey key, Node x)
        {
            if (x == null) return 0;
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0) return Rank(key, x.Left);
            if (cmp > 0) return 1 + Size(x.Left) + Rank(key, x.Right);
            return Size(x.Left);
        }

        /***********************************************************************
    *  Range count and range search.
    ***********************************************************************/


        // add the keys between lo and hi in the subtree rooted at x
        // to the queue
        private void Keys(Node x, Queue<TKey> queue, TKey lo, TKey hi)
        {
            if (x == null) return;
            int cmplo = lo.CompareTo(x.Key);
            int cmphi = hi.CompareTo(x.Key);
            if (cmplo < 0) Keys(x.Left, queue, lo, hi);
            if (cmplo <= 0 && cmphi >= 0) queue.Enqueue(x.Key);
            if (cmphi > 0) Keys(x.Right, queue, lo, hi);
        }

        // number keys between lo and hi
        public int Size(TKey lo, TKey hi)
        {
            if (lo.CompareTo(hi) > 0) return 0;
            if (Contains(hi)) return Rank(hi) - Rank(lo) + 1;
            return Rank(hi) - Rank(lo);
        }


        /*************************************************************************
    *  Check integrity of red-black BST data structure
    *************************************************************************/

        private bool Check()
        {
            if (!IsBst()) Console.WriteLine("Not in symmetric order");
            if (!IsSizeConsistent()) Console.WriteLine("Subtree counts not consistent");

            if (!Is23()) Console.WriteLine("Not a 2-3 tree");
            if (!IsBalanced()) Console.WriteLine("Not balanced");
            return IsBst() && IsSizeConsistent() && Is23() && IsBalanced();
        }

        // does this binary tree satisfy symmetric order?
        // Note: this Test also ensures that data structure is a binary tree since order is strict
        private bool IsBst()
        {
            return IsBst(_root, null, null);
        }

        // is the tree rooted at x a BST with all keys strictly between min and max
        // (if min or max is null, treat as empty constraint)
        // Credit: Bob Dondero's elegant solution
        private bool IsBst(Node x, TKey min, TKey max)
        {
            if (x == null) return true;
            if (min != null && x.Key.CompareTo(min) <= 0) return false;
            if (max != null && x.Key.CompareTo(max) >= 0) return false;
            return IsBst(x.Left, min, x.Key) && IsBst(x.Right, x.Key, max);
        }

        // are the size fields correct?
        private bool IsSizeConsistent()
        {
            return IsSizeConsistent(_root);
        }

        private bool IsSizeConsistent(Node x)
        {
            if (x == null) return true;
            if (x.N != Size(x.Left) + Size(x.Right) + 1) return false;
            return IsSizeConsistent(x.Left) && IsSizeConsistent(x.Right);
        }


        // Does the tree have no red right links, and at most one (left)
        // red links in a row on any path?
        private bool Is23()
        {
            return Is23(_root);
        }

        private bool Is23(Node x)
        {
            if (x == null) return true;
            if (isRed(x.Right)) return false;
            if (x != _root && isRed(x) && isRed(x.Left))
                return false;
            return Is23(x.Left) && Is23(x.Right);
        }

        // do all paths from root to leaf have same number of black edges?
        private bool IsBalanced()
        {
            int black = 0; // number of black links on path from root to min
            Node x = _root;
            while (x != null)
            {
                if (!isRed(x)) black++;
                x = x.Left;
            }
            return IsBalanced(_root, black);
        }

        // does every path from the root to a leaf have the given number of black links?
        private bool IsBalanced(Node x, int black)
        {
            if (x == null) return black == 0;
            if (!isRed(x)) black--;
            return IsBalanced(x.Left, black) && IsBalanced(x.Right, black);
        }

        private class Node
        {
            public bool Color; // color of parent link
            public TKey Key; // key
            public Node Left; // links to left and right subtrees
            public int N; // subtree count
            public Node Right; // links to left and right subtrees
            public TValue Val; // associated data

            public Node(TKey key, TValue val, bool color, int N)
            {
                Key = key;
                Val = val;
                Color = color;
                this.N = N;
            }
        }


        /*****************************************************************************
    *  TestIneffective client
    *****************************************************************************/
        /*public static void main(String[] args) { 
        RedBlackBST<String, Integer> st = new RedBlackBST<String, Integer>();
        for (int i = 0; !StdIn.isEmpty(); i++) {
            String key = StdIn.readString();
            st.put(key, i);
        }
        for (String s : st.keys())
            StdOut.println(s + " " + st.get(s));
        StdOut.println();
    }*/
    }
}