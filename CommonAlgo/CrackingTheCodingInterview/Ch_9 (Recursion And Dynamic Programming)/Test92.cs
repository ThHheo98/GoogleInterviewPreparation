using System.Collections.Generic;
using CommonAlgo.Misc;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test92
    {
        [TestCase]
        public void Test()
        {
            var paths = new List<Overlap.Point>();
            var cache = new Dictionary<Overlap.Point, bool>();
            GetPath(1, 2, paths, cache);
        }

        private bool GetPath(int x, int y, List<Overlap.Point> paths, Dictionary<Overlap.Point, bool> cache)
        {
            var p = new Overlap.Point {_x = x, _y = y};
            bool r;
            if (cache.TryGetValue(p, out r))
            {
                return r;
            }
            paths.Add(p);
            if (x == 0 && y == 0)
                return true;

            bool success = false;

            if (x >= 1 && IsFree(x - 1, y))
            {
                success = GetPath(x - 1, y, paths, cache);
            }
            if (!success && y >= 1 && IsFree(x, y - 1))
                success = GetPath(x, y - 1, paths, cache);
            if (!success)
                paths.Remove(p);
            cache.Add(p, success);
            return success;
        }

        private bool IsFree(int x, int y)
        {
            return true;
        }
    }
}