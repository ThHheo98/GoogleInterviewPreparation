using System;
using System.Threading;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch16
{
    public class FooEvent
    {
    }

    public class FooSemaphoreSlim
    {
        private readonly SemaphoreSlim _semaphore1;
        private readonly SemaphoreSlim _semaphore2;

        public FooSemaphoreSlim()
        {
            try
            {
                _semaphore1 = new SemaphoreSlim(1, 1);
                _semaphore2 = new SemaphoreSlim(1, 1);

                _semaphore1.Wait();
                _semaphore2.Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Method1()
        {
            try
            {
                Console.WriteLine("Method1 was invoked");
            }
            finally
            {
                _semaphore1.Release();
            }
        }

        public void Method2()
        {
            try
            {
                _semaphore1.Wait();
                _semaphore1.Release();
                Console.WriteLine("Method2 was invoked");
            }

            finally
            {
                _semaphore2.Release();
            }
        }

        public void Method3()
        {
            _semaphore2.Wait();
            _semaphore2.Release();
            Console.WriteLine("Method3 was invoked");
        }
    }

    public class Test165
    {
        [TestCase]
        public void Test()
        {
            var foo = new FooSemaphoreSlim();
            var t1 = new Thread(foo.Method1);
            var t2 = new Thread(foo.Method2);
            var t3 = new Thread(foo.Method3);

            t3.Start();
            t2.Start();
            t1.Start();
        }
    }
}