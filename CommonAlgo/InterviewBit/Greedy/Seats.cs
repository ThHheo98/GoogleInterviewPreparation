using CommonAlgo.ADT.Deque;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Greedy
{
    /// <summary>
    ///     https://discuss.leetcode.com/topic/25877/minimum-number-of-jumps/3
    ///     https://www.interviewbit.com/problems/seats/
    /// </summary>
    /*
     * There is a row of seats. Assume that it contains N seats adjacent to each other. There is a group of people who are already seated in that row randomly. i.e. some are sitting together & some are scattered.

An occupied seat is marked with a character 'x' and an unoccupied seat is marked with a dot ('.')

Now your target is to make the whole group sit together i.e. next to each other, without having any vacant seat between them in such a way that the total number of hops or jumps to move them should be minimum.

Return minimum value % MOD where MOD = 10000003

Example

Here is the row having 15 seats represented by the String (0, 1, 2, 3, ......... , 14) -

             . . . . x . . x x . . . x . .

Now to make them sit together one of approaches is -
                 . . . . . . x x x x . . . . .

Following are the steps to achieve this -
1 - Move the person sitting at 4th index to 6th index -  
   Number of jumps by him =   (6 - 4) = 2

2 - Bring the person sitting at 12th index to 9th index - 
   Number of jumps by him = (12 - 9) = 3

So now the total number of jumps made = 
   ( 2 + 3 ) % MOD = 
   5 which is the minimum possible jumps to make them seat together.

There are also other ways to make them sit together but the number of jumps will exceed 5 and that will not be minimum.

For example bring them all towards the starting of the row i.e. start placing them from index 0. 
In that case the total number of jumps will be 
   ( 4 + 6 + 6 + 9 )%MOD 
   = 25 which is very costly and not an optimized way to do this movement



    */
    /*
         
             Actually we can use greedy algorithm, the idea is simple, every time we consider the people groups from left and right sides, 
             pick the group that has less people and move towards center, for example we have the following input:

. . X X . . . X X . . X X . . X X X . . .

there are two people in the far left group and three people in the far right group, so let's merge the people group from left, and we get the following:

. . . . . X X X X . . X X . . X X X . . .

now merge the far right group and we get:

. . . . . X X X X . . X X X X X . . . . .

finally we get:

. . . . . . . X X X X X X X X X . . . . .

Time complexity is O(n + k), where k is the number of group of people initially.
             */
    public class Seats
    {
        [TestCase]
        public void Test()
        {
            var a = new int[] { '.', '.', 'x', 'x', '.', '.', '.', 'x', 'x', '.', '.', 'x', 'x', '.', '.', 'x', 'x', 'x', '.', '.', '.' };
            // add all groups to deque
            var d = new Deque<P>();

            var j = 0;
            var n = a.Length;

            while (j < n)
            {
                while (j < n && a[j] == '.')
                    j++;
                if (j == n)
                    break;
                var i = j;
                while (j < n && a[j] == 'x')
                    j++;

                d.AddToBack(new P { start = i, end = j - 1 });
            }

            var cnt = 0;
            // merge all groups together
            if (d.Count > 1)
            {
                var left = d.GetAtFront();
                var right = d.GetAtBack();

                // decide what region need to merge
                var leftLen = left.end - left.start + 1;
                var rightLen = right.end - right.start + 1;

                if (leftLen < rightLen) // merge left region
                {
                    left = d.RemoveFromFront();
                    cnt = cnt + leftLen * (d.GetAtFront().start - left.end - 1);
                    d.GetAtFront().start -= leftLen;
                }
                else // merge right region
                {
                    right = d.RemoveFromBack();
                    cnt = cnt + rightLen * (right.start - d.GetAtBack().end - 1);
                    d.GetAtBack().end += rightLen;
                }
            }

            Assert.AreEqual(6, cnt);
        }

        public class P
        {
            public int end;
            public int start;

            public override string ToString()
            {
                return $"{nameof(start)}: {start}, {nameof(end)}: {end}";
            }
        }
    }

    internal class Solution
    {
        [TestCase(Result = 5)]
        public int seats()
        {
            var a = ".x.x.x.xx.";

            var d = new Deque<P>();

            var j = 0;
            var n = a.Length;

            while (j < n)
            {
                while (j < n && a[j] == '.')
                    j++;
                if (j == n)
                    break;
                var i = j;
                while (j < n && a[j] == 'x')
                    j++;

                d.AddToBack(new P { start = i, end = j - 1 });
            }

            long cnt = 0;
            // merge all groups together
            while (d.Count > 1)
            {
                var left = d.GetAtFront();
                var right = d.GetAtBack();

                // decide what region need to merge
                var leftLen = left.end - left.start + 1;
                var rightLen = right.end - right.start + 1;

                if (leftLen < rightLen) // merge left region
                {
                    left = d.RemoveFromFront();
                    cnt = cnt + leftLen * (d.GetAtFront().start - left.end - 1);
                    cnt = cnt % 10000003;
                    d.GetAtFront().start -= leftLen;
                }
                else // merge right region
                {
                    right = d.RemoveFromBack();
                    cnt = cnt + rightLen * (right.start - d.GetAtBack().end - 1);
                    cnt = cnt % 10000003;
                    d.GetAtBack().end += rightLen;
                }
            }
            return (int)cnt;
        }

        public class P
        {
            public int end;
            public int start;
        }
    }
}
