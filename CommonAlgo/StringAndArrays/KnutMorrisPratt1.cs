using System;
using NUnit.Framework;

namespace CommonAlgo.StringAndArrays
{
    public class TestFixtureClass
    {
        public void knutmorrisprattkmpWORKING()
        {
            
        }

        [TestCase("abacaba", "aca", Result = true, TestName = "test1")]
        public bool KnutMorrisPrattTest(string text, string pattern)
        {
            return IsMatch(text, pattern) != -1;
        }


        [TestCase("abcabcd", TestName = "test1")]
        public void KnutMorrisPrattTest1(string pattern)
        {
            var prefix = GetPrefix(pattern);
            var t = 0;
            Console.WriteLine(prefix);
        }


        public int IsMatch(string s, string p)
        {
            var pi = GetPrefix(p);
            int i = 0;
            int j = 0;

            while (i < s.Length && j < p.Length)
            {
                while (j >= 0 && s[i] != s[j])
                {
                    j = pi[j];
                }
                i++;
                j++;
            }
            return j == p.Length ? i - j : -1;
        }

        public int[] GetPrefix(string s)
        {
            var pi = new int[s.Length];
            int k = 0;
            int i = 1;
            pi[0] = -1;
            while (i < s.Length - 1)
            {
                while (k >= 0 && s[i] != s[k])
                {
                    k = pi[k];
                }
                i++;
                k++;
                if (s[k] == s[i])
                    pi[i] = pi[k];
                else
                    pi[i] = k;
            }
            return pi;
        }
          
    }
}