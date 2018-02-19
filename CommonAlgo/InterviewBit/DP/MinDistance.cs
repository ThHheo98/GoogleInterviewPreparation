using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.DP
{
    public class MinDistance
    {
        [TestCase("ABC", "ABA")]
        public void Test(string a, string b)
        {
            // DP talbe, i is the position in word1, and j is the position in word2
            var dp = new int[a.Length + 1][];
            for (var i = 0;
                i < dp.Length;
                i++)
                dp[i] = new int[b.Length + 1];

            // when i or j=0 means empty string, the distance is the length of another string
            for (var i = 0;
                i < dp.Length;
                i++)
            {
                for (var j = 0;
                    j < dp[0].Length;
                    j++)
                {
                    if (i == 0)
                        dp[i][j] = j;
                    else if (j == 0)
                        dp[i][j] = i;
                }
            }

            Utils.PrintMatrix(dp);

            // if word1[i] == word2[j], then the distance of i and j is the previous i and j
            // otherwise we either replace, insert or delete a char
            // when insert a char to word1 it means we are trying to match word1 at i-1 to word2 at j
            // when delete a char from word1 it equals to insert a char to word2, which
            // means we are trying to match word1 at i to word2 at j-1
            // when replace a char to word1, then we add one step to previous i and j
            for (var i = 1;
                i < dp.Length;
                i++)
            {
                for (var j = 1;
                    j < dp[0].Length;
                    j++)
                {
                    if (a[i - 1] == b[j - 1])
                        dp[i][j] = dp[i - 1][j - 1];
                    else
                        dp[i][j] = 1 + Math.Min(dp[i - 1][j - 1], Math.Min(dp[i - 1][j],
                                       dp[i][j - 1]));
                }
            }
            Utils.PrintMatrix(dp);
            Console.WriteLine(dp[a.Length][b.Length]);
        }
    }
}
