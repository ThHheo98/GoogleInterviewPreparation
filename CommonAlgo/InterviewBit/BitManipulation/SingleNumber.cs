using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BitManipulation
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/single-number/
    ///     https://habrahabr.ru/post/243819/
    /// </summary>
    public class SingleNumber
    {
        [Test]
        public void Test()
        {
            var number = singleNumber(new List<int> { 2, 2, 3, 3, 4, 5, 5, 6, 6 });
            Assert.AreEqual(4, number);
        }

        public int singleNumber(List<int> A)
        {
            var xr = 0;
            for (var i = 0;
                i < A.Count;
                i++)
                xr ^= A[i];
            return xr;
        }
    }
}
