using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch18
{
    public class Test186
    {
        /// <summary>
        ///     Для поиска решарпером
        /// </summary>
        public void OrderedStatisticNthElementKmaxKminWORKING()
        {
        }

        /// <summary>
        ///     Worst case O(n^2), in average O(n)
        ///     Суть ее заключается в том, что она выбирает произвольный элемент массива a, индекс которого находится в интервале
        ///     [lo, hi]  и ставит его на “свое место”, т.е. на то место, на котором находился элемент, если бы массив был
        ///     упорядочен.
        ///     See: k_stat_order.png
        ///     See: http://cppalgo.blogspot.ru/2011/09/k-on.html
        ///     See: http://www.cplusplus.com/reference/algorithm/nth_element
        ///     This is K Smallest impl.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="key"></param>
        private static int nth_element(int[] a, int key)
        {
            var lo = 0;
            var hi = a.Length - 1;
            while (true)
            {
                int k = RandomizedPartition(a, lo, hi);
                if (k < key) lo = k + 1;
                else if (k > key) hi = k - 1;
                else if (k == key) return a[k];
            }
        }

        /// <summary>
        ///     Return position of element in sorted array
        /// </summary>
        /// <param name="a"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <returns></returns>
        private static int RandomizedPartition(int[] a, int lo, int hi)
        {
            var p = lo + (new Random((int) DateTime.Now.Ticks)).Next(hi - lo + 1);
            Utils.Swap(a, p, hi);

            var x = a[hi];
            var i = lo - 1;
            for (int j = lo; j <=hi; j++)
            {
                if (a[j]<=x) Utils.Swap(a, j, ++i);
            }
            return i;
        }

        [TestCase(new[] {8, 4, 2, 1, 68, 9}, 0, Result = 1, TestName = "test1")]
        [TestCase(new[] {8, 4, 2, 1, 68, 9}, 2, Result = 4, TestName = "test2")]
        [TestCase(new[] {8, 10, 7, 9, 11, 6, 13}, 2, Result = 8, TestName = "test3")]
        public int OrderedStatistic(int[] a, int rank)
        {
            return nth_element(a, rank);
        }
    }
}