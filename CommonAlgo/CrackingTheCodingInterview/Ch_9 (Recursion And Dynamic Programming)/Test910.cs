using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview
{
    public class Test910
    {
        [TestCase]
        public void Test()
        {
        }

        public List<Box> CreateStackDP(Box[] boxes, Box bottom, Dictionary<Box, List<Box>> dictionary)
        {
            if (bottom != null && dictionary.ContainsKey(bottom))
            {
                return dictionary[bottom];
            }
            int maxHeight = 0;
            List<Box> maxStack = null;
            for (int i = 0; i < boxes.Length; i++)
            {
                if (!boxes[i].CanBeAbove(bottom)) continue;
                List<Box> ns = CreateStackDP(boxes, boxes[i], dictionary);
                if (ns.Count <= maxHeight) continue;
                maxStack = ns;
                maxHeight = ns.Count;
            }
            if (maxStack == null) maxStack = new List<Box>();
            if (bottom != null) maxStack.Insert(0, bottom);
            dictionary.Add(bottom, maxStack);
            return (List<Box>) maxStack.Clone();
        }
    }

    internal static class Extensions
    {
        public static IList<T> Clone<T>(this IEnumerable<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T) item.Clone()).ToList();
        }
    }

    public class Box : ICloneable
    {
        public object Clone()
        {
            return new Box();
        }

        public bool CanBeAbove(Box bottom)
        {
            return true;
        }
    }
}