using NUnit.Framework;

namespace CommonAlgo.SortingAlgo
{
    public class BinSearch
    {
        public static int NoRecursionBinarySearch(int[] a, int lo, int hi, int key)
        {
            while (hi - lo > 1)
            {
                var m = lo + (hi - lo)/2;
                if (a[m] > key) hi = m;
                else if (a[m] <= key) lo = m;
            }
            return lo;
        }

        public static int RecursiveBinSearch(int[] a, int lo, int hi, int key)
        {
            if (lo > hi) return -1;
            var m = lo + (hi - lo)/2;
            if (a[m] == key) return m;
            if (a[m] < key) return RecursiveBinSearch(a, m + 1, hi, key);
            if (a[m] > key) return RecursiveBinSearch(a, lo, m - 1, key);
            return -1;
        }

        public static int NoRecursionBinarySearchFastImplementation(int[] a, int lo, int hi, int key)
        {
            while (hi - lo > 1)
            {
                var m = lo + (hi - lo)/2;
                if (a[m] > key) hi = m;
                else if (a[m] <= key) lo = m;
            }
            return lo;
        }


        [TestCase]
        public void TestNoRecursionBinarySearch()
        {
            var a = new[] {1, 2, 3, 4, 5};
            var key = 4;
            var res = NoRecursionBinarySearch(a, 0, a.Length - 1, key);
            Assert.IsTrue(key == a[res]);
        }

        [TestCase]
        public void TestNoRecursionBinarySearch1()
        {
            var a = new[] {1, 2, 3, 4, 5};
            var key = 4;
            var res = NoRecursionBinarySearchFastImplementation(a, 0, a.Length - 1, key);
            Assert.IsTrue(key == a[res]);
        }

        [TestCase]
        public void TestRecursionBinarySearch()
        {
            var a = new[] {1, 2, 3, 4, 5};
            var key = 4;
            var res = RecursiveBinSearch(a, 0, a.Length - 1, key);
            Assert.IsTrue(key == a[res]);
        }
    }

    [TestFixture]
    public class Tests
    {
        [TestCase(new[] {5, 4, 2, 1, 6, 7, 8}, Result = new[] {1, 2, 4, 5, 6, 7, 8})]
        public int[] InsertionSortTest(int[] a)
        {
            InsertionSort.Sort(a);
            Utils.PrintCollection(a);
            return a;
        }

        [TestCase(new[] {5, 4, 2, 1, 6, 7, 8}, Result = new[] {1, 2, 4, 5, 6, 7, 8})]
        public int[] ShellSortTest(int[] a)
        {
            ShellSort.Sort(a);
            Utils.PrintCollection(a);
            return a;
        }

        [TestCase(new[] {5, 4, 2, 1, 6, 7, 8}, Result = new[] {1, 2, 4, 5, 6, 7, 8})]
        public int[] SelectionSortTest(int[] a)
        {
            SelectionSort.Sort(a);
            Utils.PrintCollection(a);
            return a;
        }

        [TestCase(new[] {5, 4, 2, 1, 6, 7, 8}, Result = new[] {1, 2, 4, 5, 6, 7, 8})]
        public int[] QuickSortTest(int[] a)
        {
            QuickSort.Sort(a, 0, a.Length - 1);
            Utils.PrintCollection(a);
            return a;
        }

        [TestCase(new[] {5, 4, 2, 1, 6, 7, 8}, Result = new[] {1, 2, 4, 5, 6, 7, 8})]
        public int[] QuickSort3WayTest(int[] a)
        {
            Utils.PrintCollection(a);
            QuickSort.ThreeWayQuickSort(a, 0, a.Length - 1);
            Utils.PrintCollection(a);
            return a;
        }

        [TestCase(new[] {5, 4, 2, 1, 6, 7, 8}, Result = new[] {1, 2, 4, 5, 6, 7, 8})]
        public int[] DualPivotQuickSortTest(int[] a)
        {
            Utils.PrintCollection(a);
            QuickSort.DualPivotQuickSort(a, 0, a.Length - 1);
            Utils.PrintCollection(a);
            return a;
        }

        [TestCase(new[] {5, 4, 2, 1, 6, 7, 8}, Result = new[] {1, 2, 4, 5, 6, 7, 8})]
        public int[] MergeSortTest(int[] a)
        {
            var test = (int[]) MergeSort.Sort(a);
            Utils.PrintCollection(a);
            Utils.PrintCollection(test);
            return test;
        }

        [TestCase(new[] {8, 1, 9, 4, 2, 6, 16, 11, 5, 10}, Result = new[] {1, 2, 4, 5, 6, 8, 9, 10, 11, 16})]
        public int[] HeapTest(int[] a)
        {
            var sort = HeapSort.Sort(a);
            Utils.PrintCollection(sort);
            return a;
        }

        [TestCase(new[] {8, 1, 9, 4, 2, 6, 16, 11, 5}, Result = new[] {1, 2, 4, 5, 6, 8, 9, 11, 16})]
        public int[] HeapTest1(int[] a)
        {
            var sort = HeapSort.Sort(a);
            Utils.PrintCollection(sort);
            return a;
        }
    }
}