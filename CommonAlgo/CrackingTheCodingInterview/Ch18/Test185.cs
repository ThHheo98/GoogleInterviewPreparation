using System.Collections.Generic;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch18
{
    /// <summary>
    /// Find shortest distance between two words O(n)
    /// </summary>
    public class Test185
    {
        private IList<string> _sList;

        [SetUp]
        public void Setup()
        {
            _sList = new List<string> {"a", "b", "c", "d", "e"};
        }

        [TestCase("a", "e", Result = 4, TestName = "test1")]
        [TestCase("a", "e", Result = 4, TestName = "test2")]
        public int Test(string firstWord, string secondWord)
        {
            return Shortest(_sList, firstWord, secondWord);
        }

        private int Shortest(IList<string> sList, string firstWord, string secondWord)
        {
            int min = int.MaxValue;
            int lastPosWord1 = -1;
            int lastPosWord2 = -1;
            for (int i = 0; i < sList.Count; i++)
            {
                if (sList[i].Equals(firstWord))
                {
                    lastPosWord1 = i;

                    int distance = lastPosWord1 - lastPosWord2;
                    if (lastPosWord2 >= 0 && min > distance)
                    {
                        min = distance;
                    }
                }
                else if (sList[i].Equals(secondWord))
                {
                    lastPosWord2 = i;
                    int distance = lastPosWord2 - lastPosWord1;
                    if (lastPosWord1 >= 0 && min > distance)
                    {
                        min = distance;
                    }
                }
            }
            return min;
        }
    }
}