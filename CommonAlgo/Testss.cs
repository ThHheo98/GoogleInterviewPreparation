using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo
{
    public class Testss
    {
        [TestCase]
        public void Test()
        {
            var e = new List<List<int>>();

            var l1 = new List<int> {1, 2};
            var l2 = new List<int> {3, 4};

            e.Add(l1);
            e.Add(l2);


            _2DimToOne(e);
        }

        private void _2DimToOne(IEnumerable<IEnumerable<int>> v)
        {
            var r = new List<int>();
            foreach (var v1 in v)
            {
                foreach (var i in v1)
                {
                    r.Add(i);
                }
            }
            foreach (var i in r)
            {
                Console.WriteLine(i);
            }
        }

        [TestCase("54321")]
        public void ReverseString(string s)
        {
            var ca = s.ToCharArray();
            var l = 0;
            var r = ca.Length - 1;

            while (l < r)
            {
                var t = ca[l];
                ca[l] = ca[r];
                ca[r] = t;

                l++;
                r--;
            }
            Console.WriteLine(s);
            Console.WriteLine(new string(ca));
        }

        private bool IsOverlap(Point l1, Point r1, Point l2, Point r2)
        {
            // If one rectangle is on left side of other
            if (l1.x > r2.x || l2.x > r1.x)
                return false;

            // If one rectangle is above other
            if (l1.y < r2.y || l2.y < r1.y)
                return false;
            return true;
        }

        private struct Point
        {
            public int x;
            public int y;
        }
    }
}