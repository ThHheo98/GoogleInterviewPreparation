using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch16
{
    public class Chopstick
    {
        private readonly object _obj = new object();

        public bool PickUp()
        {
            return Monitor.TryEnter(_obj);
        }

        public void PutDown()
        {
            Monitor.Exit(_obj);
        }
    }

    public class Philosopher
    {
        private readonly Chopstick _left;
        private readonly string _name;
        private readonly Chopstick _right;

        public Philosopher(Chopstick left, Chopstick right, string name)
        {
            _left = left;
            _right = right;
            _name = name;
        }

        private void Chew()
        {
            //Thread.Sleep(new Random((int)DateTime.Now.Ticks).Next() % 1000);
            Console.WriteLine("Philosopher {0} Eat", _name);
        }

        private void EatBite()
        {
            if (PickUp())
            {
                Chew();
                PutDown();
                Thread.Sleep(1);
            }
        }

        private bool PickUp()
        {
            if (!_left.PickUp()) return false;
            if (!_right.PickUp())
            {
                _left.PutDown();
                return false;
            }
            return true;
        }

        private void PutDown()
        {
            _left.PutDown();
            _right.PutDown();
        }

        public void Eat()
        {
            while (true)
            {
                EatBite();
            }
        }
    }

    /// <summary>
    ///     Dinner philosophers
    /// </summary>
    public class Test163
    {
        [TestCase]
        public void Test()
        {
            const int philoCount = 5;
            var chops = new Chopstick[philoCount];
            for (int i = 0; i < philoCount; i++)
            {
                chops[i] = new Chopstick();
            }

            var tasks = new Task[philoCount];

            tasks[0] = new Task(() => new Philosopher(chops[0], chops[philoCount - 1], "philo1").Eat());

            for (int i = 1; i < philoCount; ++i)
            {
                int ix = i;
                tasks[ix] = new Task(() => new Philosopher(chops[ix - 1], chops[ix], "philo" + (ix + 1)).Eat());
            }
            Parallel.ForEach(tasks, t => t.Start());
            Task.WaitAll(tasks);
        }
    }
}