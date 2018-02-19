namespace CommonAlgo.SortingAlgo
{
    public static class SelectionSort
    {
        public static void Sort(int[] a)
        {
            for (var i = 0; i < a.Length; i++)
            {
                var minIdx = i;
                for (var j = i; j < a.Length; j++)
                    if (a[j] < a[minIdx]) minIdx = j;
                if (minIdx != i)
                    Utils.Swap(a, i, minIdx);
            }
        }
    }
}