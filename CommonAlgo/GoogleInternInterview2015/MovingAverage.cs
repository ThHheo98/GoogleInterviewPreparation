using System;
using NUnit.Framework;

// ReSharper disable MemberCanBePrivate.Global

namespace CommonAlgo.GoogleInternInterview2015
{
    public class CircularBuffer
    {
        private readonly int[] _buffer;
        private bool _bufferFull;
        private int _sum;
        private int _tail;

        public CircularBuffer(int n)
        {
            _bufferFull = false;
            _tail = 0;
            _sum = 0;
            _buffer = new int[n];
        }

        public void AddNumber(int number)
        {
            _sum += number;
            if (_bufferFull)
            {
                _sum -= _buffer[_tail];
            }

            _buffer[_tail] = number;
            _tail++;

            if (_tail >= _buffer.Length)
            {
                _tail = _tail%_buffer.Length;
                _bufferFull = true;
            }
        }

        public double Avg()
        {
            var length = _tail;
            if (_bufferFull)
            {
                length = _buffer.Length;
            }
            return (double) _sum/length;
        }

        public class MovingAverage
        {
            [TestCase]
            public void Test()
            {
                var buf = new CircularBuffer(4);
                buf.AddNumber(1);
                buf.AddNumber(2);
                buf.AddNumber(7);
                buf.AddNumber(3);
                Console.WriteLine("Avg " + buf.Avg());
                buf.AddNumber(5);
                Console.WriteLine("Avg " + buf.Avg());
            }
        }
    }
}