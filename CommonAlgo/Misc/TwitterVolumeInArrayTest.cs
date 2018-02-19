using System;
using NUnit.Framework;

namespace CommonAlgo.Misc
{
    /// <summary>
    ///     Twitter task O(n)
    ///     http://habrahabr.ru/post/200190/
    /// </summary>
    public class TwitterVolumeInArrayTest
    {
        [TestCase]
        public void Test()
        {
            var a = new[] { 2, 5, 1, 2, 3, 4, 7, 7, 6 };
            var volume = GetVolume(a);
            Assert.AreEqual(10, volume);
            Console.WriteLine("Volume {0}", volume);
        }

        [Test]
        public void Test1()
        {
            var a = new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var volume = GetVolume(a);
            Assert.AreEqual(6, volume);
            Console.WriteLine("Volume {0}", volume);
        }

        [Test]
        public void Test2()
        {
            var a = new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var volume = GetVolume1(a);
            Assert.AreEqual(6, volume);
            Console.WriteLine("Volume {0}", volume);
        }

        private int GetVolume1(int[] a)
        {
            var left = 0;
            var right = a.Length - 1;
            var leftMax = 0;
            var rightMax = 0;
            var vol = 0;
            while (left <= right)
            {
                if (a[left] <= a[right])
                {
                    if (a[left] >= leftMax)
                    {
                        leftMax = a[left];
                    }
                    else
                    {
                        vol += leftMax - a[left];
                    }
                    left++;
                }
                else
                {
                    if (a[right] >= rightMax)
                    {
                        rightMax = a[right];
                    }
                    else
                    {
                        vol += rightMax - a[right];
                    }
                    right--;
                }
            }
            return vol;
        }

        private int GetVolume(int[] a)
        {
            var left = 0;
            var right = a.Length - 1;
            var leftMax = 0;
            var rightMax = 0;
            var vol = 0;
            while (left < right)
            {
                if (a[left] > leftMax)
                {
                    leftMax = a[left];
                }
                if (a[right] > rightMax)
                {
                    rightMax = a[right];
                }

                if (leftMax >= rightMax)
                {
                    vol += rightMax - a[right];
                    right--;
                }
                else
                {
                    vol += leftMax - a[left];
                    left++;
                }
            }
            return vol;
        }
    }
}
