using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.Graphs
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/smallest-multiple-with-0-and-1/
    /// </summary>
    public class Multiply0and1
    {
        /*
        Let’s represent our numbers as strings here. Now, consider there are N states, 
        where i’th state stores the smallest string which when take modulo with N gives i.
        Our aim is to reach state 0. Now, we start from state “1” and at each step we have two options, 
        either to append “0” or “1” to current state. We try to explore both the options, 
        but note that if I have already visited a state, why would I visit it again? 
        It already stores the smallest string which achieves that state and if I visit it again with a 
        new string it will surely have more characters than already stored string.

So, this is basically a BFS on the states. We’ll visit a state atmost once, hence overall complexity is O(N). 
Interesting thing is that I need not store the whole string for each state, 
I can just store the value modulo N and I can easily see which two new states I am going to.

But, how do we build the solution?
If I reach a state x, I store two values
- From which node I arrived at node x from. Say this is node y.
- What(0 or 1) did I append at string at node y to reach node x

Using this information, I can build my solution by repeatedly going to parents starting from node 0.

        */

        [TestCase(2, Result = "10"), TestCase(55, Result = "110")]
        public string Test(int a)
        {
            var was = new bool[a];
            var values = new int[a];
            var parents = new int[a];

            return Solve(was, values, parents, a);
        }

        private static string Solve(bool[] was, int[] values, int[] parents, int n)
        {
            var q = new Queue<int>();

            // initial values
            values[1] = 1;
            was[1] = true;
            q.Enqueue(1); // starting from state  1 % a = 1

            while (q.Count > 0)
            {
                var state = q.Dequeue();

                if (state == 0) // found
                {
                    var result = string.Empty;
                    var t = state;
                    do
                    {
                        result += (char)(values[t] + '0');
                        t = parents[t];
                    } while (t != 0);

                    return new string(result.Reverse().ToArray());
                }
                // ReSharper disable once RedundantIfElseBlock
                else // continue search
                {
                    // visit neighbor nodes
                    // ends 0
                    var first = state * 10 % n;

                    if (!was[first])
                    {
                        q.Enqueue(first);
                        was[first] = true;
                        values[first] = 0;
                        parents[first] = state;
                    }

                    // ends 1
                    var second = first + 1;

                    if (second >= n) second = second - n;

                    if (!was[second])
                    {
                        q.Enqueue(second);
                        was[second] = true;
                        values[second] = 1;
                        parents[second] = state;
                    }
                }
            }
            return "";
        }
    }
}
