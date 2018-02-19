using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch17
{
    /// <summary>
    ///     Given any integer, print an English phrase that describes the integer
    /// </summary>
    public class Test177
    {
        private static readonly String[] _digits =
        {
            "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
            "Nine"
        };

        private static readonly String[] _teens =
        {
            "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
            "Eighteen", "Nineteen"
        };

        private static readonly String[] _tens =
        {
            "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty",
            "Ninety"
        };

        private static readonly String[] _bigs = {"", "Thousand", "Million", "Billion"};

        public static String NumToString(int number)
        {
            if (number == 0)
            {
                return "Zero";
            }

            if (number < 0)
            {
                return "Negative " + NumToString(-1*number);
            }
            int count = 0;
            String str = "";

            while (number > 0)
            {
                if (number%1000 != 0)
                {
                    str = NumToString100(number%1000) + _bigs[count] + " " + str;
                }
                number /= 1000;
                count++;
            }

            return str.Trim();
        }

        private static String NumToString100(int number)
        {
            String str = "";

            /* Convert hundreds place */
            if (number >= 100)
            {
                str += _digits[number/100 - 1] + " Hundred ";
                number %= 100;
            }

            /* Convert tens place */
            if (number >= 11 && number <= 19)
            {
                return str + _teens[number - 11] + " ";
            }
            if (number == 10 || number >= 20)
            {
                str += _tens[number/10 - 1] + " ";
                number %= 10;
            }

            /* Convert ones place */
            if (number >= 1 && number <= 9)
            {
                str += _digits[number - 1] + " ";
            }

            return str;
        }

        [TestCase(100, Result = "One Hundred")]
        public string Test(int a)
        {
            return NumToString(a);
        }
    }
}