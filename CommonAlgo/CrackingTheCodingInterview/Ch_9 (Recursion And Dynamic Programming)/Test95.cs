using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    /// <summary>
    ///     Get all permutation of string, n! permutations and time O(n!)
    /// </summary>
    public class Test95
    {
        // 1. remove first char 
        // 2. find permutations of the rest of chars
        // 3. Attach the first char to each of those permutations.
        //     3.1  for each permutation, move firstChar in all indexes to produce even more permutations.
        // 4. Return list of possible permutations.

        private IEnumerable<string> FindPermutations(string str)
        {
            if (str.Length == 2)
            {
                var c = str.ToCharArray();
                var s = new string(new[] {c[1], c[0]});
                return new[]
                {
                    str,
                    s
                };
            }

            var result = new List<string>();

            var firstChar = str[0];
            var permutations = FindPermutations(str.Substring(1));
            foreach (var s in permutations)
            {
                var temp = firstChar + s;
                result.Add(temp);

                var chars = temp.ToCharArray();
                for (var i = 0; i < temp.Length - 1; i++)
                {
                    Utils.Swap(chars, i, i + 1);
                    var item = new string(chars);
                    result.Add(item);
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// http://www.geeksforgeeks.org/write-a-c-program-to-print-all-permutations-of-a-given-string/
        ///     Algorithm Paradigm: Backtracking
        ///     Time Complexity: O(n*n!)
        /// </summary>
        /// <param name="res"></param>
        /// <param name="str"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        private void FindPermutationsBackTracking(IList<string> res, char[] str, int lo, int hi)
        {
            if (lo == hi)
            {
                res.Add(new string(str));
            }
            else
            {
                for (var i = lo; i <= hi; i++)
                {
                    Utils.Swap(str, lo, i);
                    FindPermutationsBackTracking(res, str, lo + 1, hi);
                    /* The first swap swaps two characters, e.g. ABC -> ACB
                     * Then you recursively call permute on ACB.
                     * But then you need to go back to ABC to compute all the other permutations. 
                     * That is the purpose of the second swap, merely swapping the same two indices, 
                     * canceling the effect of the first swap.
                     */
                    Utils.Swap(str, lo, i); //backtrack 
                }
            }
        }

        [TestCase]
        public void PermutationTest()
        {
            const string s = "ABC";
            var dict = new HashSet<string>
            {
                "ABC",
                "BAC",
                "BCA",
                "ACB",
                "CAB",
                "CBA"
            };
            var enumerable = FindPermutations(s).ToList();
            Assert.IsTrue(enumerable.Count == 6);
            foreach (var item in enumerable)
            {
                Assert.IsTrue(dict.Contains(item));
                dict.Remove(item);
                Console.WriteLine(item);
            }
            Assert.IsTrue(dict.Count == 0);
        }

        [TestCase]
        public void PermutationTestBackTracking()
        {
            const string s = "ABC";
            var dict = new HashSet<string>
            {
                "ABC",
                "BAC",
                "BCA",
                "ACB",
                "CAB",
                "CBA"
            };
            var list = new List<string>();
            FindPermutationsBackTracking(list, s.ToCharArray(), 0, s.Length - 1);
            Assert.IsTrue(list.Count == 6);
            foreach (var item in list)
            {
                Assert.IsTrue(dict.Contains(item));
                dict.Remove(item);
                Console.WriteLine(item);
            }
            Assert.IsTrue(dict.Count == 0);
        }
    }
}