using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Maths
{
    public class PowerOf2Int
    {
        [TestCase(4, Result = 1)]
        public int isPower(int a)
        {
            var r = pot(a);
            return r ? 1 : 0;
        }

        private bool pot(int n)
        {
            if (n <= 1)
                return true;
            for (var i = 2;
                i <= Math.Sqrt(n) && i < int.MaxValue / i;
                ++i)
            {
                var p = i;
                while (p <= n && p < int.MaxValue / i)
                {
                    p *= i;
                    if (p == n)
                        return true;
                }
            }
            return false;
        }
    }
}
