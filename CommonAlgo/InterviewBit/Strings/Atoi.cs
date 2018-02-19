using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    public class Atoi
    {
        [Test]
        public void Test()
        {
            var a = AtoiTest("  123 as03");
            Assert.AreEqual(123, a);
        }

        private int AtoiTest(string a)
        {
            if (string.IsNullOrEmpty(a)) return 0;

            var t = a.Trim();

            var sign = false;
            var runner = 0;
            if (t[runner] == '-')
                sign = true;
            else if (t[runner] == '+')
                runner++;

            double r = 0;
            while (runner < t.Length && t[runner] >= '0' && t[runner] <= '9')
            {
                r = r * 10 + (t[runner] - '0');
                runner++;
            }

            if (sign) r = -r;
            if (r < int.MinValue) return int.MinValue;
            if (r > int.MaxValue) return int.MaxValue;
            return (int)r;
        }
    }
}
