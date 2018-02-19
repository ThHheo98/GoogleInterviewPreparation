using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch18
{
    /// <summary>
    ///     shuffle array
    /// </summary>
    public class Test182
    {
        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10})]
        public void Test(int[] a)
        {
            Misc.ShuffleKnuth.Shuffle(a);
            foreach (int t in a)
            {
                Console.Write(t + " ");
            }
        }
    }

    /// <summary>
    ///     http://www.dotnetperls.com/fisher-yates-shuffle
    ///     The Knuth (or Fisher-Yates) shuffling algorithm
    /// </summary>
    public static class ShuffleKnuth
    {
        public static void Shuffle<T>(T[] a)
        {
            var f = new Random((int) DateTime.Now.Ticks);
            for (int i = a.Length; i > 1; i--)
            {
                int j = f.Next(i); // 0 <= j <= i-1
                T t = a[j];
                a[j] = a[i - 1];
                a[i - 1] = t;
            }
        }
    }
}