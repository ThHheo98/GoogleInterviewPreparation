using System;
using CommonAlgo.ADT.LinkedList;
using CommonAlgo.ADT.Queue;
using CommonAlgo.ADT.Stacks;
using NUnit.Framework;

namespace CommonAlgo.ADT
{
    [TestFixture]
    public class Tests
    {
        [TestCase]
        public void PQTEST()
        {
            var stack = new PriorityQueue<int>();

            stack.Enqueue(1);
            stack.Enqueue(2);
            stack.Enqueue(-1);


            int dequeue = stack.Dequeue();
            Console.WriteLine("Min element = " +
                              dequeue);

            string s = stack.ToString();
            Console.WriteLine(s);
        }

        [TestCase]
        public void ResizingArrayStackTest()
        {
            var stack = new ResizingArrayStack<int>();

            stack.Push(1);
            stack.Push(2);

            Assert.IsTrue(stack.ItemCount == 2);
            Assert.IsTrue(stack.IsEmpty() == false);
            Assert.IsTrue(stack.Peek() == 2);
            Assert.IsTrue(stack.Pop() == 2);
            Assert.IsTrue(stack.ItemCount == 1);
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());

            for (int i = 0; i < 1000; i++)
            {
                stack.Push(i);
            }

            Assert.IsTrue(stack.ItemCount == 1000);

            for (int i = 0; i < 1000; i++)
            {
                stack.Pop();
            }

            Assert.IsTrue(stack.ItemCount == 0);
        }

        [TestCase]
        public void LinkedListStackTest()
        {
            var stack = new LinkedListStack<int>();

            stack.Push(1);
            stack.Push(2);

            Assert.IsTrue(stack.ItemCount == 2);
            Assert.IsTrue(stack.IsEmpty() == false);
            Assert.IsTrue(stack.Peek() == 2);
            Assert.IsTrue(stack.Pop() == 2);
            Assert.IsTrue(stack.ItemCount == 1);
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());

            for (int i = 0; i < 1000; i++)
            {
                stack.Push(i);
            }

            Assert.IsTrue(stack.ItemCount == 1000);

            for (int i = 0; i < 1000; i++)
            {
                stack.Pop();
            }

            Assert.IsTrue(stack.ItemCount == 0);
        }

        public class IntWrapper : IComparable<IntWrapper>, IComparable
        {
            private readonly int _value;

            public IntWrapper(int value)
            {
                _value = value;
            }

            public int Value
            {
                get { return _value; }
            }

            int IComparable.CompareTo(object obj)
            {
                return CompareTo(obj as IntWrapper);
            }

            public int CompareTo(IntWrapper other)
            {
                if (other == null) return -1;
                if (other == this) return 0;
                return other._value.CompareTo(_value);
            }

            protected bool Equals(IntWrapper other)
            {
                return _value == other._value;
            }

            public override int GetHashCode()
            {
                return _value.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                var intWrapper = obj as IntWrapper;
                if (intWrapper == null) return false;
                return intWrapper._value.Equals(_value);
            }

            public override string ToString()
            {
                return string.Format("Item wrapper has a Value: {0}", Value);
            }
        }

        [TestCase]
        public void LinkedListTest()
        {
            var list = new SinglyLinkedList<IntWrapper>();

            var intWrapper = new IntWrapper(1);
            list.AddToFront(intWrapper);
            var wrapper = new IntWrapper(2);
            list.AddToFront(wrapper);

            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list.IsEmpty() == false);


            IntWrapper find = list.Find(intWrapper);
            Assert.IsTrue(find.Equals(intWrapper));

            list.Remove(new IntWrapper(2));
            Assert.IsTrue(list.Count == 1);
            Assert.IsTrue(list.IsEmpty() == false);


            list.AddToFront(new IntWrapper(1));


            Assert.IsTrue(list.Count == 2);
            list.Remove(new IntWrapper(1));
            Assert.IsTrue(list.Count == 0);
        }

        [TestCase]
        public void FindMToLastTest()
        {
            var list = new MthSingleLinkedList<IntWrapper>();
            for (int i = 0; i < 10; i++)
            {
                list.AddToFront(new IntWrapper(i));
            }

            list.Print();

            IntWrapper t = list.FindMToLast(10);
            Assert.AreEqual(9, t.Value);
            t = list.FindMToLast(7);
            Assert.AreEqual(6, t.Value);
            t = list.FindMToLast(5);
            Assert.AreEqual(4, t.Value);
        }

        [TestCase]
        public void DetermineCycle()
        {
            // Write a function that takes a pointer to the head of a list and determines whether the
            // list is cyclic or acyclic. Your function should return false if the list is acyclic and true
            // if it is cyclic. You may not modify the list in any way.
            var list = new SingleLinkedListCycle<int>();
            list.FindCycle();
        }

        [TestCase]
        public void FlatTheList()
        {
//            Given a linked list where every node represents a linked list and contains two pointers of its type:
//(i) Pointer to next node in the main list (we call it ‘right’ pointer in below code)
//(ii) Pointer to a linked list where this node is head (we call it ‘down’ pointer in below code).
//All linked lists are sorted. See the following example
//
//       5 -> 10 -> 19 -> 28
//       |    |     |     |
//       V    V     V     V
//       7    20    22    35
//       |          |     |
//       V          V     V
//       8          50    40
//       |                |
//       V                V
//       30               45
//Write a function flatten() to flatten the lists into a single linked list. The flattened linked list should also be sorted. For example, for the above input list, output list should be 5->7->8->10->19->20->22->28->30->35->40->45->50.
            // http://www.geeksforgeeks.org/flattening-a-linked-list/
            var list = new DoublyLinkedList<int>();
            list.Add(1);
            list.Remove(1);
            list.Add(2);
            list.Add(3);
            list.Remove(2);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Remove(6);

            Assert.AreEqual(3, list.Count);

            list.Clear();

            Assert.AreEqual(0, list.Count);

            DoublyLinkedList<int> flattenList = list.CreateFlattenList();
            flattenList.Flat();
            flattenList.Print();
            Assert.IsTrue(flattenList.Count == 4);

            flattenList.Unflat();
        }


        [Test]
        public void QueueTest()
        {
            var q = new LinkedListQueue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            Assert.IsTrue(q.Count == 2);
            int i = q.Dequeue();
            Assert.IsTrue(i == 1);
            Assert.IsTrue(q.Count == 1);
            i = q.Dequeue();
            Assert.IsTrue(i == 2);
            Assert.IsTrue(q.Count == 0);
        }

        [Test]
        public void ResizedArrayQueueTest()
        {
            var q = new ResizingArrayQueue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            Assert.IsTrue(q.Count == 2);
            int i = q.Dequeue();
            Assert.IsTrue(i == 1);
            Assert.IsTrue(q.Count == 1);
            i = q.Dequeue();
            Assert.IsTrue(i == 2);
            Assert.IsTrue(q.Count == 0);
        }

        [Test]
        public void TwoStackQueueTest()
        {
            var q = new TwoStackQueue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            Assert.IsTrue(q.Count == 2);
            int i = q.Dequeue();
            Assert.IsTrue(i == 1);
            Assert.IsTrue(q.Count == 1);
            i = q.Dequeue();
            Assert.IsTrue(i == 2);
            Assert.IsTrue(q.Count == 0);
        }
    }
}