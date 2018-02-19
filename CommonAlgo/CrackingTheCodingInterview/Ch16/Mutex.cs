using System;
using System.Threading;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch16
{
    namespace ConsoleApplication1
    {
        // В этом классе содержится общий ресурс в виде переменной Count,
        // а так же мьютекс mtx
        internal class SharedRes
        {
            public static int Count;
            public static readonly Mutex mtx = new Mutex();
        }

        // В этом классе Count инкременируется
        internal class IncThread
        {
            public readonly Thread Thrd;
            private int num;

            public IncThread(string name, int n)
            {
                Thrd = new Thread(Run);
                num = n;
                Thrd.Name = name;
                Thrd.Start();
            }

            // Точка входа в поток
            private void Run()
            {
                Console.WriteLine(Thrd.Name + " ожидает мьютекс");

                // Получить мьютекс
                SharedRes.mtx.WaitOne();

                Console.WriteLine(Thrd.Name + " получает мьютекс");

                do
                {
                    Thread.Sleep(500);
                    SharedRes.Count++;
                    Console.WriteLine("в потоке {0}, Count={1}", Thrd.Name, SharedRes.Count);
                    num--;
                } while (num > 0);

                Console.WriteLine(Thrd.Name + " освобождает мьютекс");

                SharedRes.mtx.ReleaseMutex();
            }
        }

        internal class DecThread
        {
            public readonly Thread Thrd;
            private int num;

            public DecThread(string name, int n)
            {
                Thrd = new Thread(Run);
                num = n;
                Thrd.Name = name;
                Thrd.Start();
            }

            // Точка входа в поток
            private void Run()
            {
                Console.WriteLine(Thrd.Name + " ожидает мьютекс");

                // Получить мьютекс
                SharedRes.mtx.WaitOne();

                Console.WriteLine(Thrd.Name + " получает мьютекс");

                do
                {
                    Thread.Sleep(500);
                    SharedRes.Count--;
                    Console.WriteLine("в потоке {0}, Count={1}", Thrd.Name, SharedRes.Count);
                    num--;
                } while (num > 0);

                Console.WriteLine(Thrd.Name + " освобождает мьютекс");

                SharedRes.mtx.ReleaseMutex();
            }
        }

        public class MutexTest
        {
            [TestCase]
            public void Main()
            {
                var mt1 = new IncThread("Inc thread", 5);

                // разрешить инкременирующему потоку начаться
                Thread.Sleep(1);

                var mt2 = new DecThread("Dec thread", 5);

                mt1.Thrd.Join();
                mt2.Thrd.Join();

                Console.ReadLine();
            }
        }
    }
}