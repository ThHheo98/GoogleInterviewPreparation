using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.StackQueues
{
    /// <summary>
    ///     http://www.geeksforgeeks.org/find-the-nearest-smaller-numbers-on-left-side-in-an-array/
    ///     https://www.interviewbit.com/problems/nearest-smaller-element/
    /// </summary>
    public class NearestSmallerElements
    {
        [Test]
        public void Test()
        {
            var smaller = prevSmaller(new List<int> { 1, 2, 3 });
            Assert.AreEqual(-1, smaller[0]);
            Assert.AreEqual(1, smaller[1]);
            Assert.AreEqual(2, smaller[2]);
        }

        public List<int> prevSmaller(List<int> list)
        {
            var s = new Stack<int>();

            var ans = new int[list.Count];

            for (var i = 0;
                i < list.Count;
                i++)
            {
                while (s.Count > 0 && s.Peek() >= list[i])
                    s.Pop();

                if (s.Count == 0)
                    ans[i] = -1;
                else
                    ans[i] = s.Peek();

                s.Push(list[i]);
            }

            return ans.ToList();
        }
    }
}
