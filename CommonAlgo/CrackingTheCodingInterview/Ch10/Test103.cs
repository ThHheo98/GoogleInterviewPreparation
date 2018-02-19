using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch10
{
    public class Test103
    {
        [TestCase(new[] {3, 4, 5, 6, 7, 8, 1, 2, 3}, 3, Result = 0, TestName = "Test1")]
        [TestCase(new[] {4, 5, 6, 7, 8, 1, 2, 3}, 3, Result = 7, TestName = "Test2")]
        public int Test(int[] a, int x)
        {
            int findXElement = FindXElement(a, 0, a.Length - 1, x);
            Console.WriteLine(findXElement);
            return findXElement;
        }

        private int FindXElement(int[] a, int l, int r, int x)
        {
            int mid = l + (r - l)/2;
            if (a[mid] == x) // base case
            {
                return mid;
            }

            if (r < l) return -1;

            if (a[l] < a[mid]) // если левая половина отсортирована
            {
                if (x >= a[l] && x <= a[mid])
                {
                    return FindXElement(a, l, mid - 1, x); // поиск в левой половине
                }
                return FindXElement(a, mid + 1, r, x); // поиск в правой половине
            }

            if (a[mid] < a[l]) // или если правая половина отсортирована
            {
                if (x >= a[mid] && x <= a[r])
                {
                    return FindXElement(a, mid + 1, r, x); // поиск в правой половине
                }
                return FindXElement(a, l, mid - 1, x); // поиск в левой половине
            }

            if (a[l] == a[mid]) // левая половина - все повторения
            {
                if (a[mid] != a[r]) // если правая отличается, то поиск в этой ПРАВОЙ половине
                {
                    return FindXElement(a, mid + 1, r, x);
                }

                int result = FindXElement(a, l, mid - 1, x); // поиск в левой половине
                if (result == -1) return FindXElement(a, mid + 1, r, x); // поиск в правой половине
                return result;
            }
            return -1;
        }
    }
}