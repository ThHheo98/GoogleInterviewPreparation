using System;
using System.Collections.Generic;

namespace CommonAlgo.SortingAlgo
{
    /// <summary>
    /// Generic Merge Sort
    /// </summary>
    public static class MergeSort
    {        
        public static IList<T> Sort<T>(IList<T> arr)
        {
            if (arr == null) throw new ArgumentNullException();
            if (arr.Count <= 1) return arr;

            IList<T> left = new T[arr.Count / 2];
            IList<T> right = new T[arr.Count - left.Count];
            int i = 0;
            while (i < left.Count) { left[i] = arr[i]; i++; }
            i = 0;
            while (i < right.Count) { right[i] = arr[i + left.Count]; i++; }
            left = Sort(left);
            right = Sort(right);
            return Merge(left, right);
        }

        private static IList<T> Merge<T>(IList<T> left, IList<T> right)
        {
            if (left == null) throw new ArgumentNullException();
            if (right == null) throw new ArgumentNullException();
            IList<T> res = new T[left.Count + right.Count];
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < left.Count && j < right.Count)
            {
                if (Comparer<T>.Default.Compare(left[i], right[j]) < 0) res[k] = left[i++];
                else res[k] = right[j++];
                k++;
            }
            while (i < left.Count) res[k++] = left[i++];
            while (j < right.Count) res[k++] = right[j++];
            return res;
        }
    }
}