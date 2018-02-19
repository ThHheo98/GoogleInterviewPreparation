using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonAlgo.GoogleInternInterview2014
{
    /// <summary>
    ///     http://www.careercup.com/question?id=9655082
    ///     http://www.careercup.com/question?id=5388826746814464
    ///     http://www.sinbadsoft.com/blog/sorting-big-files-using-k-way-merge-sort/
    ///     http://stackoverflow.com/questions/11026219/why-is-k-way-merge-onk2/
    ///     http://www.careercup.com/question?id=5752399786409984
    ///     Given multiple stream of input numbers each of which may not fit in memory
    ///     (we can assume each source to be individually sorted) give an API design to merge and store a fully sorted array.
    ///     Design must be object oriented which can handle any number of input source types. Obviously output also cannot fit
    ///     in memory.
    ///     We should use HEAP to save elements in partially ordered manner     
    ///     Complexity: O(nklogk)
    ///     O(logk) - heapify, repeat foreach element of n of k streams => O(n*k*logk)
    ///     Keyword: k-way mergesort, priority queue, max/min heap, google interview question
    /// </summary>
    public interface IStreamSorter<T>
    {
        IEnumerable<T> Sort(IList<IEnumerable<T>> streams, bool desc);
    }

    public class StreamSorter<T> : IStreamSorter<T>
    {
        private static readonly IComparer<T> Comparer = Comparer<T>.Default;

        public IEnumerable<T> Sort(IList<IEnumerable<T>> streams, bool desc)
        {
            if (streams == null) throw new ArgumentNullException();
            if (streams.Count == 0) yield break;

            var streamsInternal = streams.Where(enumerable => enumerable != null).ToList();
            if (!streamsInternal.Any()) yield break;

            var heap = streamsInternal
                .Select(e => new Node(e.GetEnumerator()))
                .ToArray();

            if (heap.Length == 0) yield break;

            var k = 0;
            for (var j = 0; j < heap.Length - k; j++)
            {
                Heapify(heap, heap.Length, j, desc);
                
                // if any of streams is empty we should sift it to the end of heap
                if (heap[j].HasEnded)
                {
                    Utils.Swap(ref heap[j], ref heap[heap.Length - 1 - k]);
                    k++;
                }
            }

            while (!heap[0].HasEnded)
            {
                yield return heap[0].Value;
                heap[0].MoveNext();
                
                // if stream is empty then we should sift it to the end of heap and forgot about this stream (k++)
                if (heap[0].HasEnded)
                {
                    Utils.Swap(ref heap[0], ref heap[heap.Length - 1 - k]);
                    k++;
                }
                Heapify(heap, heap.Length - k, 0, desc);
            }
        }

        private static void Heapify(Node[] heap, int size, int i, bool desc)
        {
            var l = 2*i + 1;
            var r = 2*i + 2;
            var cur = i;

            if (desc)
            {
                if (l < size && Comparer.Compare(heap[cur].Value, heap[l].Value) < 0) cur = l;
                if (r < size && Comparer.Compare(heap[cur].Value, heap[r].Value) < 0) cur = r;
            }
            else
            {
                if (l < size && Comparer.Compare(heap[cur].Value, heap[l].Value) > 0) cur = l;
                if (r < size && Comparer.Compare(heap[cur].Value, heap[r].Value) > 0) cur = r;
            }

            if (cur != i)
            {
                Utils.Swap(ref heap[cur], ref heap[i]);
                Heapify(heap, size, cur, desc);
            }
        }

        private class Node
        {
            private readonly IEnumerator<T> _enumerator;

            public Node(IEnumerator<T> enumerator)
            {
                if (enumerator == null) throw new ArgumentNullException("enumerator");
                _enumerator = enumerator;
                MoveNext();
            }

            public bool HasEnded { get; private set; }

            public T Value { get; private set; }

            public void MoveNext()
            {
                if (!_enumerator.MoveNext())
                {
                    Value = default(T);
                    HasEnded = true;
                }
                else
                {
                    Value = _enumerator.Current;
                }
            }
        }
    }

    [TestFixture]
    public class Tests
    {
        [TestCase(new[] {4}, new[] {1}, Result = new[] {1, 4})]
        public int[] SortingOfStreams1(int[] a, int[] b)
        {
            IStreamSorter<int> streamSorter = new StreamSorter<int>();
            var enumerable = streamSorter.Sort(new List<IEnumerable<int>> {a, b}, false);
            var res = new List<int>();
            foreach (var i in enumerable)
            {
                Console.Write(i + " ");
                res.Add(i);
            }
            return res.ToArray();
        }

        [TestCase(new[] {4, 5, 6}, new[] {1, 2, 3}, Result = new[] {1, 2, 3, 4, 5, 6})]
        public int[] SortingOfStreams2(int[] a, int[] b)
        {
            IStreamSorter<int> streamSorter = new StreamSorter<int>();
            var enumerable = streamSorter.Sort(new List<IEnumerable<int>> {a, b}, false);
            var res = new List<int>();
            foreach (var i in enumerable)
            {
                Console.Write(i + " ");
                res.Add(i);
            }
            return res.ToArray();
        }

        [TestCase]
        public void SortingOfStreams3()
        {
            var a = Enumerable.Empty<int>();
            var b = Enumerable.Empty<int>();
            IStreamSorter<int> streamSorter = new StreamSorter<int>();
            var enumerable = streamSorter.Sort(new List<IEnumerable<int>> {a, b}, false);
            Assert.IsTrue(!enumerable.Any());
        }

        [TestCase]
        public void SortingOfStreams31()
        {
            var a = Enumerable.Empty<int>();
            var b = new[] {2, 3};
            IStreamSorter<int> streamSorter = new StreamSorter<int>();
            var enumerable = streamSorter.Sort(new List<IEnumerable<int>> {a, b}, false).ToArray();
            Assert.IsTrue(enumerable[0] == 2);
            Assert.IsTrue(enumerable[1] == 3);
        }
        
        [TestCase]
        public void SortingOfStreams32()
        {
            var a = new[] { 2, 3 };
            var b = Enumerable.Empty<int>();
            IStreamSorter<int> streamSorter = new StreamSorter<int>();
            var enumerable = streamSorter.Sort(new List<IEnumerable<int>> {a, b}, false).ToArray();
            Assert.IsTrue(enumerable[0] == 2);
            Assert.IsTrue(enumerable[1] == 3);
        }

        [TestCase(new[] {1, 2, 3}, new[] {1, 2, 3}, new[] {4, 5, 9}, new[] {6, 7, 8},
            Result = new[] {1, 1, 2, 2, 3, 3, 4, 5, 6, 7, 8, 9})]
        public int[] SortingOfStreams4(int[] a, int[] b, int[] c, int[] d)
        {
            IStreamSorter<int> streamSorter = new StreamSorter<int>();
            var enumerable = streamSorter.Sort(new List<IEnumerable<int>> {a, b, c, d}, false);
            var res = new List<int>();
            foreach (var i in enumerable)
            {
                Console.Write(i + " ");
                res.Add(i);
            }
            return res.ToArray();
        }

        [TestCase(new[] {1, 5}, new[] {2, 3, 4}, Result = new[] {1, 2, 3, 4, 5})]
        public int[] SortingOfStreams5(int[] a, int[] b)
        {
            IStreamSorter<int> streamSorter = new StreamSorter<int>();
            var enumerable = streamSorter.Sort(new List<IEnumerable<int>> {a, b}, false);
            var res = new List<int>();
            foreach (var i in enumerable)
            {
                Console.Write(i + " ");
                res.Add(i);
            }
            return res.ToArray();
        }

        [TestCase(new[] {4}, new[] {1}, Result = new[] {4, 1})]
        public int[] SortingOfStreams6(int[] a, int[] b)
        {
            IStreamSorter<int> streamSorter = new StreamSorter<int>();
            var enumerable = streamSorter.Sort(new List<IEnumerable<int>> {a, b}, true);
            var res = new List<int>();
            foreach (var i in enumerable)
            {
                Console.Write(i + " ");
                res.Add(i);
            }
            return res.ToArray();
        }

        [TestCase(new[] {6, 5, 4}, new[] {3, 2, 1}, Result = new[] {6, 5, 4, 3, 2, 1})]
        public int[] SortingOfStreams7(int[] a, int[] b)
        {
            IStreamSorter<int> streamSorter = new StreamSorter<int>();
            var enumerable = streamSorter.Sort(new List<IEnumerable<int>> {a, b}, true);
            var res = new List<int>();
            foreach (var i in enumerable)
            {
                Console.Write(i + " ");
                res.Add(i);
            }
            return res.ToArray();
        }

        [TestCase]
        public void SortingOfStreams8()
        {
            var a = Enumerable.Empty<int>();
            var b = Enumerable.Empty<int>();
            IStreamSorter<int> streamSorter = new StreamSorter<int>();
            var enumerable = streamSorter.Sort(new List<IEnumerable<int>> {a, b}, true);
            Assert.IsTrue(!enumerable.Any());
        }

        [TestCase(new[] {3, 2, 1}, new[] {3, 2, 1}, new[] {9, 5, 4}, new[] {8, 7, 6},
            Result = new[] {9, 8, 7, 6, 5, 4, 3, 3, 2, 2, 1, 1})]
        public int[] SortingOfStreams9(int[] a, int[] b, int[] c, int[] d)
        {
            IStreamSorter<int> streamSorter = new StreamSorter<int>();
            var enumerable = streamSorter.Sort(new List<IEnumerable<int>> {a, b, c, d}, true);
            var res = new List<int>();
            foreach (var i in enumerable)
            {
                Console.Write(i + " ");
                res.Add(i);
            }
            return res.ToArray();
        }

        [TestCase(new[] {5, 1}, new[] {4, 3, 2}, Result = new[] {5, 4, 3, 2, 1})]
        public int[] SortingOfStreams10(int[] a, int[] b)
        {
            IStreamSorter<int> streamSorter = new StreamSorter<int>();
            var enumerable = streamSorter.Sort(new List<IEnumerable<int>> {a, b}, true);
            var res = new List<int>();
            foreach (var i in enumerable)
            {
                Console.Write(i + " ");
                res.Add(i);
            }
            return res.ToArray();
        }
    }
}