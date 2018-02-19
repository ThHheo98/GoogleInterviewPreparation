using System;
using System.Collections.Generic;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class MyStackSortAscending<T> : Stack<T> where T : IComparable
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }


        /// <summary>
        ///     Biggest on the top O(N^2) + O(N) space
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        public static MyStackSortAscending<T> SortAscending(MyStackSortAscending<T> stack)
        {
            if (stack.IsEmpty() || stack.Count == 1) return stack;

            var result = new MyStackSortAscending<T>();
            while (!stack.IsEmpty())
            {
                T tmp = stack.Pop();
                while (!result.IsEmpty() && result.Peek().CompareTo(tmp) > 0)
                {
                    stack.Push(result.Pop());
                }
                result.Push(tmp);
            }
            return result;
        }
    }
}