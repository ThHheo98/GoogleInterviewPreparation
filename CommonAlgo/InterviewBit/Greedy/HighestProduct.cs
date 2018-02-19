using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Greedy
{
    public class HighestProduct
    {
        private void sort(ref List<int> a)
        {
            a = a.OrderBy(i => i).ToList();
        }

        [TestCase]
        public void Maxp3()
        {
            var a = new List<int> { 110, 100, 90 };
            var count = a.Count;

            sort(ref a);
            Utils.PrintCollection(a);

            var max = a[count - 3] * a[count - 2] * a[count - 1];
            max = Math.Max(a[0] * a[1] * a[count - 1], max);
        }
    }
}
