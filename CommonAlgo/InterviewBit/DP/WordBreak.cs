using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.DP
{
    public class WordBreak
    {
        [TestCase("leetcode", new[] { "code", "leet" }, Result = true)]
        public bool WordBreakTest(string s, ICollection<string> dict)
        {
            var dp = new bool[s.Length + 1];
            dp[0] = true;
            for (var i = 1;
                i <= s.Length;
                i++)
            {
                for (var j = i - 1;
                    j >= 0;
                    j--)
                {
                    if (dp[j])
                    {
                        var word = s.Substring(j, i - j);
                        if (dict.Contains(word))
                        {
                            dp[i] = true;
                            break;
                        }
                    }
                }
            }
            return dp[s.Length];
        }
    }
}
