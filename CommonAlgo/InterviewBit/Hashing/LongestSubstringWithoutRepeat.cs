using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Hashing
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/longest-substring-without-repeat/
    ///     https://leetcode.com/articles/longest-substring-without-repeating-characters/
    /// </summary>
    public class LongestSubstringWithoutRepeat
    {
        /*
         
Given a string, 
find the length of the longest substring without repeating characters.

Example:

The longest substring without repeating letters for "abcabcbb" is "abc", which the length is 3.

For "bbbbb" the longest substring is "b", with the length of 1.
Think in terms of two pointers. 
If you encounter a repeating character, you won’t be able to include the new character 
till you exclude out the previous occurrence of the character. Which means your window needs to shrink
 till your start character is pointing to the position next to previous occurrence of the character.

Also, note that the size of character set is small ( 128 at max ), so tracking the count of characters in the current set is fairly easy using hashing / array buckets.
             */
        [Test]
        public void Test()
        {
            var i = lengthOfLongestSubstring("abcabcd");
            Assert.AreEqual(4, i);
        }

        /// <summary>
        ///     Approach #3 Sliding Window Optimized [Accepted]
        ///     O(n) + O(min(m,n)).
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int lengthOfLongestSubstringOptimized(string s)
        {
            int n = s.Length, ans = 0;
            var map = new Dictionary<char, int>(); // current index of character
            // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++)
            {
                if (map.ContainsKey(s[j]))
                    i = Math.Max(map[s[j]], i);
                ans = Math.Max(ans, j - i + 1);
                map.Add(s[j], j + 1);
            }
            return ans;
        }

        /// <summary>
        ///     Approach #3 Sliding Window Optimized [Accepted]
        ///     O(n) + O(m) where m is size of charset.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int lengthOfLongestSubstringOptimized2(string s)
        {
            int n = s.Length, ans = 0;
            var index = new int[128]; // current index of character
            // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++)
            {
                i = Math.Max(index[s[j]], i);
                ans = Math.Max(ans, j - i + 1);
                index[s[j]] = j + 1;
            }
            return ans;
        }

        /// <summary>
        ///     Решение за O(2n) + O(min(len(a), size of alpabet))
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int lengthOfLongestSubstring(string a)
        {
            if (string.IsNullOrEmpty(a)) return 0;
            var hs = new HashSet<char>();

            var left = 0;
            var right = 0;
            var maxLen = int.MinValue;

            while (right < a.Length)
            {
                if (hs.Contains(a[right]))
                {
                    hs.Remove(a[left]);
                    left++;
                }
                else
                {
                    hs.Add(a[right]);
                    maxLen = Math.Max(maxLen, right - left + 1);
                    right++;
                }
            }
            return maxLen;
        }
    }
}
