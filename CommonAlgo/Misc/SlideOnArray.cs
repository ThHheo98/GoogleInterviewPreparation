using System;
using NUnit.Framework;

namespace CommonAlgo.Misc
{
    public class SlideOnArray
    {
        [Test]
        public void Approach1()
        {
            var a = new[] {1, 2, 3, 4, 5, 6};
            for (var i = 0; i < a.Length - 1; i++)
            {
                Console.WriteLine(a[i] + " " + a[i + 1]);
            }
        }

        [Test]
        public void Approach2()
        {
            var a = new[] {1, 2, 3, 4, 5, 6};
            for (var i = 1; i < a.Length; i++)
            {
                Console.WriteLine(a[i - 1] + " " + a[i]);
            }
        }
    }
}