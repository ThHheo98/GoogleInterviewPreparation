using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Hashing
{
    /// <summary>
    /// https://www.interviewbit.com/problems/4-sum/
    /// http://www.programcreek.com/2013/02/leetcode-4sum-java/
    /// </summary>
    /*
     Given an array S of n integers, are there elements a, b, c, and d in S such 
     that a + b + c + d = target? Find all unique quadruplets in the array which gives 
     the sum of target.

 Note:
Elements in a quadruplet (a,b,c,d) must be in non-descending order. (ie, a ≤ b ≤ c ≤ d)
The solution set must not contain duplicate quadruplets.
Example : 
Given array S = {1 0 -1 0 -2 2}, and target = 0
A solution set is:

    (-2, -1, 1, 2)
    (-2,  0, 0, 2)
    (-1,  0, 0, 1)
Also make sure that the solution set is lexicographically sorted.
Solution[i] < Solution[j] iff Solution[i][0] < Solution[j][0] 
OR (Solution[i][0] == Solution[j][0] AND ... Solution[i][k] < Solution[j][k])
The naive approach obviously is exloring all combinations of 4 integers using 4 loops.

Now, to look into improving, does it help if we sort the array ?

Also, think of how your approach would change if you did not have to list all
of the unique tuples but just tell whether at least one such tuple existed ( YES / NO ).
When the array is sorted, try to fix the least and second least integer by looping over it.
Lets say the least integer in the solution is arr[i] and second least is arr[j].
Now we need to find a pair of integers k and l such that arr[k] + arr[l] is target-arr[i]-arr[j]. 
To do that, lets try the 2 pointer approach. If we fix the two pointers at the end ( that is, j+1 and end of array ), we look at the sum.
If the sum is smaller than the sum we want, we increase the first pointer to increase the sum.
If the sum is bigger than the sum we want, we decrease the end pointer to reduce the sum.

Note that there is one more solution possible if the question only asked to answer YES / NO to suggest whether there existed at least one tuple with the target sum. 
Then we could have gone with an approach using more memory with hashing.

        Getting a Time Limit exceeded or Output Limit exceeded ?

Make sure you handle case of empty input []. In C++/C, Usually if you run a loop till array.size() - 2, it can lead to the program running indefinitely as array.size() is unsigned int, and the subtraction just makes it wrap over to a big integer.

Make sure you are not processing the same triplets again. Skip over the duplicates in the array. 
Try a input like : 
-1 -1 -1 -1 0 0 0 0 1 1 1 1
Ideally, you should get only 3 pairs : {[-1 -1 1 1], [-1 0 0 1], [0 0 0 0]}
         */
    public class _4Sum
    {
        [Test]
        public void Test()
        {
            var list = Sum(new List<int> { 1, 0, -1, 0, -2, 2 }, 0);
            Assert.AreEqual(3, list.Count);
            var q = new Queue<List<int>>();
            q.Enqueue(new List<int> { -2, -1, 1, 2 });
            q.Enqueue(new List<int> { -2, 0, 0, 2 });
            q.Enqueue(new List<int> { -1, 0, 0, 1 });
            var i = 0;
            while (q.Count > 0)
            {
                CollectionAssert.AreEqual(q.Dequeue(), list[i]);
                i++;
            }
        }

        private List<List<int>> Sum(List<int> a, int b)
        {
            if (a == null) return null;
            if (a.Count < 4) return new List<List<int>>();

            a = a.OrderBy(i1 => i1).ToList();
            var hs = new HashSet<List<int>>();

            var res = new List<List<int>>();

            for (var i = 0; i < a.Count - 3; i++)
            {
                if (i != 0 && a[i] == a[i - 1]) continue;
                for (var j = i + 1; j < a.Count - 2; j++)
                {
                    if (j != i + 1 && a[j] == a[j - 1]) continue;
                    var k = j + 1;
                    var l = a.Count - 1;
                    while (k < l)
                    {
                        if (a[i] + a[j] + a[k] + a[l] < b)
                        {
                            k++;
                        }
                        else if (a[i] + a[j] + a[k] + a[l] > b)
                        {
                            l--;
                        }
                        else
                        {
                            var list = new List<int>();
                            list.Add(a[i]);
                            list.Add(a[j]);
                            list.Add(a[k]);
                            list.Add(a[l]);

                            if (!hs.Contains(list))
                            {
                                res.Add(list);
                                hs.Add(list);
                            }

                            k++;
                            l--;

                            while (k < l && a[l] == a[l + 1]) l--;
                            while (k < l && a[k] == a[k - 1]) k++;
                        }
                    }
                }
            }

            return res;
        }
    }
}
