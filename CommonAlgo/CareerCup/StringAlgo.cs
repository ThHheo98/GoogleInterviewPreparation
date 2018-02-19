using System;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.CareerCup
{
    [TestFixture]
    public class StringAlgo
    {
        private const char _0 = '0';
        private const char _1 = '1';
        private const char _q = '?';
        private int _cntPrints;

        [TestCase("??", 0)]
        [TestCase("?d?f?c??", 0)]
        public void StringPermutationReplace(string s, int startPos)
        {
            _cntPrints = 0;
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException("s");
            }

            if (startPos < 0)
            {
                throw new ArgumentException("startPos");
            }

            PrintStringPermutations(s, startPos);
            Console.WriteLine();
            int k = s.ToCharArray().Count(c => c == _q);
            int n = 2; // 0 and 1
            double actual = Math.Pow(n, k);
            Console.WriteLine("n^k = {0}", actual);
            Console.WriteLine("Count of prints = {0}", _cntPrints);
            Assert.AreEqual(_cntPrints, actual);
        }

        private void PrintStringPermutations(string s, int position)
        {
            if (position == s.Length) // recursion base
            {
                Console.WriteLine(s);
                _cntPrints++;
            }
            else if (s[position] != _q)
            {
                PrintStringPermutations(s, position + 1);
            }
            else
            {
                s = ReplaceAt(s, position, _0);
                PrintStringPermutations(s, position + 1);
                s = ReplaceAt(s, position, _1);
                PrintStringPermutations(s, position + 1);
            }
        }

        private static string ReplaceAt(string input, int index, char newChar)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }
    }
}