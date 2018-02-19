using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch10
{
    public class HtWt : IComparable
    {
        public readonly int _ht;
        public readonly int _wt;

        public HtWt(int h, int w)
        {
            _ht = h;
            _wt = w;
        }

        public int CompareTo(object s)
        {
            var second = (HtWt) s;
            if (_ht != second._ht)
            {
                return _ht.CompareTo(second._ht);
            }
            return _wt.CompareTo(second._wt);
        }


        public override string ToString()
        {
            return "(" + _ht + ", " + _wt + ")";
        }


        public bool IsBefore(HtWt other)
        {
            return _ht < other._ht && _wt < other._wt;
        }
    }

    public class Test107
    {
        private static void PrintList(IEnumerable<HtWt> list)
        {
            foreach (HtWt item in list)
            {
                Console.WriteLine(item + " ");
            }
        }


        private static List<HtWt> Initialize()
        {
            var item = new HtWt(65, 60);
            var items = new List<HtWt> {item};

            item = new HtWt(70, 150);
            items.Add(item);

            item = new HtWt(56, 90);
            items.Add(item);

            item = new HtWt(75, 190);
            items.Add(item);

            item = new HtWt(60, 95);
            items.Add(item);

            item = new HtWt(68, 110);
            items.Add(item);

            item = new HtWt(35, 65);
            items.Add(item);

            item = new HtWt(40, 60);
            items.Add(item);

            item = new HtWt(45, 63);
            items.Add(item);

            return items;
        }

        /// <summary>
        ///     http://e-maxx.ru/algo/longest_increasing_subseq_log
        /// </summary>
        [TestCase]
        public void Test()
        {
            List<HtWt> items = Initialize();

            items = items.OrderBy(wt => wt._ht).ToList();
            PrintList(items);
            Console.WriteLine();
            IEnumerable<HtWt> solution = LongestIncreasingSubsequence(items);
            PrintList(solution);
        }

        private static void LongestIncreasingSubsequence(List<HtWt> array, List<HtWt>[] solutions, int currentIndex)
        {
            if (currentIndex >= array.Count || currentIndex < 0)
            {
                return;
            }
            HtWt currentElement = array[currentIndex];

            // Find longest sequence that we can append current_element to
            List<HtWt> bestSequence = null;
            for (int i = 0; i < currentIndex; i++)
            {
                if (array[i].IsBefore(currentElement))
                {
                    // If current_element is bigger than list tail
                    bestSequence = SeqWithMaxLength(bestSequence, solutions[i]); // Set best_sequence to our new max
                }
            }

            // Append current_element
            var newSolution = new List<HtWt>();
            if (bestSequence != null)
            {
                newSolution.AddRange(bestSequence);
            }
            newSolution.Add(currentElement);

            // Add to list and recurse
            solutions[currentIndex] = newSolution;
            LongestIncreasingSubsequence(array, solutions, currentIndex + 1);
        }

        private static IEnumerable<HtWt> LongestIncreasingSubsequence(List<HtWt> array)
        {
            var solutions = new List<HtWt>[array.Count];
            LongestIncreasingSubsequence(array, solutions, 0);

            List<HtWt> bestSequence = null;
            for (int i = 0; i < array.Count; i++)
            {
                bestSequence = SeqWithMaxLength(bestSequence, solutions[i]);
            }

            return bestSequence;
        }

        /// <summary>
        ///     Returns longer sequence
        /// </summary>
        /// <param name="seq1"></param>
        /// <param name="seq2"></param>
        /// <returns></returns>
        private static List<HtWt> SeqWithMaxLength(List<HtWt> seq1, List<HtWt> seq2)
        {
            if (seq1 == null)
            {
                return seq2;
            }
            if (seq2 == null)
            {
                return seq1;
            }
            return seq1.Count > seq2.Count ? seq1 : seq2;
        }
    }
}