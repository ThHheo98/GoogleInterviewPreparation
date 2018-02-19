using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Hashing
{
    /// <summary>
    /// https://www.interviewbit.com/problems/diffk-ii/
    /// https://github.com/manuchandel/SportProgramming/blob/master/InterviewBit/Hashing/DIFFK2.cpp 
    /// </summary>
    public class DiffK2
    {
        /*
         Given an array A of integers and another non negative integer k, find if there exists 2 indices i and j such that A[i] - A[j] = k, i != j.

Example :

Input :

A : [1 5 3]
k : 2
Output :

1
as 3 - 1 = 2

Return 0 / 1 for this problem.

            The naive approach obviously is exloring all combinations of 2 integers using 2 loops and then check their difference.

However, lets look at it like this. 
We are looking to find pair of integers where A[i] - A[j] = k, k being known entity
Lets say we fix A[i] ( i.e. we know A[i]), do we know what A[j] should be ? Once we know what A[j] we want, does it reduce to a search / lookup problem ?

            We are looking to find pair of integers where A[i] - A[j] = k, k being known entity
Lets say we fix A[i] ( i.e. we know A[i]), do we know what A[j] should be ?
A[j] = A[i] - k.

We can store all the numbers in a hashmap / hashset and then lookup A[j] in it to find out if A[j] exists.

Corner case : How do you handle case when k = 0 cleanly ?
             */
        [Test]
        public void Test()
        {
            var list = new List<int> { 1, 5, 3 };
            var b = 2;

            var possible1 = diffkPossible1(list, b);
            Assert.AreEqual(1, possible1);

            var possible2 = diffkPossible2(list, b);
            Assert.AreEqual(1, possible2);
        }

        /// <summary>
        ///     2 pass solution
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int diffkPossible2(List<int> a, int b)
        {
            if (a == null || a.Count < 2) return 0;

            var d = new Dictionary<int, int>();

            for (var i = 0; i < a.Count; i++)
                d[a[i]] = i;

            for (var i = 0; i < a.Count; i++)
            {
                if (d.ContainsKey(a[i] + b))
                {
                    if (d[a[i] + b] != i) return 1;
                }
                else if (d.ContainsKey(a[i] - b))
                {
                    if (d[a[i] - b] != i) return 1;
                }
            }

            return 0;
        }

        /// <summary>
        ///     1 pass solution
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private int diffkPossible1(List<int> a, int b)
        {
            if (a == null || a.Count < 2) return 0;

            var hashSet = new HashSet<int>();

            for (var i = 0; i < a.Count; i++)
            {
                var s1 = a[i] + b;
                var s2 = a[i] - b;

                if (hashSet.Contains(s1)) return 1;
                if (hashSet.Contains(s2)) return 1;

                hashSet.Add(a[i]);
            }

            return 0;
        }
    }
}
