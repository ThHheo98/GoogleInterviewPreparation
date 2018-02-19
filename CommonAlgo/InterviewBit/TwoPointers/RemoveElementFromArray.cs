using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TwoPointers
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/remove-element-from-array/
    ///     https://leetcode.com/articles/remove-element/
    /// </summary>
    public class RemoveElementFromArray
    {
        [Test]
        public void Test()
        {
            var el1 = removeElement1(new[] { 1, 2, 3, 4 }, 4);
            Assert.AreEqual(3, el1);
            var el2 = removeElement1(new[] { 1, 2, 3, 4 }, 4);
            Assert.AreEqual(3, el2);
        }

        public int removeElement1(int[] nums, int val)
        {
            var i = 0;
            for (var j = 0;
                j < nums.Length;
                j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }

        public int removeElement2(int[] nums, int val)
        {
            var i = 0;
            var n = nums.Length;
            while (i < n)
            {
                if (nums[i] == val)
                {
                    nums[i] = nums[n - 1];
                    // reduce array size by one
                    n--;
                }
                else
                {
                    i++;
                }
            }
            return n;
        }
    }
}
