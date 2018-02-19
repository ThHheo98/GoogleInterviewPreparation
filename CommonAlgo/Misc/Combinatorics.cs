using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.Misc
{
    public class Combinatorics
    {
        [TestCase]
        public void Test()
        {
            const string s = "123";
            Console.WriteLine("All permutations of " + s);
            Permutations(s, 0);

            const int n = 5;
            const int k = 3;
            Console.WriteLine("All combinations of 3 from 5");
            var list = new List<int>();
            Arrangements(list, n, k, 1);

            Console.WriteLine("All combinations of 3 from 5");
            Combinations(new List<int>(), n, 1, k);
        }

        private static void Permutations(string str, int start)
        {
            if (start == str.Length - 1)
            {
                Check(str);
            }
            else
            {
                var charArr = str.ToCharArray();
                for (var i = start; i < charArr.Length; i++)
                {
                    Utils.Swap1(charArr, start, i);
                    Permutations(new string(charArr), start + 1);
                    Utils.Swap1(charArr, start, i);
                }
            }
        }

        private static void Arrangements(IList<int> list, int n, int k, int start)
        {
            if (start == n)
            {
                Check(list);
            }
            else
            {
                for (var i = start; i < n; i++)
                {
                    Utils.Swap1(list, start, i);
                    Arrangements(list, n, k - 1, start + 1);
                    Utils.Swap1(list, start, i);
                }
            }
        }

        private static void Combinations(IList<int> list, int n, int start, int k)
        {
            if (k == 0)
            {
                Check(list);
            }
            else
            {
                for (var i = start; i <= n; i++)
                {
                    list.Add(i);
                    Combinations(list, n, i + 1, k - 1);
                    list.RemoveLast();
                }
            }
        }

        private static void Check(string str)
        {
            foreach (var i in str)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        private static void Check(IList<int> a)
        {
            foreach (var i in a)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}