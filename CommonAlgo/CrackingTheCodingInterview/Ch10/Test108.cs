using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch10
{
    public class RankNode
    {
        private readonly int _data;
        private RankNode _left;
        private int _leftSize;
        private RankNode _right;

        public RankNode(int d)
        {
            _data = d;
        }

        public void Insert(int d)
        {
            if (d <= _data)
            {
                if (_left != null)
                {
                    _left.Insert(d);
                }
                else
                {
                    _left = new RankNode(d);
                }
                _leftSize++;
            }
            else
            {
                if (_right != null)
                {
                    _right.Insert(d);
                }
                else
                {
                    _right = new RankNode(d);
                }
            }
        }

        public int GetRank(int d)
        {
            if (d == _data)
            {
                return _leftSize;
            }
            if (d < _data)
            {
                if (_left == null)
                {
                    return -1;
                }
                return _left.GetRank(d);
            }
            int rightRank = _right == null ? -1 : _right.GetRank(d);
            if (rightRank == -1)
            {
                return -1;
            }
            return _leftSize + 1 + rightRank;
        }
    }

    public class Test108
    {
        private static RankNode _root;

        private static void Track(int number)
        {
            if (_root == null)
            {
                _root = new RankNode(number);
            }
            else
            {
                _root.Insert(number);
            }
        }

        public static int GetRankOfNumber(int number)
        {
            return _root.GetRank(number);
        }

        [TestCase]
        public void Test()
        {
            const int size = 5;
            int[] list = AssortedMethods.RandomArray(size, -5, 5);
            foreach (int t in list)
            {
                Track(t);
            }

            var tracker = new int[size];
            foreach (int t in list)
            {
                int v = t;
                int rank1 = _root.GetRank(t);
                tracker[rank1] = v;
            }

            for (int i = 1; i < tracker.Length; i++)
            {
                if (tracker[i] == 0 || tracker[i - 1] == 0) continue;

                if (tracker[i] > tracker[i - 1])
                {
                    Console.WriteLine("ERROR at " + i);
                }
            }

            Console.WriteLine("Array: " + AssortedMethods.ArrayToString(list));
            Console.WriteLine("Ranks: " + AssortedMethods.ArrayToString(tracker));
        }
    }
}