using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    [TestFixture]
    public class Tests2
    {
        /// <summary>
        ///     // Describe how you could use a single array to implement three stack
        /// </summary>
        /// <param name="stackCount"></param>
        /// <param name="stackCapacity"></param>
        [TestCase(3, 10)]
        public void Test31(int stackCount, int stackCapacity)
        {
            // two solution: fixed array size with stack 1 lying in [0, N/3) and so one
            // first solution

            var stack = new _3StackInArray<int>(stackCount, stackCapacity);

            for (int i = 1; i <= stack.CountOfStacks; i++)
            {
                for (int j = 0; j < stackCapacity; j++)
                {
                    stack.Push(j, i);
                }
            }

            for (int i = 1; i <= stack.CountOfStacks; i++)
            {
                Assert.AreEqual(stackCapacity - 1, stack.Peek(i));
            }

            for (int i = 1; i <= stack.CountOfStacks; i++)
            {
                int i1 = i;
                Assert.That(() => stack.Push(10, i1), Throws.Exception.TypeOf<FullStackException>());
            }

            for (int i = 1; i <= stack.CountOfStacks; i++)
            {
                for (int j = 0; j < stackCapacity; j++)
                {
                    stack.Pop(i);
                }
            }

            for (int i = 1; i <= stack.CountOfStacks; i++)
            {
                int i1 = i;
                Assert.That(() => stack.Pop(i1), Throws.Exception.TypeOf<StackIsEmptyException>());
            }
        }

        /// <summary>
        ///     Stack with Min, pop, push by O(1)
        /// </summary>
        [TestCase]
        public void Test32()
        {
            var st = new StackWithMin<int>();

            for (int i = 10; i >= 0; i--)
            {
                st.Push(i);
            }

            Assert.IsTrue(st.Min() == 0);
        }


        /// <summary>
        ///     Set of stacks
        /// </summary>
        [TestCase(3, 1)]
        public void Test33(int countOfStack, int stackMaxCapacity)
        {
            var st = new SetOfStack<int>(stackMaxCapacity);

            for (int i = 1; i <= countOfStack*stackMaxCapacity; i++)
            {
                st.Push(i);
            }
            Assert.AreEqual(countOfStack*stackMaxCapacity, st.Count);

            for (int i = countOfStack*stackMaxCapacity; i > 0; i--)
            {
                int pop = st.Pop();
                Assert.AreEqual(i, pop);
            }
        }

        /// <summary>
        ///     Tower of Hanoi
        /// </summary>
        [TestCase(3)]
        public void Test34(int countOfDisks)
        {
            const int towerCount = 3;
            var towers = new Tower[3];
            for (int i = 0; i < towerCount; i++)
            {
                towers[i] = new Tower(i);
            }
            for (int i = countOfDisks - 1; i >= 0; i--)
            {
                towers[0].Add(i);
            }
            towers[0].MoveDisks(countOfDisks, towers[1], towers[2]);
        }

        /// <summary>
        ///     Tower of Hanoi Static
        /// </summary>
        [TestCase(3)]
        public void Test34Static(int countOfDisks)
        {
            const int towerCount = 3;
            var towers = new Tower[3];
            for (int i = 0; i < towerCount; i++)
            {
                towers[i] = new Tower(i);
            }
            for (int i = countOfDisks - 1; i >= 0; i--)
            {
                towers[0].Add(i);
            }
            Console.WriteLine(towers[0].ToString());

            Tower.Hanoi(countOfDisks, towers[0], towers[1], towers[2]);
        }

        /// <summary>
        ///     Implement Queue by 2 stack
        /// </summary>
        [TestCase]
        public void Test35()
        {
            var myQueueDequeueCostly = new MyQueueDequeueCostly<int>();

            for (int i = 10; i >= 0; i--)
            {
                myQueueDequeueCostly.Enqueue(i);
            }

            for (int i = 10; i >= 0; i--)
            {
                int dequeue = myQueueDequeueCostly.Dequeue();
                Assert.AreEqual(i, dequeue);
            }

            var myQueueEnqueueCostly = new MyQueueEnqueueCostly<int>();

            for (int i = 10; i >= 0; i--)
            {
                myQueueEnqueueCostly.Enqueue(i);
            }

            for (int i = 10; i >= 0; i--)
            {
                int dequeue = myQueueEnqueueCostly.Dequeue();
                Assert.AreEqual(i, dequeue);
            }
        }

        /// <summary>
        ///     Implement stack by 2 queue
        /// </summary>
        [TestCase]
        public void Test35A()
        {
            var popCostly = new MyStackPopCostly<int>();

            for (int i = 0; i <= 10; i++)
            {
                popCostly.Push(i);
            }

            for (int i = 10; i >= 0; i--)
            {
                int pop = popCostly.Pop();
                Assert.AreEqual(i, pop);
            }

            var pushCostly = new MyStackPushCostly<int>();

            for (int i = 0; i <= 10; i++)
            {
                pushCostly.Push(i);
            }

            for (int i = 10; i >= 0; i--)
            {
                int pop = pushCostly.Pop();
                Assert.AreEqual(i, pop);
            }
        }

        /// <summary>
        ///     Sort stack ascending
        /// </summary>
        [TestCase]
        public void Test36()
        {
            var sortAscending = new MyStackSortAscending<int>();
            for (int i = 0; i < 11; i++)
            {
                sortAscending.Push(i);
            }
            MyStackSortAscending<int> ints = MyStackSortAscending<int>.SortAscending(sortAscending);
            for (int i = 10; i >= 0; i--)
            {
                Assert.AreEqual(i, ints.Pop());
            }
        }

        /// <summary>
        ///     Sort stack ascending
        /// </summary>
        [TestCase]
        public void Test37()
        {
            var q = new AnimalQueue();

            q.Enqueue(new Cat("cat1"));
            q.Enqueue(new Cat("cat2"));
            q.Enqueue(new Cat("cat3"));
            q.Enqueue(new Cat("cat4"));

            q.Enqueue(new Dog("dog1"));
            q.Enqueue(new Dog("dog2"));
            q.Enqueue(new Dog("dog3"));
            q.Enqueue(new Dog("dog4"));

            Animal any = q.DequeueAny();
            Assert.IsNotNull(any);
            Assert.AreEqual(7, q.Count);

            Animal dequeueCats = q.DequeueCats();
            Assert.IsNotNull(dequeueCats);

            Animal dequeueDogs = q.DequeueDogs();
            Assert.IsNotNull(dequeueDogs);

            Assert.AreEqual(5, q.Count);
        }
    }
}