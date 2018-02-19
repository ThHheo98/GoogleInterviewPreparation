using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.DP
{
    public class RepeatingSubSequence
    {
        [TestCase("abba"), TestCase("abab")]
        public void Anytwo(string a)
        {
            var n = a.Length;
            var dp = new int[n + 1][];
            for (var i = 0;
                i < dp.Length;
                i++)
                dp[i] = new int[n + 1];

            for (var i = 1;
                i < n + 1;
                i++)
            {
                for (var j = i + 1;
                    j < n + 1;
                    j++)
                {
                    if (a[i - 1] == a[j - 1])
                        dp[i][j] = dp[i - 1][j - 1] + 1;
                    else
                        dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                }
            }

            for (var i = 0;
                i < n + 1;
                i++)
            {
                for (var j = 0;
                    j < n + 1;
                    j++)
                {
                    if (dp[i][j] > 1)
                    {
                        Console.WriteLine("true");
                        return;
                    }
                }
            }

            Console.WriteLine("false");
        }
    }
}
