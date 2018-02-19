using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch17
{
    /// <summary>
    ///     Find subsequense with max sum
    ///     http://e-maxx.ru/algo/maximum_average_segment
    /// </summary>
    public class Test178
    {
        [TestCase(new[] {2, 3, -8, -1, 2, 4, -2, 3}, Result = 7, TestName = "test1")]
        public int Test(int[] a)
        {
            return GetMaxSum(a);
        }

        /// <summary>
        ///     Kadane Algorithm
        ///     This  implemetation not accept all cases (all negs case)
        ///     Here full implemetation
        ///     http://stackoverflow.com/questions/9942228/kadane-algorithm-negative-numbers
        ///     http://www.geeksforgeeks.org/largest-sum-contiguous-subarray/
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        private static int GetMaxSum(IEnumerable<int> a)
        {
            int maxsum = 0, sum = 0;
            foreach (int t in a)
            {
                sum += t;
                if (sum > maxsum)
                {
                    maxsum = sum;
                }
                else if (sum < 0)
                {
                    sum = 0;
                }
            }
            return maxsum;
        }


        //https://leetcode.com/problems/maximum-subarray/
        /// <summary>
        ///    With handle of all neg values
        ///    //http://stackoverflow.com/questions/9942228/kadane-algorithm-negative-numbers
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            if (nums == null) return 0;
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
                 // kadane algo
            var maxSoFar = int.MinValue;
            var maxHere = 0;
            var maxElem = int.MinValue; // handle allnegative case
            int i = 0;
            while (i < nums.Length)
            {
                maxHere = Math.Max(maxHere + nums[i], 0);
                maxSoFar = Math.Max(maxHere, maxSoFar);
                maxElem = Math.Max(maxElem, nums[i]);
                i++;
            }
            if (maxSoFar == 0) maxSoFar = maxElem;
            return maxSoFar;
        }
    }
}