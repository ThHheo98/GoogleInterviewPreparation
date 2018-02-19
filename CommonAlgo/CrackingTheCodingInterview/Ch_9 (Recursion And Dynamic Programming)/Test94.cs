using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    /// <summary>
    ///     Find all subset of set (O(2^n))
    /// </summary>
    public class Test94
    {
        [TestCase(new[] {1, 2, 3})]
        public void Test(int[] set)
        {
            List<List<int>> generateSubset = GenerateSubset(set, 0);
            foreach (var list in generateSubset)
            {
                foreach (int value in list)
                {
                    Console.Write(value);
                }
                Console.WriteLine();
            }
        }

        private List<List<T>> GenerateSubset<T>(T[] set, int index)
        {
            List<List<T>> allsubsets;
            if (set.Length == index)
            {
                allsubsets = new List<List<T>> {new List<T>()};
            }
            else
            {
                allsubsets = GenerateSubset(set, index + 1);
                T item = set[index];
                var moresubsets = new List<List<T>>();
                foreach (var s in allsubsets)
                {
                    var newsubset = new List<T>();
                    newsubset.AddRange(s);
                    newsubset.Add(item);
                    moresubsets.Add(newsubset);
                }
                allsubsets.AddRange(moresubsets);
            }
            return allsubsets;
        }
    }
}