using System;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Greedy
{
    //http://www.programcreek.com/2014/03/leetcode-candy-java/
    //https://www.interviewbit.com/problems/distribute-candy/
    public class DisrtibuteCandies
    {
        [TestCase(new[] { 3, 1, 2, 2 }, Result = 6)]
        public int Test(int[] ratings)
        {
            if (ratings == null || ratings.Length == 0) return 0;

            var candies = new int[ratings.Length];

            // from left to right
            candies[0] = 1;
            for (var i = 1;
                i < ratings.Length;
                i++)
            {
                if (ratings[i] > ratings[i - 1])
                    candies[i] = candies[i - 1] + 1;
                else
                    candies[i] = 1;
            }

            // from right to left
            for (var i = candies.Length - 2;
                i >= 0;
                i--)
            {
                int currentCandyCount;
                if (ratings[i] > ratings[i + 1])
                    currentCandyCount = candies[i + 1] + 1;
                else
                    currentCandyCount = 1;

                candies[i] = Math.Max(currentCandyCount, candies[i]);
            }

            var r = 0;
            for (var i = 0;
                i < candies.Length;
                i++)
                r += candies[i];
            return r;
        }
    }
}
