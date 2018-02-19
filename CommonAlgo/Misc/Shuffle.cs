using System;
using NUnit.Framework;

namespace CommonAlgo.Misc
{
    /// <summary>
    ///     http://www.dotnetperls.com/fisher-yates-shuffle
    ///     The Knuth (or Fisher-Yates) shuffling algorithm
    /// </summary>
    public static class ShuffleKnuth
    {
        public static void Shuffle(int[] a)
        {
            var random = new Random((int) DateTime.Now.Ticks);
            for (int i = a.Length; i > 1; i--)
            {
                int j = random.Next(i);
                int t = a[i - 1];
                a[i - 1] = a[j];
                a[j] = t;
            }
        }
    }

    public class ShuffleTest
    {
        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10})]
        public void Test(int[] a)
        {
            ShuffleKnuth.Shuffle(a);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
        }
    }
}