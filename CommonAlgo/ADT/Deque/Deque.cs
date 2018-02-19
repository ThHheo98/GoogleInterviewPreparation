using System;
using NUnit.Framework;

namespace CommonAlgo.ADT.Deque
{
    public class DequeueTest
    {
        [TestCase]
        public void Test()
        {
            var deque = new Deque<int>();
            deque.AddToBack(0);

            deque.AddToFront(10);
            deque.AddToFront(20);
            deque.AddToFront(30);

            deque.RemoveFromFront();

            Console.WriteLine(deque.ToString());

            deque.AddToBack(40);
            deque.AddToBack(50);

            Console.WriteLine(deque.ToString());

            deque.RemoveFromBack();

            Console.WriteLine(deque.ToString());
        }
    }

    internal class Deque<T>
    {
        private int _count;
        private QNode _head;
        private QNode _tail;

        public int Count

        {
            get { return _count; }
        }

        public void AddToFront(T data)
        {
            var newNode = new QNode(data);

            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _head.Prev = newNode;
                newNode.Next = _head;
                _head = newNode;
            }
            _count++;
        }

        public T RemoveFromFront()
        {
            if (_head == null)
            {
                return default(T);
            }

            if (_count == 1)
            {
                var tempHead1 = _head;
                _head = null;
                _tail = null;
                _count--;
                return tempHead1.Data;
            }

            var tempHead = _head;
            _head = _head.Next;
            _head.Prev = null;

            if (_head == null)
            {
                _tail = null;
            }
            _count--;
            return tempHead.Data;
        }

        public void AddToBack(T data)
        {
            var newNode = new QNode(data);
            if (_head == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Prev = _tail;
                _tail.Next = newNode;
                _tail = newNode;
            }
            _count++;
        }

        public T RemoveFromBack()
        {
            var tempTail = _tail;
            if (tempTail == null)
            {
                return default(T);
            }

            _tail = _tail.Prev;
            if (null == _tail)
            {
                _head = null;
            }
            else
            {
                _tail.Next = null;
            }
            _count--;
            return tempTail.Data;
        }

        public T GetAtFront()
        {
            return _head.Data;
        }

        public T GetAtBack()
        {
            return _tail.Data;
        }

        private class QNode
        {
            public QNode(T data)
            {
                Data = data;
                Next = null;
                Prev = null;
            }

            public T Data { get; private set; }
            public QNode Next { get; set; }
            public QNode Prev { get; set; }
        }
    }
}
