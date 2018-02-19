using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TwoPointers
{
    /*
     Let us first look at why 2 pointer approach works here. 
A naive 2 loop approach would be:

for (int i = 0; i < len; i++) {
  for (int j = i + 1; j < len; j++) {
    if (A[j] - A[i] > diff) break; // No need going forward as the difference is going to increase even further. 
    if (A[j] - A[i] == diff) return true; 
  }
}
Now, let us say that for i = I, we we exploring j.

At j = J - 1, our difference D1 was less than diff
At j = J, our difference D2 exceeded diff.
When i = I + 1, our A[i] increases ( as the array is sorted ). 
So, for j = J - 1, the differece will be smaller than D1 
(which is even more smaller to diff.) 
Which means we do not need to explore j <= J - 1 
and we can begin exploring directly from j = J. 
So, j only keeps moving in forward direction and never needs to come back as i increases.

Let us use that in a solution now:

int j = 0; 
for (int i = 0; i < len; i++) {
  j = max(j, i+1);
  while (arr[j] - arr[i] < diff) j += 1;
  if (arr[j] - arr[i] == diff) return true;
}
         */

    /// <summary>
    ///     https://www.interviewbit.com/problems/diffk/
    /// </summary>
    public class DiffK
    {
        [Test]
        public void Test()
        {
            var diff = Diff(new List<int> { 1, 3, 5 }, 4);
            Assert.AreEqual(1, diff);
        }

        private static int Diff(IReadOnlyList<int> list, int diff)
        {
            if (list.Count < 2 || diff < 0)
                return 0;
            int j = 0, len = list.Count;
            for (var i = 0;
                i < len - 1;
                i++)
            {
                j = Math.Max(j, i + 1);
                while (j < len && list[j] - list[i] < diff)
                    j += 1;
                if (j < len && list[j] - list[i] == diff)
                    return 1;
            }
            return 0;
        }
    }
}
