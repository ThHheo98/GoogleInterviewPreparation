using System;
using System.Collections.Generic;
using System.Text;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public static class AssortedMethods
    {
        private static readonly Random Random = new Random((int) DateTime.Now.Ticks);

        private static int RandomInt(int n)
        {
            return Random.Next(n);
        }

        private static int RandomIntInRange(int min, int max)
        {
            return RandomInt(max + 1 - min) + min;
        }

        public static int[][] RandomMatrix(int m, int n, int min, int max)
        {
            var matrix = new int[m][];
            for (int i = 0; i < m; i++)
            {
                matrix[i] = new int[n];
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i][j] = RandomIntInRange(min, max);
                }
            }
            return matrix;
        }

        public static string ArrayToString(IEnumerable<int> array)
        {
            var sb = new StringBuilder();
            foreach (int v in array)
            {
                sb.Append(v + ", ");
            }
            return sb.ToString();
        }

        public static int[] RandomArray(int n, int min, int max)
        {
            var array = new int[n];
            for (int j = 0; j < n; j++)
                array[j] = RandomIntInRange(min, max);
            return array;
        }

        public static void PrintMatrix(IEnumerable<int[]> matrix)
        {
            foreach (var t in matrix)
            {
                foreach (int t1 in t)
                {
                    if (t1 < 10 && t1 > -10)
                    {
                        Console.WriteLine(" ");
                    }
                    if (t1 < 100 && t1 > -100)
                    {
                        Console.WriteLine(" ");
                    }
                    if (t1 >= 0)
                    {
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine(" " + t1);
                }
                Console.WriteLine();
            }
        }

        public static void PrintMatrix(IEnumerable<bool[]> matrix)
        {
            foreach (var t in matrix)
            {
                foreach (bool t1 in t)
                {
                    Console.WriteLine(t1 ? "1" : "0");
                }
                Console.WriteLine();
            }
        }

        public static void PrintIntArray(IEnumerable<int> array)
        {
            foreach (int t in array)
            {
                Console.WriteLine(t + " ");
            }
            Console.WriteLine();
        }
    }
}