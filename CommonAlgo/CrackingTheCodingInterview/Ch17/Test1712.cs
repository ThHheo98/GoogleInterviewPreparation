using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch17
{
    /// <summary>
    ///     Design an algorithm to find all pairs of integers within an array which sum to a specified value.
    /// </summary>
    public class Test1712
    {
        [TestCase(new[] {9, 8, 7, 6, 5, 4, 3, 2, 1}, 8)]
        public void Test(int[] a, int sum)
        {
            PrintPairSums(a, sum);
        }

        private void PrintPairSums(int[] array, int sum)
        {
            Array.Sort(array);
            var first = 0;
            var last = array.Length - 1;
            while (first < last)
            {
                var s = array[first] + array[last];
                if (s == sum)
                {
                    Console.WriteLine(array[first] + " " + array[last]);
                    first++;
                    last--;
                }
                else
                {
                    if (s < sum) first++;
                    else last--;
                }
            }
        }
    }

    /// <summary>
    ///     Design an algorithm to find all pairs of integers within an array which sum to a specified value.
    ///     Версия Никиты, задача из Касперского
    /// </summary>
    public class Test17122
    {
        [TestCase(new[] {9, 8, 7, 6, 5, 4, 3, 2, 1}, 8)]
        public void Test(int[] a, int sum)
        {
            Pairs.GetPairs(a, sum);
        }

        // Есть коллекция чисел и отдельное число Х. Надо вывести все пары чисел, которые в сумме равны заданному Х.
        public static class Pairs
        {
            public static IDictionary<int, int> GetPairs(IEnumerable<int> items, int number)
            {
                var result = new Dictionary<int, int>();
                var pairs = new Dictionary<int, int>();

                foreach (var i in items)
                {
                    if (pairs.ContainsKey(i))
                    {
                        result[i] = pairs[i];
                    }
                    else
                    {
                        pairs[number - i] = i;
                    }
                }

                return result;
            }
        }
    }

    /// <summary>
    ///     Design an algorithm to find all pairs of integers within an array which sum to a specified value.
    /// </summary>
    public class Test17121
    {
        [TestCase(new[] {9, 8, 7, 6, 5, 4, 3, 2, 1, 9, 8, 7, 6, 5, 4, 3, 2, 1}, 8)]
        public void Test(int[] a, int sum)
        {
            PrintPairSums(a, sum);
        }

        private void PrintPairSums(int[] array, int sum)
        {
            Array.Sort(array);
            var first = 0;
            var last = array.Length - 1;
            while (first < last)
            {
                var s = array[first] + array[last];
                if (s == sum)
                {
                    Console.WriteLine(array[first] + " " + array[last]);
                    first++;
                    last--;
                }
                else
                {
                    if (s < sum) first++;
                    else last--;
                }
            }
        }
    }
}