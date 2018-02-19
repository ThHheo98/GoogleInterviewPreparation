using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit
{
    public class WaveArraySort
    {
        /// <summary>
        ///     O(nlogn) solution
        /// </summary>
        /// <param name="a"></param>
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void WaveSortTest1(int[] a)
        {
            Array.Sort(a);

            for (var i = 0;
                i < a.Length - 1;
                i += 2)
                Utils.Swap(ref a[i], ref a[i + 1]);
            Utils.PrintCollection(a);
        }

        /// <summary>
        ///     O(n) solution
        /// </summary>
        /// <param name="a"></param>
        [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        public void WaveSortTest2(int[] a)
        {
            var nthElement = Utils.NthElement(a, a.Length / 2);
            var element = a[nthElement];

            var odd = 1;
            var even = 0;
            var r = new int[a.Length];
            for (var i = 0;
                i < a.Length;
                i++)
            {
                if (a[i] <= element)
                {
                    r[even] = a[i];
                    even += 2;
                }
                else
                {
                    r[odd] = a[i];
                    odd += 2;
                }
            }

            Utils.PrintCollection(r);
        }
    }
}
