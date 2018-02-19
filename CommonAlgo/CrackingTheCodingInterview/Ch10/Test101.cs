using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch10
{
    public class Test101
    {
        [TestCase(new[] {1, 2, 3, 4, 0, 0, 0, 0}, new[] {1, 2, 3, 4}, 4)]
        public void Test(int[] a, int[] b, int lastA)
        {
            Merge(a, b, lastA, b.Length);

            foreach (int i in a)
            {
                Console.Write(i + " ");
            }
        }

        private static void Merge(int[] a, int[] b, int lastA, int lastB)
        {
            int iA = lastA - 1;
            int iB = lastB - 1;

            int indexMerged = lastA + lastB - 1;

            while (iA >= 0 && iB >= 0)
            {
                if (a[iA] > b[iB])
                {
                    a[indexMerged] = a[iA];
                    indexMerged--;
                    iA--;
                }
                else
                {
                    a[indexMerged] = b[iB];
                    indexMerged--;
                    iB--;
                }
            }

            while (iB >= 0)
            {
                a[indexMerged] = b[iB];
                indexMerged--;
                iB--;
            }
        }
    }
}