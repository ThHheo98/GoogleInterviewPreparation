namespace CommonAlgo.SortingAlgo
{
    /// <summary>
    ///     Сортировка Шелла (англ. Shell sort) — алгоритм сортировки,
    ///     являющийся усовершенствованным вариантом сортировки вставками.
    ///     Идея метода Шелла состоит в сравнении элементов, стоящих не только рядом,
    ///     но и на определённом расстоянии друг от друга.
    ///     Иными словами — это сортировка вставками с предварительными «грубыми» проходами.
    /// </summary>
    public static class ShellSort
    {
        public static void Sort(int[] a)
        {
            var step = a.Length/2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < a.Length; i++)
                {
                    var value = a[i];
                    for (j = i - step; j >= 0 && a[j] > value; j -= step)
                        a[j + step] = a[j];

                    a[j + step] = value;
                }
                step /= 2;
            }
        }
    }
}