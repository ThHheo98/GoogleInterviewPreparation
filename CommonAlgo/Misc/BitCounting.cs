using System;
using NUnit.Framework;

namespace CommonAlgo.Misc
{
    public class BitCounting
    {
        [TestCase(1, Result = 1), TestCase(-1, Result = 32)]
        public int TestBiTCounting(int number)
        {
            Console.WriteLine(GetIntBinaryString(number));

            var r = 0;

            var number_uint = (uint)number;
            Console.WriteLine(GetIntBinaryString(number_uint));

            Console.WriteLine();
            while (number_uint != 0)
            {
                if ((number_uint & 1) == 1)
                    r++;
                Console.WriteLine(GetIntBinaryString(number_uint));
                number_uint = number_uint >> 1;
                Console.WriteLine(GetIntBinaryString(number_uint));
            }
            return r;
        }

        [TestCase(-1, Result = 32)]
        public int TestBitCounting1(int number)
        {
            Console.WriteLine(GetIntBinaryString(number));

            var r = 0;

            Console.WriteLine();
            while (number != 0)
            {
                if ((number & 1) == 1)
                    r++;
                Console.WriteLine(GetIntBinaryString(number));
                number = number >> 1;
                Console.WriteLine(GetIntBinaryString(number));
            }
            return r;
        }

        private static string GetIntBinaryString(uint n)
        {
            var b = new char[32];
            var pos = 31;
            var i = 0;

            while (i < 32)
            {
                if ((n & 1 << i) != 0)
                    b[pos] = '1';
                else
                    b[pos] = '0';
                pos--;
                i++;
            }
            return new string(b);
        }

        private static string GetIntBinaryString(int n)
        {
            var b = new char[32];
            var pos = 31;
            var i = 0;

            while (i < 32)
            {
                if ((n & 1 << i) != 0)
                    b[pos] = '1';
                else
                    b[pos] = '0';
                pos--;
                i++;
            }
            return new string(b);
        }
    }
}
