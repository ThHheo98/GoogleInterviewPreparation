using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    internal class ValidNumber
    {
        [Test]
        public void Test()
        {
            var t = isNumber("22e1");
            Assert.AreEqual(1, t);
        }

        public int isNumber(string a)
        {
            if (a == null || a.Length == 0 || a[a.Length - 1] == '.')
                return 0;
            var i = 0;
            var dot = 0;
            var e = 0;
            var num = 0;
            var temp = a[i];

            if (temp == '+' || temp == '-' || temp == ' ')
                i++;

            while (i < a.Length)
            {
                temp = a[i];

                if (temp >= '0' && temp <= '9')
                {
                    num++;
                }
                else if (temp == '+' || temp == '-' || temp == ' ')
                {
                }
                else if (temp == '.' && i < a.Length - 1 && a[i + 1] >= '0' && a[i + 1] <= '9')
                {
                    if (e > 0)
                        return 0;
                    dot++;
                }
                else if (temp == 'e')
                {
                    e++;
                }
                else
                {
                    return 0;
                }
                i++;
            }

            if (num < 1)
                return 0;

            if (dot > 1 || e > 1)
                return 0;

            return 1;
        }
    }
}
