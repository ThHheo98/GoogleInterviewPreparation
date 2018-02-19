using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TwoPointers
{
    public class SortByColor
    {
        [Test]
        public void Test()
        {
            var list = new List<int> { 0, 1, 2, 0, 1, 2 };
            _3WayPart(list);
            Utils.PrintCollection(list);
        }

        public void _3WayPart(List<int> a)
        {
            var lo = 0;
            var hi = a.Count - 1;
            int mid = 0, temp;

            while (mid <= hi)
            {
                switch (a[mid])
                {
                    case 0:
                    {
                        temp = a[lo];
                        a[lo] = a[mid];
                        a[mid] = temp;
                        lo++;
                        mid++;
                        break;
                    }
                    case 1:
                        mid++;
                        break;
                    case 2:
                    {
                        temp = a[mid];
                        a[mid] = a[hi];
                        a[hi] = temp;
                        hi--;
                        break;
                    }
                }
            }
        }
    }
}
