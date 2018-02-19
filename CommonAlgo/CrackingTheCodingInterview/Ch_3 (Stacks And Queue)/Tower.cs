using System;
using System.Collections.Generic;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Tower
    {
        private readonly Stack<int> _disks;
        private readonly int _index;

        public Tower(int i)
        {
            _disks = new Stack<int>();
            _index = i;
        }

        public void Add(int value)
        {
            if (_disks.Count > 0 && _disks.Peek() <= value)
            {
                Console.WriteLine("Ошибка перемещения диска {0}", value);
            }
            else
            {
                _disks.Push(value);
            }
        }

        private void MoveTopTo(Tower t)
        {
            int top = _disks.Pop();
            t.Add(top);
            Console.WriteLine("Move disk from {0} from {1} to {2}", top, _index, t._index);
        }

        public void MoveDisks(int n, Tower destination, Tower buffer)
        {
            if (n > 0)
            {
                MoveDisks(n - 1, buffer, destination);
                MoveTopTo(destination);
                buffer.MoveDisks(n - 1, destination, this);
            }
        }

        public override string ToString()
        {
            var t = new Stack<int>(new Stack<int>(_disks));

            string r = string.Empty;
            while (t.Count > 0)
            {
                r += t.Pop() + " ";
            }
            return r;
        }

        public static void Hanoi(int n, Tower source, Tower destination, Tower buffer)
        {
            if (n > 0)
            {
                Hanoi(n - 1, source, buffer, destination);
                source.MoveTopTo(destination);
                Hanoi(n - 1, buffer, destination, source);
            }
        }
    }

    
}