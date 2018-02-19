using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Greedy
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/bulbs/
    ///     solution
    ///     http://qa.geeksforgeeks.org/4118/find-the-minimum-number-switches-you-have-press-turn-the-bulbs
    /// </summary>
    public class Bulbs
    {
        [Test]
        public void TestReal()
        {
            var A = new List<int> { 0, 1, 0, 1 };
            var ans = Test(A);
            Assert.AreEqual(4, ans);
        }

        private int Test(List<int> A)
        {
            if (A == null || A.Count == 0)
                return 0;

            var ans = 0;
            if (A[0] != 1)
                ans++;

            for (var i = 1;
                i < A.Count;
                ++i)
            {
                if (A[i - 1] != A[i])
                    ans++;
            }

            return ans;
        }
    }
}
