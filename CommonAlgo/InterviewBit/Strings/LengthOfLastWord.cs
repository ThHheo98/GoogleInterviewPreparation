using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/length-of-last-word/
    /// </summary>
    public class LengthOfLastWord
    {
        [Test]
        public void test()
        {
            const string a = "Hello World   ";
            var l = LengthOfLastWordTest(a);
            Assert.AreEqual(5, l);
        }

        public int LengthOfLastWordTest(string a)
        {
            if (a == null || a.Length == 0)
                return 0;

            var i = a.Length - 1;
            var j = -1;

            while (i >= 0 && a[i] == ' ')
                i--;

            if (i == -1)
                return 0;

            j = i;
            while (j >= 0 && a[j] != ' ')
                j--;

            if (j == -1)
                return i + 1;

            return i - j;
        }
    }
}
