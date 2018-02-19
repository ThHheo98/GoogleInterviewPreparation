using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BinarySearch
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/square-root-of-integer/
    ///     http://www.geeksforgeeks.org/square-root-of-an-integer/
    /// </summary>
    public class SquareRootOfInteger
    {
        [Test]
        public void Test()
        {
            var i = sqrt(4);
            Assert.AreEqual(2, i);
        }

        public int sqrt(int x)
        {
            // Base Cases
            if (x == 0 || x == 1)
                return x;

            // Do Binary Search for floor(sqrt(x))
            long start = 1, end = x / 2 + 1, ans = 0;
            while (start <= end)
            {
                var mid = (start + end) / 2;

                // If x is a perfect square
                if (mid * mid == x)
                    return (int)mid;

                // Since we need floor, we update answer when mid*mid is
                // smaller than x, and move closer to sqrt(x)
                if (mid * mid < x)
                {
                    start = mid + 1;
                    ans = mid;
                }
                else // If mid*mid is greater than x
                    end = mid - 1;
            }
            return (int)ans;
        }
    }
}
