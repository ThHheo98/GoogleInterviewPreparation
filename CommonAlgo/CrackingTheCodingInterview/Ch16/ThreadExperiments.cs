using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch16
{
    public class ThreadExperiments
    {
        [TestCase]
        public void Test()
        {
            var t = new Thread(Start);
            t.Start(5);
            Console.WriteLine("I am Test");
            Thread.Sleep(1000);
            t.Join();
            Console.WriteLine("Done");
        }

        private void Start(object o)
        {
            Console.WriteLine("I am thread n {0}, I am doing smth", o);
            Thread.Sleep(1000);
        }

        [TestCase]
        public void Test1()
        {
            ThreadPool.QueueUserWorkItem(Start1, 5);
            Console.WriteLine("I am Test");
            Thread.Sleep(8000);
            Console.WriteLine("Done");
        }

        private void Start1(object o)
        {
            Console.WriteLine("I am thread n {0}, I am doing smth", o);
            Thread.Sleep(5000);
            Console.WriteLine("I am thread n {0}, I done", o);
        }

        [TestCase]
        public void Test2()
        {
            CallContext.LogicalSetData("name", "Alex");
            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Name = {0}", CallContext.LogicalGetData("name")));
            ExecutionContext.SuppressFlow();
            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Name = {0}", CallContext.LogicalGetData("name")));
            ExecutionContext.RestoreFlow();
        }

        [TestCase]
        public void Test3()
        {
            var cts = new CancellationTokenSource();

            ThreadPool.QueueUserWorkItem(state => TestCTS(cts, 1000));

            Console.WriteLine("Press Enter to cancel operation");
            Console.ReadLine();
            cts.Cancel();

            Console.ReadLine();
        }

        private void TestCTS(CancellationTokenSource cts, int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                if (cts.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation requested");
                    return;
                }
                Console.WriteLine(i);
                Thread.Sleep(25000);
            }
        }
    }
}