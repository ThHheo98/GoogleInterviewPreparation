using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TwoPointers
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/merge-two-sorted-lists-ii/
    ///     https://github.com/manuchandel/SportProgramming/blob/master/InterviewBit/Two-Pointers/MERGE.cpp
    /// </summary>
    public class MergeTwoSortedLists2
    {
        [Test]
        public void Test()
        {
            var merge = Merge(new List<int> { 1, 2, 3 }, new List<int> { 3, 3, 4 });
            Assert.AreEqual(1, merge[0]);
            Assert.AreEqual(2, merge[1]);
            Assert.AreEqual(3, merge[2]);
            Assert.AreEqual(3, merge[3]);
            Assert.AreEqual(3, merge[4]);
            Assert.AreEqual(4, merge[5]);
        }

        public List<int> Merge(List<int> A, List<int> B)
        {
            var list = new List<int>();

            var n = A.Count;
            var m = B.Count;
            int p, q = 0;

            for (p = 0;
                p < n;
                p++)
                list.Add(A[p]);
            for (p = 0;
                p < n;
                p++)
                A.RemoveAt(A.Count - 1);
            p = 0;
            while (p < n && q < m)
            {
                if (list[p] <= B[q])
                {
                    A.Add(list[p]);
                    p++;
                }
                else
                {
                    A.Add(B[q]);
                    q++;
                }
            }
            while (p < n)
            {
                A.Add(list[p]);
                p++;
            }
            while (q < m)
            {
                A.Add(B[q]);
                q++;
            }
            return A;
        }
    }
}
