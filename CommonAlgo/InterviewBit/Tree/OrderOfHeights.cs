using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Tree
{
    /// <summary>
    ///     http://qa.geeksforgeeks.org/3974/determine-the-actual-order-heights-google
    ///     https://www.interviewbit.com/problems/order-of-people-heights/
    /// </summary>
    public class OrderOfHeightsSegmentTree
    {
        private void BuildTree(Node root)
        {
            if (root.end - root.start <= 1) return;

            var mid = (root.start + root.end) / 2;

            root.left = new Node(root.start, mid);
            root.right = new Node(mid, root.end);

            BuildTree(root.left);
            BuildTree(root.right);
        }

        [SuppressMessage("ReSharper", "RedundantIfElseBlock")]
        private int GetPos(Node root, int inFrontValue)
        {
            root.space -= 1;
            if (root.left == null) return root.start;

            if (inFrontValue < root.left.space)
                return GetPos(root.left, inFrontValue);
            else
                return GetPos(root.right, inFrontValue - root.left.space);
        }

        public List<int> order(List<int> heights, List<int> inFront)
        {
            var res = new int[heights.Count];

            var root = new Node(0, heights.Count);
            BuildTree(root);

            var items = new List<Pair>();
            for (var i = 0;
                i < heights.Count;
                i++)
                items.Add(new Pair { height = heights[i], inFront = inFront[i] });

            // сортируем в таком порядке, чтобы первым на место в очереди вставал человек у котого меньший рост
            items = items.OrderBy(pair => pair).ToList();
            foreach (var item in items)
            {
                var pos = GetPos(root, item.inFront);
                res[pos] = item.height;
            }
            return res.ToList();
        }

        [Test]
        public void Test()
        {
            var heights = new List<int> { 5, 3, 2, 6, 1, 4 };
            var infront = new List<int> { 0, 1, 2, 0, 3, 2 };
            var result = order(heights, infront);

            foreach (var i in result)
                Console.Write(i + " ");

            var ans = new[] { 5, 3, 2, 1, 6, 4 };
            for (var i = 0;
                i < result.Count;
                i++)
                Assert.AreEqual(ans[i], result[i]);
        }

        private class Node
        {
            public readonly int end;

            public readonly int start;
            public Node left;
            public Node right;

            /// <summary>
            ///     Количество не занятых позиций
            ///     причем в паренте указывается сколько не занятых позиций в его чайлдах!!!
            /// </summary>
            public int space;

            public Node(int iStart, int iEnd)
            {
                start = iStart;
                end = iEnd;
                space = iEnd - iStart;
                left = null;
                right = null;
            }
        }

        private class Pair : IComparable<Pair>
        {
            public int height;
            public int inFront;

            #region Implementation of IComparable<in Pair>

            public int CompareTo(Pair other)
            {
                var r = height.CompareTo(other.height);
                if (r == 0)
                    r = inFront.CompareTo(other.inFront);
                return r;
            }

            #endregion
        }
    }
}
