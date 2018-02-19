using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.StackQueues
{
    /// <summary>
    ///     https://www.youtube.com/watch?v=ZmnqCZp9bBs
    ///     https://www.interviewbit.com/problems/largest-rectangle-in-histogram/
    ///     http://www.programcreek.com/2014/05/leetcode-largest-rectangle-in-histogram-java/
    ///     http://www.geeksforgeeks.org/largest-rectangle-under-histogram/
    ///     http://www.geeksforgeeks.org/largest-rectangular-area-in-a-histogram-set-1/
    /// </summary>
    public class LargestRectangleArea
    {
        [Test]
        public void Test()
        {
            var rectangleArea = largestRectangleArea(new List<int> { 2, 1, 5, 6, 2, 3 });
            Assert.AreEqual(10, rectangleArea);
        }

        public int largestRectangleArea(List<int> a)
        {
            var s = new Stack<int>();
            var i = 0;
            var max = int.MinValue;

            while (i < a.Count)
            {
                if (s.Count == 0 || a[i] >= a[s.Peek()])
                {
                    s.Push(i);
                    i++;
                }
                else
                {
                    var idx = s.Pop();
                    var h = a[idx];
                    var w = s.Count == 0 ? i : i - s.Peek() - 1;
                    max = Math.Max(max, h * w);
                }
            }

            while (s.Count > 0)
            {
                var idx = s.Pop();
                var h = a[idx];
                var w = s.Count == 0 ? i : i - s.Peek() - 1;
                max = Math.Max(max, h * w);
            }

            return max;
        }
    }
}
