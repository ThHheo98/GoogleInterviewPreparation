using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.DP
{
    /*
     Given a string s, partition s such that every substring of the partition is a palindrome.

Return the minimum cuts needed for a palindrome partitioning of s.

Example : 
Given 
s = "aab",
Return 1 since the palindrome partitioning ["aa","b"] could be produced using 1 cut.
       */

    public class PalindromePartitioning2
    {
        [TestCase("AAB", Result = 1)]
        public int MinCut(string s)
        {
            var n = s.Length;

            var dp = new bool[n, n];
            var cut = new int[n];

            for (var j = 0;
                j < n;
                j++)
            {
                cut[j] = j; // set maximum # of cuts
                for (var i = 0;
                    i <= j;
                    i++)
                {
                    if (s[i] == s[j] && (j - i <= 1 || dp[i + 1, j - 1]))
                    {
                        dp[i, j] = true;
                        if (i > 0)
                            cut[j] = Math.Min(cut[j], cut[i - 1] + 1);
                        else
                            cut[j] = 0;
                    }
                }
            }
            return cut[n - 1];
        }
    }
}
