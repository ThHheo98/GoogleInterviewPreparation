using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch18
{
    /// <summary>
    ///     Pick m elements from a array randomly
    /// </summary>
    public class Test183
    {
        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, 5)]
        public void Test(int[] a, int m)
        {
            IEnumerable<int> r = PickRandomly(a, m);
            foreach (int t in r)
            {
                Console.Write(t + " ");
            }
        }

        private static IEnumerable<int> PickRandomly(int[] a, int m)
        {
            var random = new Random((int) DateTime.Now.Ticks);

            var result = new int[m];
            var copy = new int[a.Length];
            Array.Copy(a, copy, a.Length);
            for (int i = 0; i < m; i++)
            {
                int index = random.Next(i, a.Length);
                result[i] = a[index];
                a[index] = a[i];
            }
            return result;
        }
    }
}