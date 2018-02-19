using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.StackQueues
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/evaluate-expression/
    ///     https://discuss.leetcode.com/topic/1941/java-accepted-code-stack-implementation
    /// </summary>
    public class EvaluateExpression
    {
        [Test]
        public void Test()
        {
            var rpn = EvalRpn(new List<string> { "2", "1", "+", "3", "*" });
            Assert.AreEqual(9, rpn);
        }

        public int EvalRpn(List<string> st)
        {
            var s = new Stack<int>();

            var a = 0;
            var b = 0;

            for (var i = 0;
                i < st.Count;
                ++i)
            {
                switch (st[i])
                {
                    case "/":
                        b = s.Pop();
                        a = s.Pop();
                        s.Push(a / b);
                        break;
                    case "*":
                        a = s.Pop();
                        b = s.Pop();
                        s.Push(a * b);
                        break;
                    case "+":
                        a = s.Pop();
                        b = s.Pop();
                        s.Push(a + b);
                        break;
                    case "-":
                        b = s.Pop();
                        a = s.Pop();
                        s.Push(a - b);
                        break;
                    default:
                        s.Push(int.Parse(st[i]));
                        break;
                }
            }

            return s.Pop();
        }
    }
}
