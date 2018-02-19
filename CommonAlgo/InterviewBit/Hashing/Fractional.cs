using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Hashing
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/fraction/
    ///     http://qa.geeksforgeeks.org/3910/return-the-fraction-as-string
    /// </summary>
    public class Fractional
    {
        /*
         * Given two integers representing the numerator and denominator of a fraction, return the fraction in string format.

If the fractional part is repeating, enclose the repeating part in parentheses.

Example :

Given numerator = 1, denominator = 2, return "0.5"
Given numerator = 2, denominator = 1, return "2"
Given numerator = 2, denominator = 3, return "0.(6)"
         * 
         When does the fractional part repeat ?

Lets simulate the process of converting fraction to decimal. Lets look at the part where we have already figured out the integer part which is floor(numerator / denominator). 
Now you are left with ( remainder = numerator%denominator ) / denominator. 
If you remember the process of converting to decimal, at each step you do the following :

1) multiply the remainder by 10, 
2) append remainder / denominator to your decimals
3) remainder = remainder % denominator.

At any moment, if your remainder becomes 0, you are done.

However, there is a problem with recurring decimals. For example if you look at 1/3, the remainder never becomes 0.

Notice one more important thing. 
If you start with remainder = R at any point with denominator d, you will always get the same sequence of digits. 
So, if your remainder repeats at any point of time, you know that the digits between the last occurrence of R will keep repeating.
             */

        [Test]
        public void Test()
        {
            var a = -1;
            var b = 2;
            var toDecimal = fractionToDecimal(a, b);
            Assert.AreEqual("-0.5", toDecimal);
        }

        public string fractionToDecimal(int a, int b)
        {
            if (a == 0) return "0";

            long numerator = a;
            long denominator = b;

            var res = string.Empty;

            if (numerator < 0 ^ denominator < 0) res += "-";

            numerator = Math.Abs(numerator);
            denominator = Math.Abs(denominator);

            res += (numerator / denominator).ToString();

            if (numerator % denominator == 0) return res;

            res += ".";

            var map = new Dictionary<long, int>();

            for (var r = numerator % denominator; r != 0; r %= denominator)
            {
                if (map.ContainsKey(r))
                {
                    res = res.Insert(map[r], "(");
                    res += ")";
                    break;
                }

                map[r] = res.Length;

                r *= 10;

                res += (char)('0' + r / denominator);
            }

            return res;
        }
    }
}
