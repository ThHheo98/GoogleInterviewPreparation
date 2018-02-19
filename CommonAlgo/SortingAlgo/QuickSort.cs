namespace CommonAlgo.SortingAlgo
{
    public static class QuickSort
    {
        public static void ThreeWayQuickSort(int[] a, int lo, int hi)
        {
            if (lo < hi)
            {
                int gt = hi;
                int lt = lo;
                int i = lo;
                int p = a[lo];
                while (i<=gt)
                {
                    if (a[i]<p) Utils.Swap(a, i++,lt++);
                    else if (a[i] > p) Utils.Swap(a, i, gt--);
                    else i++;
                }
                ThreeWayQuickSort(a, lo, lt-1);
                ThreeWayQuickSort(a, gt+1, hi);
            }
        }

        public static void DualPivotQuickSort(int[] a, int lo, int hi)
        {
            if (lo < hi)
            {
                if (a[hi] < a[lo]) Swap(a, hi, lo);
                
                int lt = lo + 1;
                int gt = hi - 1;
                int i = lo + 1;
                while (i <= gt)
                {
                    if (a[i] < a[lo]) { Swap(a, i, lt); lt++; i++;  }
                    else if (a[hi] < a[i]) { Swap(a, i, gt); gt--; }
                    else i++;
                }
                Swap(a, lo, --lt);
                Swap(a, hi, ++gt);

                DualPivotQuickSort(a, lo, lt - 1);
                if (a[lt] < a[gt]) DualPivotQuickSort(a, lt + 1, gt - 1);
                DualPivotQuickSort(a, gt + 1, hi);
            }
        }

        private static void Swap(int[] a, int f, int s)
        {
            var t = a[f];
            a[f] = a[s];
            a[s] = t;
        }

        public static void Sort(int[] a, int l, int r)
        {
            if (l < r)
            {
                var p = Partition(a, l, r);
                Sort(a, l, p - 1);
                Sort(a, p, r);
            }
        }


        private static int Partition(int[] a, int l, int r)
        {
            var p = a[l + (r - l)/2];
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
    }
}