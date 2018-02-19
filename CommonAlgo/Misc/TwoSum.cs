using System;
using NUnit.Framework;

namespace CommonAlgo.Misc
{
    public class Solution
    {
        [TestCase]
        public void Test()
        {
            var r = TwoSum(new[] {3, 2, 4}, 6);
            Console.WriteLine();
            Console.WriteLine(r[0]);
            Console.WriteLine(r[1]);
        }

        public int[] TwoSum(int[] nums, int target)
        {
            // sort 
            nums = mergesort(nums);
            for (var i = 0; i < nums.Length; i++)
                Console.Write(nums[i] + " ");
            //return null;
            // get sum
            return Sum2(nums, target);
        }

        public static int[] Sum2(int[] nums, int target)
        {
            int[] r = new int[2];
            var lo = 0;
            var hi = nums.Length - 1;
            while (lo < hi)
            {
                var s = nums[lo] + nums[hi];

                if (s == target)
                {
                    r = new [] {lo+1, hi+1};
                    break;
                }
                if (s > target)
                {
                    hi--;
                }
                else
                {
                    lo++;
                }
            }
            return r;
        }

        public static int[] mergesort(int[] a)
        {
            if (a == null) return null;
            if (a.Length == 0) return a;
            if (a.Length == 1) return a;
            var l = new int[a.Length/2];
            var r = new int[a.Length - l.Length];
            for (var i = 0; i < l.Length; i++)
                l[i] = a[i];
            for (var i = 0; i < r.Length; i++)
                r[i] = a[i + l.Length];
            l = mergesort(l);
            r = mergesort(r);
            return merge(l, r);
        }

        public static int[] merge(int[] l, int[] r)
        {
            var res = new int[l.Length + r.Length];
            var i = 0;
            var j = 0;
            var k = 0;
            while (i < l.Length && j < r.Length)
            {
                if (l[i] < r[j])
                {
                    res[k] = l[i];
                    i++;
                }
                else
                {
                    res[k] = r[j];
                    j++;
                }
                k++;
            }
            while (i < l.Length)
            {
                res[k] = l[i];
                k++;
                i++;
            }
            while (j < r.Length)
            {
                res[k] = r[j];
                j++;
                k++;
            }
            return res;
        }
    }
}