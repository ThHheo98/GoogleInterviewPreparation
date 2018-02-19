using System.Collections.Generic;

namespace CommonAlgo.InterviewBit.StackQueues
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/redundant-braces/
    ///     http://qa.geeksforgeeks.org/3857/program-to-check-redundant-braces
    ///     http://qa.geeksforgeeks.org/2548/how-to-check-an-expression-contains-redundant-braces-or-not
    /// </summary>
    public class RedundantBraces
    {
        /*
         If we somehow pick out sub-expressions surrounded by ( and ), then if we are left with () as a part of the string, we know we have redundant braces.

Lets take an example:

(a+(a+b))

We keep pushing elements onto the stack till we encounter ')'. 
When we do encounter ')', we start popping elements till we 
find a matching '('. If the number of elements popped do not 
correspond to '()', we are fine and we can move forward. 
Otherwise, voila! Matching braces have been found. 

Note Cases Like :(a*(a)) and (a) etc.
             
             */

        private string braces1(string A)
        {
            var st = new Stack<char>();
            int ct;
            for (var i = 0;
                i < A.Length;
                i++)
            {
                if (A[i] != ')')
                {
                    st.Push(A[i]);
                }
                else
                {
                    ct = 0;
                    while (st.Count > 0 && st.Peek() != '(')
                    {
                        st.Pop();
                        ct++;
                    }
                    st.Pop();
                    if (ct == 0 || ct == 1)
                        return "YES";
                }
            }
            return "NO";
        }

        public int braces(string str)
        {
            var length = str.Length;
            var stack = new Stack<char>();

            for (var i = 0;
                i < length;
                ++i)
            {
                if (str[i] == ')')
                {
                    var cnt = 0;

                    while (stack.Peek() != '(')
                    {
                        stack.Pop();
                        cnt++;
                    }

                    stack.Pop();
                    if (cnt < 2)
                        return 1;
                }

                else
                {
                    stack.Push(str[i]);
                }
            }

            return 0;
        }
    }
}
