using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.StackQueues
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/rain-water-trapped/
    ///     https://discuss.leetcode.com/topic/5125/sharing-my-simple-c-code-o-n-time-o-1-space/2
    ///     http://www.geeksforgeeks.org/trapping-rain-water/
    /// </summary>
    public class RainWaterTrapped
    {
        /*
         Here is my idea: instead of calculating area by height*width, we can think it in a cumulative way. 
         In other words, sum water amount of each bin(width=1).
Search from left to right and maintain a max height of left and right separately, which is like 
a one-side wall of partial container. Fix the higher one and flow water from the lower part. For example, 
if current height of left is lower, 
we fill water in the left bin. Until left meets right, we filled the whole container.
         */

        [Test]
        public void Test2()
        {
            var a = new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var volume = GetVolume1(a);
            Assert.AreEqual(6, volume);
            Console.WriteLine("Volume {0}", volume);
        }

        private int GetVolume1(int[] a)
        {
            var left = 0;
            var right = a.Length - 1;
            var leftMax = 0;
            var rightMax = 0;
            var vol = 0;
            while (left <= right)
            {
                if (a[left] <= a[right])
                {
                    if (a[left] >= leftMax)
                        leftMax = a[left];
                    else
                        vol += leftMax - a[left];
                    left++;
                }
                else
                {
                    if (a[right] >= rightMax)
                        rightMax = a[right];
                    else
                        vol += rightMax - a[right];
                    right--;
                }
            }
            return vol;
        }
    }
}
