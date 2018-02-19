using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BinarySearch
{
    public class MatrixMedian
    {
        [Test]
        public void Test()
        {
            var matr = new List<List<int>>();
            for (var i = 0;
                i < 3;
                i++)
                matr.Add(new List<int>());

            matr[0].Add(1);
            matr[0].Add(3);
            matr[0].Add(5);

            matr[1].Add(2);
            matr[1].Add(6);
            matr[1].Add(9);

            matr[2].Add(3);
            matr[2].Add(6);
            matr[2].Add(9);

            Utils.PrintMatrix(matr);

            var m = findMedian(matr);
            Assert.AreEqual(5, m);
        }

        private static int BinarySearch(IList<int> list, int mid)
        {
            //if (mid >= list.Count) return list.Count;

            var comp = Comparer<int>.Default;

            int lo = 0, hi = list.Count - 1;

            var value = list[mid];

            while (lo < hi)
            {
                var m = lo + (hi - lo) / 2;

                if (comp.Compare(list[m], value) < 0)
                    lo = m + 1;
                else
                    hi = m - 1;
            }

            if (lo <= list.Count) return list[lo];

            if (comp.Compare(list[lo], value) < 0)
                lo++;

            return lo >= list.Count ? lo : list[lo];
        }

        public int findMedian(List<List<int>> a)
        {
            var n = a.Count;
            var m = a[0].Count;

            var l = 0;
            var r = int.MaxValue;

            var req = n * m;

            while (r - l > 1)
            {
                var mid = l + (r - l) / 2;

                var cnt = 0;
                for (var i = 0;
                    i < n;
                    i++)
                {
                    var idx = BinarySearch(a[i], mid);
                    var p = idx;
                    cnt += p;
                }
                Console.WriteLine(cnt + " " + l + " " + r);
                if (cnt >= req / 2 + 1)
                    r = mid;
                else
                    l = mid;
            }
            return r;
        }
    }
}
