using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch17
{
    /// <summary>
    /// FindUnsortedSequence
    /// </summary>
    public class Test176
    {
        [TestCase(new[] {1, 2, 3, 9, 8, 10, 11, 12}, 2, 4)]
        public void Test(int[] a, int l, int r)
        {
            Tuple<int, int> findUnsortedSequence = FindUnsortedSequence(a);
            Assert.IsTrue(l == findUnsortedSequence.Item1);
            Assert.IsTrue(r == findUnsortedSequence.Item2);
        }

        private int FindEndOfLeftSubsequence(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < a[i - 1]) return i - 1;
            }
            return a.Length - 1;
        }

        private int FindStartOfRightSubsequnce(int[] a)
        {
            for (int i = a.Length - 2; i >= 0; i--)
            {
                if (a[i] > a[i + 1]) return i + 1;
            }
            return 0;
        }

        private int ShrinkLeft(int[] a, int min_index, int start)
        {
            int comp = a[min_index];
            for (int i = start - 2; i >= 0; i--)
            {
                if (a[i] <= comp) return i + 1;
            }
            return 0;
        }

        private int ShrinkRight(int[] a, int max_index, int start)
        {
            int comp = a[max_index];
            for (int i = start; i < a.Length; i++)
            {
                if (a[i] >= comp) return i - 1;
            }
            return a.Length - 1;
        }

        private Tuple<int, int> FindUnsortedSequence(int[] a)
        {
            // находим левую подпоследовательность
            int end_left = FindEndOfLeftSubsequence(a);

            // находим правую подпоследовательность
            int start_right = FindStartOfRightSubsequnce(a);

            // находим минимальный и максимальный элемент середины
            int min_index = end_left + 1;
            if (min_index >= a.Length) return new Tuple<int, int>(-1, -1);
            int max_index = start_right - 1;


            for (int i = end_left; i <= start_right; i++)
            {
                if (a[i] < a[min_index]) min_index = i;
                if (a[i] > a[max_index]) max_index = i;
            }


            // понижаем левую, пока меньше, чем [min_index]
            int left_index = ShrinkLeft(a, min_index, end_left);

            // понижаем правую, пока больше, чем [max_index]
            int right_index = ShrinkRight(a, max_index, start_right);

            Console.WriteLine(left_index + " " + right_index);
            return new Tuple<int, int>(left_index, right_index);
        }
    }
}