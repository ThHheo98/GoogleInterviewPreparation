using System.Collections.Generic;

namespace CommonAlgo.InterviewBit.BinarySearch
{
    public class RotatedArraySearch
    {
        public int search(List<int> a, int b)
        {
            if (a == null || a.Count == 0)
                return -1;

            return fm(a, b);
        }

        private int fm(List<int> a, int b)
        {
            var start = 0;
            var end = a.Count - 1;

            while (start <= end)
            {
                var m = start + (end - start) / 2;

                if (a[m] == b)
                    return m;

                // left part is sorted
                if (a[start] <= a[m])
                {
                    if (a[start] <= b && b < a[m])
                        end = m - 1;
                    else
                        start = m + 1;
                }
                else
                {
                    // right part is sorted
                    if (a[m] < b && b <= a[end])
                        start = m + 1;
                    else
                        end = m - 1;
                }
            }

            return -1;
        }
    }
}
