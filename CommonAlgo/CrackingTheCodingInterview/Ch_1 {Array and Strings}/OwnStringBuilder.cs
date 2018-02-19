using System;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class OwnStringBuilder
    {
        private const int _maxCapacity = 1024;
        private string[] _array;
        private int _capacity = 1;
        private int _current;
        private int _length;

        public OwnStringBuilder()
        {
            _array = new string[_capacity];
            _length = 0;
        }

        public OwnStringBuilder(int capacity) : this()
        {
            if (capacity > _maxCapacity) throw new InvalidOperationException("Invalid capacity");
            _capacity = capacity;
        }

        public int Length
        {
            get { return _length; }
        }

        public void Append(string s)
        {
            if (_current >= _capacity) Resize(2*_capacity);
            _array[_current] = s;
            _length += s.Length;
            _current++;
        }

        private void Resize(int newSize)
        {
            if (newSize > _maxCapacity)
                throw new OutOfMemoryException(
                    "OutOfMemoryException string");
            var r = new string[newSize];

            for (int i = 0; i < _current; i++)
            {
                r[i] = _array[i];
            }
            _capacity = newSize;
            _array = r;
        }

        public override string ToString()
        {
            var chars = new char[_length];
            int i = 0;
            int j = 0;
            while (i < _length && j < _capacity)
            {
                int k = 0;
                while (k < _array[j].Length)
                {
                    chars[i] = _array[j][k];
                    k++;
                    i++;
                }
                j++;
            }
            return new string(chars);
        }

        [TestCase]
        public void Test()
        {
            var t = new OwnStringBuilder();
            for (int i = 0; i < 10; i++)
            {
                t.Append(i.ToString());
            }
            Assert.AreEqual(10, t.Length);

            Assert.AreEqual("0123456789", t.ToString());
        }
    }
}