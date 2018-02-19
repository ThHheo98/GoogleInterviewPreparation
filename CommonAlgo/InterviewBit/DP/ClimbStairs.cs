using NUnit.Framework;

namespace CommonAlgo.InterviewBit.DP
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/stairs/
    ///     https://leetcode.com/problems/climbing-stairs/
    /// </summary>
    public class ClimbStairs
    {
        [TestCase(3, Result = 3)]
        public int ClimbStairsTest1(int n)
        {
            // up to bottom
            var dp = new int[n + 1];
            for (var i = 0;
                i < dp.Length;
                i++)
                dp[i] = -1;

            return ClimbStairsTest1Rec(n, dp);
        }

        private int ClimbStairsTest1Rec(int n, int[] dp)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            if (dp[n] != -1)
                return dp[n];
            dp[n] = ClimbStairsTest1Rec(n - 1, dp) + ClimbStairsTest1Rec(n - 2, dp);
            return dp[n];
        }

        [TestCase(3, Result = 3)]
        public int ClimbStairsTest2(int n)
        {
            var dp = new int[1000];
            dp[0] = 1;
            dp[1] = 1;
            for (var i = 2;
                i <= n;
                i++)
                dp[i] = dp[i - 1] + dp[i - 2];
            return dp[n];
        }
    }
}
