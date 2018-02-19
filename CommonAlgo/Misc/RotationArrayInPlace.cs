using NUnit.Framework;

namespace CommonAlgo.Misc
{
    // https://leetcode.com/problems/rotate-array/
    public class RotationArrayInPlace
    {
        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 3, Result = new[] {4, 5, 6, 7, 8, 9, 1, 2, 3})]
        public int[] TestLeft(int[] a, int k)
        {
            RotateLeft(a, k);
            return a;
        }

        [TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9}, 3, Result = new[] {7, 8, 9, 1, 2, 3, 4, 5, 6})]
        public int[] TestRight(int[] a, int k)
        {
            RotateRight(a, k);
            return a;
        }

        private static void RotateLeft(int[] a, int k)
        {
            if (a == null) return;
            if (a.Length <= 1) return;
            if (k > a.Length) k = k % a.Length;
            ReverseArray(a, 0, k - 1);
            ReverseArray(a, k, a.Length - 1);
            ReverseArray(a, 0, a.Length - 1);
        }

        private static void RotateRight(int[] a, int k)
        {
            if (a == null) return;
            if (a.Length <= 1) return;
            if (k > a.Length) k = k % a.Length;
            ReverseArray(a, 0, a.Length - k - 1);
            ReverseArray(a, a.Length - k, a.Length - 1);
            ReverseArray(a, 0, a.Length - 1);
        }

        private static void ReverseArray(int[] a, int s, int e)
        {
            while (s < e)
            {
                var t = a[s];
                a[s] = a[e];
                a[e] = t;

                s++;
                e--;
            }
        }
    }
}