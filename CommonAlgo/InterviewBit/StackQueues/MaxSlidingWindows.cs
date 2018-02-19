using System;
using System.Collections.Generic;
using CommonAlgo.ADT.Deque;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.StackQueues
{
    /// <summary>
    ///     http://articles.leetcode.com/sliding-window-maximum/
    ///     https://www.interviewbit.com/problems/sliding-window-max/
    /// </summary>
    public class MaxSlidingWindows
    {
        [Test]
        public void Test()
        {
            var maximum1 = slidingMaximum(new List<int> { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, 1);
            var maximum = slidingMaximum(new List<int>
            {
                90, 943, 777, 658, 742, 559, 623, 263, 880, 176, 354, 434, 699, 501, 551, 821, 563, 974, 701, 479, 238, 87, 61, 910, 204, 534, 369, 845, 566, 19, 939, 87, 708, 323, 662, 32, 655, 835, 67, 360, 550, 173, 488, 420, 680, 805, 630, 48, 791, 991, 791, 819, 772, 228, 123, 303, 642, 780, 115, 89, 919, 830, 271, 853, 588, 249, 20, 940, 851, 749, 340, 587, 235, 106, 125, 32, 319, 590, 354, 751, 761, 564, 484, 51, 202, 370, 216, 130, 146, 632
            }, 6);
        }

        public List<int> slidingMaximum(List<int> a, int w)
        {
            if (a == null)
                return new List<int>();

            var n = a.Count;

            if (n == 0)
                return new List<int>();

            if (w > n)
            {
                var mx = int.MinValue;
                for (var i = 0;
                    i < n;
                    i++)
                    mx = Math.Max(a[i], mx);
                return new List<int> { mx };
            }

            var ans = new List<int>();
            var dq = new Deque<int>();
            for (var i = 0;
                i < w;
                i++)
            {
                while (dq.Count > 0 && a[i] >= a[dq.GetAtBack()])
                    dq.RemoveFromBack();

                dq.AddToBack(i);
            }

            for (var i = w;
                i < n;
                i++)
            {
                ans.Add(a[dq.GetAtFront()]);

                while (dq.Count > 0 && a[i] >= a[dq.GetAtBack()]) // remove all that > than new value
                    dq.RemoveFromBack();

                while (dq.Count > 0 && dq.GetAtFront() <= i - w)
                    dq.RemoveFromFront();

                dq.AddToBack(i);
            }

            ans.Add(a[dq.GetAtFront()]);

            return ans;
        }
    }
}
