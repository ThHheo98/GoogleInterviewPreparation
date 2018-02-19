using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Maths
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/palindrome-integer/?ref=dash-reco
    /// </summary>
    public class IntIsPolindrome
    {
        [TestCase]
        public void test()
        {
            var i = isPalindrome(112211);
            Assert.AreEqual(1, i);
        }

        public int isPalindrome(int x)
        {
            if (x < 0)
                return 0;

            var div = 1;
            while (x / div >= 10)
                div *= 10;

            var l = 0;
            var r = 0;

            while (x != 0)
            {
                l = x / div;
                r = x % 10;
                if (l != r)
                    return 0;

                x = x % div / 10;
                div /= 100;
            }
            return 1;
        }
    }
}
