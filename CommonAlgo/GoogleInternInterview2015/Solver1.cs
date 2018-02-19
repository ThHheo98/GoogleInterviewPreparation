using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.GoogleInternInterview2015
{
    ///http://www.programcreek.com/2013/01/leetcode-longest-consecutive-sequence-java/
    public class Solver1
    {
        [TestCase]
        public void Test()
        {
          //  var a = new[] { 100, 4, 200, 1, 3, 2 };
          //  Assert.AreEqual(LongestConsecutiveSequence(a), 4);
            var b = new [] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.AreEqual(LongestConsecutiveSequence(b), 9);
        }

        public static int LongestConsecutiveSequence(int[] a)
        {
            if (a.Length == 0)
            {
                return 0;
            }

            var set = new HashSet<int>();
            var max = 1;

            foreach (var e in a)
            {
                set.Add(e);
            }

            foreach (var e in a)
            {
                var left = e - 1;
                var right = e + 1;
                var count = 1;

                while (set.Contains(left))
                {
                    count++;
                    set.Remove(left);
                    left--;
                }

                while (set.Contains(right))
                {
                    count++;
                    set.Remove(right);
                    right++;
                }

                max = Math.Max(count, max);
            }

            return max;
        }
    }
}
