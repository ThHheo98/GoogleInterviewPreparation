using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.BinarySearch
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/allocate-books/
    ///     http://qa.geeksforgeeks.org/3766/allocate-the-minimum-number-of-pages-to-each-student-google
    /// </summary>
    /*
     Think can we find how many number of students we need if we fix that one student can read at most V number of pages ? So, our problem statement reduces to : Given fixed number of pages (V),  how many number of students we need?
Check below pseudocode for better understanding.

?
Solution :
   simple simulation approach
   intially Sum := 0
   cnt_of_student = 0
   iterate over all books:
        If Sum + number_of_pages_in_current_book > V :
                  increment cnt_of_student
                  update Sum
        Else:
                  update Sum
   EndLoop;
   
 
 
    fix range LOW, HIGH
    Loop until LOW < HIGH:
            find MID_point
            Is number of students required to keep max number of pages below MID < M ? 
            IF Yes:
                update HIGH
            Else
                update LOW
    EndLoop;
         */
    public class AllocateBooks
    {
        [Test]
        public void Test()
        {
            var readOnlyList = new List<int> { 12, 34, 67, 90 };
            var ans = Solve(readOnlyList, readOnlyList.Count, 2);
            Assert.AreEqual(113, ans);
        }

        private bool IsPossible(IReadOnlyList<int> arr, int n, int m, long curMin)
        {
            var studentsRequired = 1;
            var curSum = 0;

            for (var i = 0;
                i < n;
                i++)
            {
                if (arr[i] > curMin)
                    return false;

                if (curSum + arr[i] > curMin)
                {
                    studentsRequired++;
                    curSum = arr[i];
                    if (studentsRequired > m)
                        return false;
                }
                else
                {
                    curSum += arr[i];
                }
            }
            return true;
        }

        private int Solve(IReadOnlyList<int> arr, int n, int m)
        {
            if (n < m)
                return -1;

            long sum = 0;
            for (var i = 0;
                i < n;
                ++i)
                sum += arr[i];

            long start = 0;
            long end = sum, mid;
            var ans = int.MaxValue;

            while (start <= end)
            {
                mid = (start + end) / 2;

                if (IsPossible(arr, n, m, mid))
                {
                    ans = Math.Min(ans, (int)mid);
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return ans;
        }
    }
}
