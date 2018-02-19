using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test51
    {
        private bool GetBit(int n, int i)
        {
            return (n & (1 << i)) != 0;
        }

        private int UpdateBit(int n, int i, int v)
        {
            int mask = ~(1 << i);
            return (n & mask) | (v << i);
        }


        [TestCase(1024, 19, 2, 6, Result = 1100, TestName = "test1")]
        [TestCase(1024, 18, 2, 6, Result = 1096, TestName = "test2")]
        [TestCase(1024, 18, 8, 6, Result = 0, TestName = "test3")]
        public int TestOwn(int n, int m, byte i, byte j)
        {
            int count = j - i + 1;
            if (count <= 0) return 0;

            for (byte k = 0; k < count; k++)
            {
                bool bit = GetBit(m, k);
                n = UpdateBit(n, i + k, bit ? 1 : 0);
            }
            Console.WriteLine(n);
            return n;
        }

        [TestCase(1024, 19, 2, 6, Result = 1100, TestName = "test1")]
        [TestCase(1024, 18, 2, 6, Result = 1096, TestName = "test2")]
        [TestCase(1024, 18, 8, 6, Result = 0, TestName = "test3")]
        public int TestSolution(int n, int m, byte i, byte j)
        {
            if (j - i <= 0) return 0;

            const int allOnes = ~0;
            int left = allOnes << (j + 1); //create left part of mask
            int right = (allOnes << i) - 1; //create right part of mask
            int mask = left | right; // // create mask
            int nCleared = n & mask; // clear bit in n from i to j
            int mShifted = m << i; // shift m to the appropriate position
            return nCleared | mShifted; // join n and m
        }
    }
}