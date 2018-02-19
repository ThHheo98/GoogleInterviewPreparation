using System;
using NUnit.Framework;

namespace CommonAlgo.SearchAlgo
{
    [TestFixture]
    public class BinarySearch
    {
        /// <summary>
        /// the floor is the greatest element smaller than or equal to x
        /// </summary>
        /// <param name="a"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [TestCase(new[] {1, 2, 3, 6, 7, 8, 9}, 5, Result = 3)]
        public int BinarySearchFloor(int[] a, int key) // ближайшее левое (меньшее или равно) число
        {
            if (key <= a[0])
                return -1;
            var binarySearchFloor = BinarySearchFloor(a, 0, a.Length, key);
            return binarySearchFloor;
        }

        /// <summary>
        /// the ceiling of x is the smallest element in array greater than or equal to x,
        /// </summary>
        /// <param name="a"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [TestCase(new[] {1, 2, 3, 4, 8, 9}, 7, Result = 8)]
        public int BinarySearchCeil(int[] a, int key) // ближайшее правое (больше или равно) число
        {
            if (key <= a[0])
                return -1;
            var binarySearchCeil = BinarySearchCeil(a, 0, a.Length, key);
            return binarySearchCeil;
        }

        private static int BinarySearchCeil(int[] a, int l, int r, int key)
        {
            int m;
            // Invariant: A[l] >= key and A[r] > key
            while (r - l > 1)
            {
                m = l + (r - l)/2;
                if (a[m] >= key)
                {
                    r = m;
                }
                else
                {
                    l = m;
                }
                Console.WriteLine(m);
                Console.WriteLine(l);
                Console.WriteLine(r);
            }
            return a[r];
        }

        private int BinarySearchFloor(int[] a, int l, int r, int key)
        {
            int m;

            // invariant: a[l] <= key and a[r] > key
            while (r - l > 1)
            {
                m = l + (r - l)/2;
                if (a[m] <= key)
                {
                    l = m;
                }
                else
                {
                    r = m;
                }
            }
            return a[l];
        }

        [TestCase(new[] {6, 7, 8, 9, 10, 1, 2, 3, 4, 5}, Result = 5, TestName = "test2")]
        [TestCase(new[] {6, 7, 8, 9, 10, 11, 1, 2, 3, 4, 5}, Result = 6, TestName = "test1")]
        public int BinarySearchIndexOfMinimumRotatedArray(int[] a)
        {
            return BinarySearchIndexOfMinimumRotatedArray(a, 0, a.Length - 1);
        }

        private int BinarySearchIndexOfMinimumRotatedArray(int[] a, int l, int r)
        {
            int m;
            if (a[l] <= a[r]) // если массив не сдвинут
                return l; // возвращаем минимальный элемент

            while (l <= r) // пока индексы  не указывают на будем сужать пространство поиска
            {
                if (l == r) // проверка нужна потому что цикле еще учитывается l < r
                    return l;
                m = l + (r - l)/2; // находим медиану безопасным в плане переполнения способом от Google
                if (a[m] < a[r]) // т.к. a[m] меньше максимального значения в правой части (a[r]) и массив отсортирован,
                    r = m; // то мы можем не рассматривать элементы от m+1 до r. Пример:  12 15 35 3 4 5 6 7 8 9 
                // Медиана = 4, a[m] = 4 a[r] = 9 => числа от 5 до 9 
                // можно не учитывать, они всяко больше, чем a[m] (все из - за свойства сортированности)
                else
                    l = m + 1;
                // иначе число a[m] попадает в первый пульс (см. http://goo.gl/DUX0OO) и поэтому числа слева от 
                // а[m]  тоже больше, чем ИСКОМОЕ минимальное значение (снова из-за сортированности)
                //  см. BinarySearchIndexOfMinimumRotatedArray.jpg
            }
            return -1;
        }

        public static int BinarySearchIndexOfMinimumRotatedArray1(int[] a, int lo, int hi)
        {
            if (a[lo] <= a[hi]) return lo;
            while (lo <= hi)
            {
                if (lo == hi) return lo;
                var m = lo + (hi - lo)/2;
                if (a[m] < a[hi])
                    hi = m;
                else lo = m + 1;
            }
            return -1;
        }

        [TestCase(new[] {6, 7, 8, 9, 10, 1, 2, 3, 4, 5}, Result = 5, TestName = "test4")]
        [TestCase(new[] {6, 7, 8, 9, 10, 11, 1, 2, 3, 4, 5}, Result = 6, TestName = "test5")]
        public int BinarySearchIndexOfMinimumRotatedArray1(int[] a)
        {
            return BinarySearchIndexOfMinimumRotatedArray1(a, 0, a.Length - 1);
        }

        [TestCase(new[] {8, 9, 10, 11, 1, 2, 3, 4, 5, 6, 7}, Result = 3, TestName = "test1")]
        [TestCase(new[] {4, 5, 6, 7, 1, 2, 3}, Result = 3, TestName = "test2")]
        public int BinarySearchIndexOfMaximumRotatedArray(int[] a)
        {
            return BinarySearchIndexOfMaximumRotatedArray(a, 0, a.Length - 1);
        }


        private int BinarySearchIndexOfMaximumRotatedArray(int[] a, int lo, int hi)
        {
            int m;
            if (a[lo] <= a[hi]) // если массив не сдвинут
                return lo - 1; // возвращаем минимальный элемент

            while (lo <= hi) // пока индексы  не указывают на будем сужать пространство поиска
            {
                if (lo == hi) // проверка нужна потому что цикле еще учитывается l < r
                    return lo - 1;
                m = lo + (hi - lo)/2; // находим медиану безопасным в плане переполнения способом от Google
                if (a[m] < a[hi])
                    // т.к. a[m] меньше максимального значения в правой части (a[r]) и массив отсортирован,
                    hi = m; // то мы можем не рассматривать элементы от m+1 до r. Пример:  12 15 35 3 4 5 6 7 8 9 
                // Медиана = 4, a[m] = 4 a[r] = 9 => числа от 5 до 9 
                // можно не учитывать, они всяко больше, чем a[m] (все из - за свойства сортированности)
                else
                    lo = m + 1;
                // иначе число a[m] попадает в первый пульс (см. http://goo.gl/DUX0OO) и поэтому числа слева от 
                // а[m]  тоже больше, чем ИСКОМОЕ минимальное значение (снова из-за сортированности)
                //  см. BinarySearchIndexOfMinimumRotatedArray.jpg
            }
            return -1;
        }
    }
}