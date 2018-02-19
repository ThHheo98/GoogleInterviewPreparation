using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/longest-common-prefix/
    /// </summary>
    public class LongestCommonPrefix
    {
        [Test]
        public void Test()
        {
            var a = new List<string> { "abcderf", "abcfdgdf", "abc" };
            var t = GetLongestCommonPrefix(a);
            Assert.AreEqual("abc", t);
        }

        public string GetLongestCommonPrefix(List<string> a)
        {
            if (a == null || a.Count == 0)
                return string.Empty;
            if (a.Count == 1)
                return a[0];

            var minl = int.MaxValue;
            foreach (var s in a)
                minl = Math.Min(minl, s.Length);

            var j = -1;
            var found = false;
            for (var i = 0;
                i < minl;
                i++)
            {
                var c = a[0][i];
                foreach (var s in a)
                {
                    if (c != s[i])
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                    j++;
            }

            return a[0].Substring(0, j + 1);
        }
    }
}
