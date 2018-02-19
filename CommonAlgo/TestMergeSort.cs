using NUnit.Framework;

namespace CommonAlgo
{
    public class TestMergeSort
    {
        [TestCase(new[] {2, 8, 4, 9, 12, 7, 6, 3}, Result = new[] {2, 3, 4, 6, 7, 8, 9, 12}, TestName = "Test1")]
        public int[] Test(int[] a)
        {
            return Sort(a);
        }

        public int[] Sort(int[] a)
        {
            if (a.Length <= 1) return a;
            var l = new int[a.Length/2];
            var r = new int[a.Length - l.Length];

            for (int i = 0; i < l.Length; i++)
            {
                l[i] = a[i];
            }

            for (int i = 0; i < r.Length; i++)
            {
                r[i] = a[i + l.Length];
            }

            l = Sort(l);
            r = Sort(r);

            return Merge(l, r);
        }


        public int[] Merge(int[] l, int[] r)
        {
            int i = 0;
            int li = 0;
            int ri = 0;

            var res = new int[l.Length + r.Length];

            while (i < res.Length)
            {
                if (ri >= r.Length)
                {
                    res[i] = l[li++];
                }
                else if (li < l.Length && l[li] < r[ri])
                {
                    res[i] = l[li++];
                }
                else
                {
                    res[i] = r[ri++];
                }
                i++;
            }


            return res;
        }

        private static void Swap(int[] a, int f, int s)
        {
            int t = a[f];
            a[f] = a[s];
            a[s] = t;
        }

        [TestCase(new[] {2, 8, 4, 9, 12, 7, 6, 3}, Result = new[] {2, 3, 4, 6, 7, 8, 9, 12}, TestName = "Test1")]
        public int[] QSortTest(int[] a)
        {
            //  QSort(a, 0, a.Length - 1);
            Sort(a, 0, a.Length - 1);
            //qSort(a, 0, a.Length-1);

            return a;
        }


        public static void Sort(int[] a, int l, int r)
        {
            if (l < r)
            {
                int p = Partition(a, l, r);
                Sort(a, l, p - 1);
                Sort(a, p, r);
            }
        }


        private static int Partition(int[] a, int l, int r)
        {
            int p = a[l + (r - l) / 2];
            while (l <= r)
            {
                while (a[l] < p) l++;
                while (a[r] > p) r--;
                if (l <= r)
                {
                    Swap(a, l, r);
                    l++;
                    r--;
                }
                
            }
            return l;
        }

//        private int partition(int[] arr, int left, int right)
//        {
//            int i = left, j = right;
//            int pivot = arr[(left + right)/2];
//
//            while (i <= j)
//            {
//                while (arr[i] < pivot)
//                    i++;
//                while (arr[j] > pivot)
//                    j--;
//                if (i <= j)
//                {
//                    int tmp = arr[i];
//                    arr[i] = arr[j];
//                    arr[j] = tmp;
//                    i++;
//                    j--;
//                }
//            }
//
//            return i;
//        }
//
//        private void Sort(int[] arr, int left, int right)
//        {
//            if (left >= right) return;
//
//            int index = partition(arr, left, right);
//
//            Sort(arr, left, index - 1);
//
//            Sort(arr, index, right);
//        }
    }
}