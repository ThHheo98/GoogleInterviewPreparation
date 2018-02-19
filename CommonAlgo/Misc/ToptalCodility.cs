using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.Misc
{
    public class ToptalCodility
    {
        private static int Equilibrium(int[] arr)
        {
            int sum = 0, leftsum = 0;

            foreach (var t in arr)
                sum += t;

            foreach (var t in arr)
            {
                sum -= t;
                if (leftsum == sum)
                    return t;
                leftsum += t;
            }

            return -1;
        }

        /**
 *        i-3
 *     +--------+
 *  i-4|        |
 *     +-----+  |
 *       i-5    |
 *              |i-2
 *        ^     |
 *       i|     |
 *        +-----+
 *          i-1
 */

        private static int SolutionTurtle(IReadOnlyList<int> arr)
        {
            for (var i = 0; i < arr.Count; ++i)
            {
                if (i >= 3 && arr[i - 3] >= arr[i - 1]
                    && (arr[i] >= arr[i - 2]
                        || (i >= 5
                            && arr[i - 5] >= arr[i - 3] - arr[i - 1]
                            && arr[i] >= arr[i - 2] - arr[i - 4])))
                {
                    return i + 1;
                }
            }
            return 0;
        }

        private static int[] Neg2Base(int m)
        {
            var result = new List<int>();
            while (m != 0)
            {
                var remainder = m%-2;
                m /= -2;

                if (remainder < 0)
                {
                    remainder += 2;
                    m++;
                }

                result.Add(remainder);
            }
            result.Reverse();
            return result.ToArray();
        }

        private int BitArrayToInt(int[] a, int @base)
        {
            var result = 0;
            for (var i = a.Length - 1; i >= 0; i--)
            {
                if (a[i] == 1)
                    result += (int) Math.Pow(@base, a.Length - i - 1);
            }
            return result;
        }

        [TestCase]
        public void TestEquilibrium()
        {
            var a = new[] {1, 2, 3, 4, 3, 2, 1};
            var i = Equilibrium(a);
            Assert.IsTrue(i == 4);
        }

        [TestCase]
        public void TestBinary()
        {
            var arr = new[] {1, 1, 0, 0, 1}; // 9 in -2 base
            var X = BitArrayToInt(arr, 2);
            var @base = Neg2Base(-X);
            var r = new[] {1, 0, 1, 1};
            Assert.IsTrue(r.Length == @base.Length);
            for (var i = 0; i < r.Length; i++)
            {
                Assert.IsTrue(r[i] == @base[i]);
            }
        }

        [TestCase]
        public void TestTurtle()
        {
            int[] arr = {1, 3, 2, 5, 4, 4, 6, 3, 2};
            var solution = SolutionTurtle(arr);
            Assert.IsTrue(solution == 7);
        }
    }
}