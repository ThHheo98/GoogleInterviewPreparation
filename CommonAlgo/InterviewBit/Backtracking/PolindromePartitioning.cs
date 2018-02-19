using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Backtracking
{
    public class PolindromePartitioning
    {
        [TestCase("aab")]
        public void Test(string s)
        {
            var ans = new List<IList<string>>();
            var cur = new List<string>();

            Recurs(ans, cur, s, 0);

            foreach (var list in ans)
            {
                foreach (var i in list)
                    Console.Write(i + " ");
                Console.WriteLine();
            }
        }

        private void Recurs(ICollection<IList<string>> ans, IList<string> cur, string s, int start)
        {
            if (start == s.Length)
            {
                ans.Add(new List<string>(cur));
                return;
            }

            for (var j = start;
                j < s.Length;
                ++j)
            {
                var ss = s.Substring(start, j - start + 1);
                var isPoly = IsPoly(ss);

                if (isPoly)
                {
                    cur.Add(ss);
                    Recurs(ans, cur, s, j + 1);
                    cur.RemoveAt(cur.Count - 1);
                }
            }
        }

        [TestCase("abacaba", Result = 1), TestCase("abacabc", Result = 0)]
        public int Test1(string s)
        {
            Console.WriteLine(s);
            var isPoly = IsPoly(s);
            Console.WriteLine(isPoly ? 1 : 0);
            return isPoly ? 1 : 0;
        }

        private bool IsPoly(string s)
        {
            var n = s.Length / 2;
            for (var i = 0;
                i < n;
                i++)
            {
                if (s[i] != s[s.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }
}
