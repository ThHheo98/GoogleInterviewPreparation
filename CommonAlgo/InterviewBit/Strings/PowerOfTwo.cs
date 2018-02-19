using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Strings
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/power-of-2/
    /// </summary>
    public class PowerOfTwo
    {
        private bool NotOne(string str)
        {
            var sz = str.Length;
            if (sz > 1)
                return true;
            if (str[0] != '1')
                return true;
            return false;
        }

        private bool IsEven(string str)
        {
            var data = str[str.Length - 1] - '0' & 1;
            if (data != 0)
                return false;
            return true;
        }

        private string Divide(string str, int data)
        {
            var ch = str.ToCharArray();

            Array.Reverse(ch);

            var str1 = new string(ch);

            long bas = 10;
            var temp = "";
            for (int i = str1.Length - 1, rem = 0;
                i >= 0;
                --i)
            {
                var cur = str1[i] - '0' + rem * bas;
                var val = (char)(cur / data);
                rem = (int)(cur % data);
                temp += (char)(val + '0');
            }

            while (temp.Length > 0 && temp[0] - '0' == 0)
                temp = temp.Remove(0, 1);

            return temp;
        }

        private int Power(string str)
        {
            var sz = str.Length;

            if (sz == 1)
            {
                if (str[0] == '2' || str[0] == '4' || str[0] == '8')
                    return 1;
                return 0;
            }

            while (NotOne(str) && IsEven(str))
            {
                str = Divide(str, 2);
                if (str.Length == 1 && str[0] == '1')
                    break;
            }

            if (NotOne(str))
                return 0;

            return 1;
        }

        [Test]
        public void t()
        {
            var powerOfTwoTest = PowerOfTwoTest("16");
            Assert.AreEqual(1, powerOfTwoTest);
        }

        public int PowerOfTwoTest(string str)
        {
            var power = Power(str);
            return power;
        }
    }
}
