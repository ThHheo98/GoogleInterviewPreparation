using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.InterviewBit.TreeMapsAndHeaps
{
    /// <summary>
    ///     https://www.interviewbit.com/problems/least-recently-used-cache/
    ///     http://www.tedunangst.com/flak/post/2Q-buffer-cache-algorithm
    ///     http://www.programcreek.com/2013/03/leetcode-lru-cache-java/
    ///     http://www.vldb.org/conf/1994/P439.PDF
    /// </summary>
    public class LRUCache
    {
        private readonly int _capacity;

        private readonly Dictionary<int, Node> _hash = new Dictionary<int, Node>();

        private Node head;
        private Node tail;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            head = null;
            tail = null;
        }

        private void Remove(Node node)
        {
            if (node.pre == null) // ie node is head;
                head = node.next;
            else
                node.pre.next = node.next;

            if (node.next == null) // ie node is end
                tail = node.pre;
            else
                node.next.pre = node.pre;
        }

        private void SetHead(Node node)
        {
            node.next = head;
            node.pre = null;

            if (head != null)
                head.pre = node;

            head = node;

            if (tail == null)
                tail = head;
        }

        public int get(int key)
        {
            if (_hash.ContainsKey(key))
            {
                var r = _hash[key];
                // remote from end of linked list
                Remove(r);
                // add to head of linked list
                SetHead(r);

                return r.val;
            }
            return -1;
        }

        public void set(int key, int value)
        {
            // 2 choices
            // key is present in cache
            if (_hash.ContainsKey(key))
            {
                var r = _hash[key];
                r.val = value;
                Remove(r);
                SetHead(r);
            }
            else
            {
                var created = new Node(key, value);

                if (_hash.Count >= _capacity)
                {
                    _hash.Remove(tail.key);
                    Remove(tail);
                    SetHead(created);
                }
                else
                {
                    SetHead(created);
                }

                _hash.Add(key, created);
            }
        }

        public class Tests
        {
            [Test]
            public void Test()
            {
                var lru = new LRUCache(1);

                lru.set(2, 1);
                var val = lru.get(2);
                Assert.AreEqual(1, val);
                lru.set(3, 4);
                var val1 = lru.get(2);
                Assert.AreEqual(-1, val1);
                var val2 = lru.get(3);
                Assert.AreEqual(4, val2);
            }
        }

        private class Node
        {
            public readonly int key;
            public Node next;
            public Node pre;
            public int val;

            public Node(int key, int val)
            {
                this.key = key;
                this.val = val;
                pre = null;
                next = null;
            }
        }
    }
}
