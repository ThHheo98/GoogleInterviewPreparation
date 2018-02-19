using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Hashing
{
    public class WindowString
    {
        [Test]
        public void Test()
        {
            var window = minWindow("ADOBECODEBANC", "ABC");
            Assert.AreEqual("BANC", window);
        }

        [Test]
        public void Test1()
        {
            int a = -2147483648;
            int b = -1;
            long n = a;
            long d = b;
            var xor = (n<0)^(d<0);
            Console.WriteLine(xor);


            string res = string.Empty;

            bool xorValue = (n < 0) ^ (d < 0);

            if (xorValue) res += "-";

            long numerator = Math.Abs(n);
            long denominator = Math.Abs(d);

            res += (numerator / denominator).ToString();

            if (numerator % denominator == 0)
                Console.WriteLine(res);
        }

        public string minWindow(string s, string t)
        {
           if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t)) return "";
            if (t.Length > s.Length) return "";

            var hasFound = new int[256];
            var haveToFind = new int[256];

            for (int i = 0; i < t.Length; i++)
            {
                haveToFind[t[i]]++;
            }


            // to track anser
            int start = -1;
            int end = -1;
            int minLength = int.MaxValue;
            int count = 0;

            for (int left = 0, right = 0; right < s.Length; right++)
            {
                // skip all symbols we no need to match
                if (haveToFind[s[right]] == 0) { continue; }
                hasFound[s[right]]++;
                if (hasFound[s[right]] <= haveToFind[s[right]]) count++;

                if (count == t.Length)
                {
                    while (haveToFind[s[left]] == 0 || hasFound[s[left]] > haveToFind[s[left]])
                    {
                        if (hasFound[s[left]] > haveToFind[s[left]])
                            hasFound[s[left]]--;
                        left++;
                    }

                    int ml = right - left + 1;
                    if (ml < minLength)
                    {
                        minLength = ml;
                        start = left;
                        end = right;
                    }
                }
            }

            string r = "";
            if (start != -1 && end != -1)
            {
                r = s.Substring(start, minLength);
            }
            return r;
        }
    }
}