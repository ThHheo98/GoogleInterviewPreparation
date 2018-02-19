using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.Misc
{
    public class GreyCode
    {
        [TestCase]
        public void GrayCode()
        {
            var n = 3;
            var arr = new List<int> { 0 };
            for (var i = 0; i < n; i++)
            {
                var inc = 1 << i;
                for (var j = arr.Count - 1; j >= 0; j--)
                {
                    var prev = arr[j];
                    arr.Add(prev + inc);
                }
            }
            foreach (var i in arr)
                Console.WriteLine(i);
        }

        [TestCase]
        public void Generate()
        {
            var n = 4;
            if (n == 0) return; // new List<IList<int>>();
            if (n == 1) return; // new List<IList<int>>() { new List<int> { 1 } };
            if (n == 2) return; // new List<IList<int>>() { new List<int> { 1 }, new List<int> { 1, 1 } };

            var r = new List<IList<int>> { new List<int> { 1 }, new List<int> { 1, 1 } };

            for (var k = 2; k < n; k++)
            {
                var item = new List<int> { 1 };
                r.Add(item);
                for (var j = 1; j < k; j++)
                {
                    var rr = r[k - 1][j - 1] + r[k - 1][j];
                    // Console.WriteLine(rr);
                    r[k].Add(rr);
                }
                item.Add(1);
            }
            // return r;
        }
    }
}
