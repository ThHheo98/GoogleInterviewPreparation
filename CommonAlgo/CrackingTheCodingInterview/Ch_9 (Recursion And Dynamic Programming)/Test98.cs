using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test98
    {
        [TestCase(100)]
        public void Test(int n)
        {
            int makeChange2 = MakeChange(n, 25);
            Console.WriteLine(makeChange2);
        }

        private static int MakeChange(int total, int denom)
        {
            int nextCoin;
            switch (denom)
            {
                case 25:
                    nextCoin = 10;
                    break;
                case 10:
                    nextCoin = 5;
                    break;
                case 5:
                    nextCoin = 1;
                    break;
                case 1:
                    return 1;
                default:
                    return 0;
            }
            int ways = 0;
            for (int count = 0; count*denom <= total; ++count)
                ways += MakeChange(total - count*denom, nextCoin);
            return ways;
        }
    }
}