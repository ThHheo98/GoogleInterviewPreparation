using System;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    public class LongestPolyndromicSubstring
    {
        [TestCase("aaaabaaa", Result = "aaabaaa")]
        public string Test(string text)
        {
            var longestPalindrome = LongestPalindromeManacherAlgorithm(text);

            return longestPalindrome;
        }

        [TestCase("aaaabaaa", Result = "aaabaaa")]
        public string Test1(string text)
        {
            var longestPalindrome = longestPalindromeSimple(text);

            return longestPalindrome;
        }

        /// <summary>
        ///     https://miafish.wordpress.com/2015/01/23/leetcode-oj-c-longest-palindromic-substring/
        ///     http://articles.leetcode.com/longest-palindromic-substring-part-i
        ///     http://articles.leetcode.com/longest-palindromic-substring-part-ii
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>

        #region Manacher Algo O(n)
        public string LongestPalindromeManacherAlgorithm(string s)
        {
            var res = string.Empty;
            var resLen = 0;

            var swithpounds = preprocess(s);

            Console.WriteLine(swithpounds);
            var maxR = 0;
            var maxC = 0;
            var dp = new int[swithpounds.Length];

            for (var i = 0;
                i < swithpounds.Length;
                i++)
            {
                dp[i] = maxR > i ? Math.Min(dp[2 * maxC - i], maxR - i) : 0;

                // attempt to expand it
                while (i + 1 + dp[i] < swithpounds.Length && i - 1 - dp[i] >= 0 && swithpounds[i + 1 + dp[i]] == swithpounds[i - 1 - dp[i]])
                    dp[i]++;

                if (dp[i] + i > maxR)
                {
                    maxR = dp[i] + i;
                    maxC = i;
                }

                if (dp[i] > resLen)
                {
                    resLen = dp[i];
                    res = s.Substring((i - dp[i]) / 2, resLen);
                }
            }

            return res;
        }

        private string preprocess(string s)
        {
            // http://codeforces.com/blog/entry/12143?locale=ru#comment-168015
            var stringbuilder = new StringBuilder();
            foreach (var ch in s)
            {
                stringbuilder.Append("#");
                stringbuilder.Append(ch);
            }

            stringbuilder.Append("#");

            return stringbuilder.ToString();
        }

        #endregion

        #region Simple O(n^2)

        private string expandAroundCenter(string s, int c1, int c2)
        {
            int l = c1, r = c2;
            var n = s.Length;
            while (l >= 0 && r <= n - 1 && s[l] == s[r])
            {
                l--;
                r++;
            }
            return s.Substring(l + 1, r - l - 1);
        }

        private string longestPalindromeSimple(string s)
        {
            var n = s.Length;
            if (n == 0)
                return "";
            var longest = s.Substring(0, 1); // a single char itself is a palindrome
            for (var i = 0;
                i < n - 1;
                i++)
            {
                var p1 = expandAroundCenter(s, i, i);
                if (p1.Length > longest.Length)
                    longest = p1;

                var p2 = expandAroundCenter(s, i, i + 1);
                if (p2.Length > longest.Length)
                    longest = p2;
            }
            return longest;
        }

        #endregion
    }
}
