using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Hashing
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/2-sum/
    ///     https://leetcode.com/articles/two-sum/ editoral solution
    /// </summary>
    /*
     Given an array of integers, find two numbers such that they add up to a specific target number.

The function twoSum should return indices of the two numbers such that they add up to the target, where index1 < index2. Please note that your returned answers (both index1 and index2 ) are not zero-based. 
Put both these numbers in order in an array and return the array from your function ( Looking at the function signature will make things clearer ). Note that, if no pair exists, return empty list.

If multiple solutions exist, output the one where index2 is minimum. If there are multiple solutions with the minimum index2, choose the one with minimum index1 out of them.

Input: [2, 7, 11, 15], target=9
Output: index1 = 1, index2 = 2
O(n^2) runtime, O(1) space – Brute force:


        The brute force approach is simple. 
        Loop through each element x and find if there is another value that equals to target – x. 
        As finding another value requires looping through the rest of array, its runtime complexity is O(n^2).

        To improve on it, notice that when we fix one of the integers ‘curValue’, we know the value of the other integer we need to find ( target - curValue ). 
        Then it becomes a simple search problem. You can store all the integers of the array in a hashmap and do a lookup to check if the elements exists in the map.
        
        Have you checked cases where the element you are looking up in the map is same as the curValue.

        For example, consider the following cases :

        A:[4 4] target : 8 
        and A :[3 4] target : 8

        The answer in first case should be [1 2] and in second case, it should be empty.

         */
    public class TwoSum
    {
        [Test]
        public void Test()
        {
            var list = twoSum(new List<int> { 4, 7, -4, 2, 2, 2, 3, -5, -3, 9, -4, 9, -7, 7, -1, 9, 9, 4, 1, -4, -2, 3, -3, -5, 4, -7, 7, 9, -4, 4, -8 }, -3);
            Assert.AreEqual(4, list[0]);
            Assert.AreEqual(8, list[1]);

            var ints = twoSum(new List<int> { 1, 1, 1 }, 2);
            Assert.AreEqual(1, ints[0]);
            Assert.AreEqual(2, ints[1]);
        }

        public List<int> twoSum(List<int> a, int b)
        {
            var d = new Dictionary<int, List<int>>();
            var ans = new List<int>();

            for (var i = 0; i < a.Count; i++)
            {
                if (!d.ContainsKey(a[i]))
                {
                    d[a[i]] = new List<int>();
                    d[a[i]].Add(i);
                }
                else
                {
                    d[a[i]].Add(i);
                }
            }

            Console.WriteLine();
            for (var i = 0; i < a.Count; i++)
            {
                var complement = b - a[i];
                if (d.ContainsKey(complement))
                {
                    var i1 = i;
                    var i2 = i;
                    var j = 0;
                    while (j < d[complement].Count)
                    {
                        if (d[complement][j] != i)
                        {
                            i2 = d[complement][j];
                            j = d[complement].Count;
                        }
                        j++;
                    }

                    if (i1 < i2)
                        if (ans.Count == 0)
                        {
                            ans.Add(i1);
                            ans.Add(i2);
                        }
                        else
                        {
                            if (ans[ans.Count - 1] > i2)
                            {
                                ans.RemoveAt(ans.Count - 1);
                                ans.RemoveAt(ans.Count - 1);
                                ans.Add(i1);
                                ans.Add(i2);
                            }
                        }
                }
            }

            if (ans.Count > 0)
            {
                ans[0]++;
                ans[1]++;
            }

            return ans;
        }
    }
}
