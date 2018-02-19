using System;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class OwnBigInteger
    {
        private Node _head;
        private int _length;
        private bool _useDelim;

        public OwnBigInteger()
        {
            _head = null;
            _length = 0;
        }

        public void Add(int value, bool toBegin)
        {
            _head = toBegin ? AddToBegin(_head, value) : AddToEnd(_head, value);
            _length++;
        }

        private Node AddToEnd(Node head, int value)
        {
            var node = new Node {item = value};
            if (head == null)
            {
                head = node;
                return head;
            }
            Node t = head;
            while (t.next != null)
            {
                t = t.next;
            }

            t.next = node;
            return head;
        }

        private Node AddToBegin(Node head, int item)
        {
            var newBee = new Node {item = item, next = null};

            newBee.next = head;
            head = newBee;
            return head;
        }

        public static OwnBigInteger operator +(
            OwnBigInteger first, OwnBigInteger second)
        {
            var res = new OwnBigInteger();
            Node firstRunner = first._head;
            Node secondRunner = second._head;
            int carry = 0;

            while (firstRunner != null && secondRunner != null)
            {
                int i = firstRunner.item + secondRunner.item + carry;
                carry = i >= 10 ? 1 : 0;
                res.Add(i%10, false);
                firstRunner = firstRunner.next;
                secondRunner = secondRunner.next;
            }
            if (first._length > second._length)
            {
                while (firstRunner != null)
                {
                    res.Add(firstRunner.item + carry, false);
                    firstRunner = firstRunner.next;
                }
            }
            else
            {
                while (secondRunner != null)
                {
                    res.Add(secondRunner.item + carry, false);
                    secondRunner = secondRunner.next;
                }
            }
            return res;
        }

        public static OwnBigInteger AddInReverseOrder(
            OwnBigInteger first, OwnBigInteger second)
        {
            var res = new OwnBigInteger();
            Node firstRunner = first._head;
            Node secondRunner = second._head;
            int carry = 0;

            while (firstRunner != null && secondRunner != null)
            {
                int i = firstRunner.item + secondRunner.item + carry;
                carry = i >= 10 ? 1 : 0;
                res.Add(i%10, false);
                firstRunner = firstRunner.next;
                secondRunner = secondRunner.next;
            }
            if (first._length > second._length)
            {
                while (firstRunner != null)
                {
                    res.Add(firstRunner.item + carry, false);
                    firstRunner = firstRunner.next;
                }
            }
            else
            {
                while (secondRunner != null)
                {
                    res.Add(secondRunner.item + carry, false);
                    secondRunner = secondRunner.next;
                }
            }
            return res;
        }

        // сложение для прямого порядка
//        private class PartialSum
//        {
//            private Node node = null;
//            private int carry= 0;
//        }

//        public static OwnBigInteger Add(
//           OwnBigInteger first, OwnBigInteger second)
//        {
//            if (first._length > second._length)
//            {
//                second = PadLeft(second, first._length-second._length);
//            }
//            else
//            {
//                first = PadLeft(first, second._length - first._length);
//            }
//
//            PartialSum sum = AddIntegers(first, second);
//        }
//
//        private static PartialSum AddIntegers(OwnBigInteger first, OwnBigInteger second)
//        {
//            if (first == null && second == null)
//            {
//                return new PartialSum();
//            }
//            AddIntegers(first.next)
//        }
//
//        private static OwnBigInteger PadLeft(OwnBigInteger second, int i)
//        {
//            
//        }

        public void Print(bool useDelim)
        {
            _useDelim = useDelim;
            Console.WriteLine(ToString());
            _useDelim = false;
        }

        #region Overrides of Object

        public override string ToString()
        {
            string str = string.Empty;
            Node t = _head;
            while (t != null)
            {
                str += t.item + (_useDelim ? "->" : string.Empty);
                t = t.next;
            }
            return _useDelim ? str.Substring(0, str.Length - 2) : str;
        }

        #endregion

        private class Node
        {
            public int item;
            public Node next;
        }
    }
}