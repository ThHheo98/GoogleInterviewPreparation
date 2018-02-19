using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.DP
{
    public class MinJumps
    {
        [TestCase(new[] { 2, 3, 1, 1, 4 }, Result = 2)]
        public int Jump(int[] arr)
        {
            var arrLength = arr.Length;

            var jumps = new int[arrLength];

            jumps[0] = 0;

            // Find the minimum number of jumps to reach arr[i]
            // from arr[0], and assign this value to jumps[i]

            for (var i = 1;
                i < arrLength;
                i++)
            {
                jumps[i] = int.MaxValue;
                for (var j = 0;
                    j < i;
                    j++)
                {
                    if (i <= j + arr[j] && jumps[j] != int.MaxValue)
                    {
                        jumps[i] = Math.Min(jumps[i], jumps[j] + 1);
                        break;
                    }
                }
            }

            return jumps[arrLength - 1];
        }

        [TestCase(new[] { 2, 3, 1, 1, 4 }, Result = 2)]
        public int OJLeetCodeSolutionTree(int[] a)
        {
            var n = a.Length;
            if (n < 2)
                return 0;

            var jumps = 0;

            var currentMax = 0;
            var nextMax = 0;

            var i = 0;
            while (currentMax - i + 1 > 0)
            {
                //nodes count of current level>0
                jumps++;
                for (; i <= currentMax;
                    i++)
                {
                    //traverse current level , and update the max reach of next level
                    nextMax = Math.Max(nextMax, a[i] + i);
                    if (nextMax >= n - 1)
                        return jumps; // if last element is in level+1,  then the min jump=level
                }

                if (currentMax == nextMax)
                    return -1;

                currentMax = nextMax;
            }
            return -1;
        }
    }
}
