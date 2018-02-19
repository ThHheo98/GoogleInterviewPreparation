using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TwoPointers
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/counting-triangles/
    /// </summary>
    /*
        First we sort the array of side lengths. So since Ai < Aj < Ak where i < j < k, 
        therefore it is sufficient to check Ai + Aj > Ak to prove they form a triangle.
        Thus for every i and j, we can find the maximum value of k such that the triangle inequality holds.
        Also we can also prove that for every such index i, we only have to increase the value of the k
        (satisfying the above condition) for every iteration of j from i+1 to n.
        Therefore, we get a O(n2) solution (Proof of this is left to the reader).
    */
    public class CountingTriangles
    {
        [Test]
        public void Test()
        {
            var triang = NTriang(new List<int> { 1, 1, 1, 2, 2 });
            Assert.AreEqual(4, triang);
        }

        private static int NTriang(List<int> a)
        {
            if (a == null || a.Count == 0 || a.Count < 3) return 0;

            var n = a.Count;

            var ans = 0;

            a = a.OrderBy(i => i).ToList();

            for (var i = 0;
                i < n - 2;
                ++i)
            {
                var k = i + 2;

                for (var j = i + 1;
                    j < n - 1;
                    j++)
                {
                    while (k < n && a[i] + a[j] > a[k]) k++;

                    ans += k - j - 1;
                    if (ans >= 1000000007) ans = ans % 1000000007;
                }
            }

            return ans;
        }
    }
}
