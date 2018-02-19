using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Maths
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/rearrange-array/
    /// </summary>
    public class RearrangeArray
    {
        [Test]
        public void Test()
        {
            int[] a = { 1, 0 };
            var n = a.Length;
            for (var i = 0;
                i < n;
                i++)
                a[i] += a[a[i]] % n * n;

            for (var i = 0;
                i < n;
                i++)
                a[i] /= n;

            Assert.AreEqual(0, a[0]);
            Assert.AreEqual(1, a[1]);
        }
    }
}
