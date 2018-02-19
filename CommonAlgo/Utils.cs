using System;
using System.Collections.Generic;

namespace CommonAlgo
{
    internal static class Utils
    {
       

        private static readonly Random Rnd = new Random((int) DateTime.Today.ToFileTimeUtc());

        public static T RemoveLast<T>(this IList<T> list)
        {
            var rv = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return rv;
        }

        internal static void PrintAdjacencyList(IList<IList<int>> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                Console.Write("[{0}]: ", i);
                for (var j = 0; j < list[i].Count; j++)
                {
                    Console.Write(list[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        internal static void Swap(ref int i, ref int i1)
        {
            var t = i;
            i = i1;
            i1 = t;
        }

        internal static void Swap<T>(ref T i, ref T i1)
        {
            var t = i;
            i = i1;
            i1 = t;
        }

        internal static void Swap<T>(T[] a, int i, int i1)
        {
            var t = a[i];
            a[i] = a[i1];
            a[i1] = t;
        }

        internal static void Swap1<T>(IList<T> a, int i, int i1)
        {
            var t = a[i];
            a[i] = a[i1];
            a[i1] = t;
        }

        private static void SortCollection<T, U>(List<T> list, Func<T, U> expression)
            where U : IComparable<U>
        {
            list.Sort((x, y) => expression.Invoke(x).CompareTo(expression.Invoke(y)));
        }
        
        internal static void PrintCollection<T>(IEnumerable<T> a)
        {
            foreach (var i in a)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        internal static void PrintMatrix<T>(IEnumerable<IEnumerable<T>> a)
        {
            foreach (var i in a)
            {
                foreach (var v in i)
                {
                    Console.Write(v + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static int NthElement(int[] a, int k)
        {
            return NthElement(a, 0, a.Length, k);
        }

        private static int NthElement(int[] a, int low, int high, int k)
        {
            var i1 = low + Rnd.Next(high - low);
            Swap(a, i1, high - 1);

            var i = Partition(a, low, high);

            if (k < i)
            {
                return NthElement(a, low, i, k);
            }
            if (k > i)
            {
                return NthElement(a, i + 1, high, k);
            }
            return i;
        }

        private static int Partition(int[] a, int low, int high)
        {
            var i = low - 1;
            for (var j = low; j < high; j++)
            {
                if (a[j] <= a[high - 1])
                {
                    i++;
                    Swap(a, i, j);
                }
            }
            return i;
        }
    }
}