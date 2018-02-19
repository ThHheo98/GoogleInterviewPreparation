using NUnit.Framework;

namespace CommonAlgo.StringAndArrays
{
    public class TestFixtureClass1
    {
        [TestCase("abacaba", "aca", Result = true, TestName = "test1")]
        public bool KnutMorrisPrattTest(string text, string pattern)
        {
            return IsContains(text, pattern);
        }

        private bool IsContains(string t, string p)
        {
            return FindFirstIndexOfPInT(t, p) != -1;
        }

        private int FindFirstIndexOfPInT(string s, string p)
        {
            int[] prefix = GetPrefix(p);
            int i = 0;
            int j = 0;

            while (i < s.Length && j < p.Length)
            {
                while (j >= 0 && s[i] != s[j])
                {
                    j = prefix[j];
                }
                i++;
                j++;
            }
            return j == p.Length ? i - j : -1;
        }

        private int[] GetPrefix(string s)
        {
            var pi = new int[s.Length];
            pi[0] = -1;
            int k = 0;
            int i = 1;

            while (i < s.Length - 1)
            {
                while (k >= 0 && s[k] != s[i])
                {
                    k = pi[k];
                }
                k++;
                i++;
                pi[i] = s[k] == s[i] ? pi[k] : k;
            }
            return pi;
        }
    }
}