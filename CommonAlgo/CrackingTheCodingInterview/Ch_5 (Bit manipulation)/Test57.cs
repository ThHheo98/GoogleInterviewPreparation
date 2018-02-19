using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test57
    {
        public static string Convert(int x)
        {
            var bits = new char[32];
            int i = 0;

            while (x != 0)
            {
                bits[i++] = (x & 1) == 1 ? '1' : '0';
                x >>= 1;
            }

            Array.Reverse(bits, 0, i);
            return new string(bits);
        }

        /* Create a random array of numbers from 0 to n, but skip 'missing' */

        public static List<BitInteger> initialize(int n, int missing)
        {
            BitInteger.INTEGER_SIZE = Convert(n).Length;
            var array = new List<BitInteger>();

            for (int i = 1; i <= n; i++)
            {
                array.Add(new BitInteger(i == missing ? 0 : i));
            }

            // Shuffle the array once.
            for (int i = 0; i < n; i++)
            {
                var rand = (int) (i + new Random().NextDouble()*(n - i));

                BitInteger t = array[i];
                array[i] = array[rand];
                array[rand] = t;
            }

            return array;
        }


        public static int FindMissing(List<BitInteger> array)
        {
            return FindMissing(array, BitInteger.INTEGER_SIZE - 1);
        }

        private static int FindMissing(List<BitInteger> input, int column)
        {
            if (column < 0)
            {
                // Base case and error condition
                return 0;
            }
            var oneBits = new List<BitInteger>(input.Count/2);
            var zeroBits = new List<BitInteger>(input.Count/2);
            foreach (BitInteger t in input)
            {
                if (t.fetch(column) == 0)
                {
                    zeroBits.Add(t);
                }
                else
                {
                    oneBits.Add(t);
                }
            }
            if (zeroBits.Count <= oneBits.Count)
            {
                int v = FindMissing(zeroBits, column - 1);
                Console.Write("0");
                return (v << 1) | 0;
            }
            else
            {
                int v = FindMissing(oneBits, column - 1);
                Console.Write("1");
                return (v << 1) | 1;
            }
        }

        [TestCase]
        public void Test()
        {
            var rand = new Random();
            int n = rand.Next(300000) + 1;
            int missing = rand.Next(n + 1);
            List<BitInteger> array = initialize(n, missing);
            Console.WriteLine("The array contains all numbers but one from 0 to " + n + ", except for " + missing);

            int result = FindMissing(array);
            if (result != missing)
            {
                Console.WriteLine("Error in the algorithm!\n" + "The missing number is " + missing +
                                  ", but the algorithm reported " + result);
            }
            else
            {
                Console.WriteLine("\nThe missing number is " + result);
            }
        }
    }
}