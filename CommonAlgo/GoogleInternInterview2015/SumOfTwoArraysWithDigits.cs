using System;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.GoogleInternInterview2015
{
    //http://www.careercup.com/question?id=5631950045839360
    public class SumOfTwoArraysWithDigits
    {
        public static int[] Sum(int[] a, int[] b)
        {
            // check arrays length
            // choose largest one

            var alen = a.Length;
            var blen = b.Length;
            if (blen > alen) return Sum(b, a);

            // save carry
            var carry = 0;


            // create out array legth = largest + 1
            var res = new int[alen + 1];

            // iterate over largest array
            for (var i = alen - 1; i >= 0; i--)
            {
                // sum carry + element from first array +  element from second array
                // (with check of boundary conditions with second array (shortest))
                var tmp = carry;
                if (blen + i - alen >= 0) tmp = tmp + b[blen + i - alen];
                tmp = tmp + a[i];

                // write sum % 10 to res 
                res[i + 1] = tmp%10;
                // update carry
                carry = tmp/10;
            }

            // after cycle write carry to first element
            res[0] = carry;
            return res;
        }


        [TestCase]
        public void Test()
        {
            int[] a = {9, 9, 9};
            int[] b = {9, 9, 9, 9, 9};

            var sum1 = Sum(a, b);
            var aggregate = sum1.Select(i => i.ToString()).Aggregate((s, e) => s.ToString() + e.ToString());
            Assert.IsTrue(aggregate == "100998");
            Console.WriteLine(aggregate);
        }
    }
}