using System;
using System.IO.Pipes;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadTest
{
    internal sealed class Type1
    {
    }

    internal sealed class Type2
    {
    }


    internal class Program
    {
        private static void Main()
        {
            // Test3();

            //            Test4();
            MyMethodAsync(1);

            new SpinLock();
        }


        private static async Task<Type1> Method1Async()
        {
            /* Асинхронная операция, возвращающая объект Type1 */
            return new Type1();
        }

        private static Task<Type2> Method2Async()
        {
            //            return Task.Run(() => new Type2());
            //            return Task.FromResult(new Type2());
            /* Асинхронная операция, возвращающая объект Type2 */

            var source = new TaskCompletionSource<Type2>();
            source.SetResult(new Type2());
            return source.Task;
            //            return new Type2();
        }

        private static void Test()
        {
            var method2Async = Method2Async();
            if (method2Async.IsCompleted)
            {
                var result = method2Async.Result;
                return;
            }

            method2Async.ContinueWith(task =>
            {
                var result = task.Result;
            });

            //            var method2Async = Method2Async();
            //            var method2Async1 = await Method2Async();

            //            var type2 = await Method2Async();


            //            method2Async1.ToString();
            //            method2Async.ToString();
        }

        private static async Task<String> MyMethodAsync(Int32 argument)
        {
            Int32 local = argument;
            try
            {
                Type1 result1 = await Method1Async();
                for (Int32 x = 0; x < 3; x++)
                {
                    Type2 result2 = await Method2Async();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Catch");
            }
            finally
            {
                Console.WriteLine("Finally");
            }
            return "Done";
        }

        private static void Test4()
        {
            var cts = new CancellationTokenSource();
            var t = new Task<int>(() => Sum(cts.Token, 10000), cts.Token);
            t.Start();
            cts.Cancel();
            try
            {
                Console.WriteLine("The result = {0}", t.Result);
            }
            catch (AggregateException e)
            {
                e.Handle(x => x is OperationCanceledException);
                Console.WriteLine("sum was canceled");
            }
        }

        private static int Sum(CancellationToken token, int i)
        {
            int s = 0;
            for (; i > 0; i--)
            {
                token.ThrowIfCancellationRequested();
                checked
                {
                    s += i;
                }
            }
            return s;
        }

        public static void Test3()
        {
            var cts = new CancellationTokenSource();
            //cts.Token.Register(() => Console.WriteLine("Hello!"));
            cts.Token.Register(() => Console.WriteLine("Hello!"), true);

            //ThreadPool.QueueUserWorkItem(state => TestCTS(CancellationToken.None, 1000));
            ThreadPool.QueueUserWorkItem(state => TestCTS(cts.Token, 1000));

            Console.WriteLine("Press Enter to cancel operation");
            Console.ReadLine();
            //            cts.Cancel();
            cts.Cancel(true);

            Console.ReadLine();
        }

        private static void TestCTS(CancellationToken cts, int cnt)
        {
            for (int i = 0; i < cnt; i++)
            {
                if (cts.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation requested");

                    return;
                }
                Console.WriteLine(i);
                Thread.Sleep(250);
            }
        }

        private static async void StartServer()
        {
            while (true)
            {
                var pipe = new NamedPipeServerStream("test", PipeDirection.InOut, 1,
                    PipeTransmissionMode.Message, PipeOptions.Asynchronous | PipeOptions.WriteThrough);
                await Task.Factory.FromAsync(pipe.BeginWaitForConnection, pipe.EndWaitForConnection, null);
            }
        }
    }
}