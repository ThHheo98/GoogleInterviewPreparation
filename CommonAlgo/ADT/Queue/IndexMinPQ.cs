using System;
using System.Collections;
using System.Collections.Generic;

namespace CommonAlgo.ADT.Queue
{
    public class IndexMinPQ<Key> : IEnumerable<int> where Key : IComparable<Key>
    {
        private readonly int NMAX; // maximum number of elements on PQ
        private readonly Key[] keys; // keys[i] = priority of i
        private readonly int[] pq; // binary heap using 1-based indexing
        private readonly int[] qp; // inverse of pq - qp[pq[i]] = pq[qp[i]] = i
        private int N; // number of elements on PQ

        /**
     * Initializes an empty indexed priority queue with indices between 0 and NMAX-1.
     * @param NMAX the keys on the priority queue are index from 0 to NMAX-1
     * @throws java.lang.IllegalArgumentException if NMAX < 0
     */

        public IndexMinPQ(int NMAX)
        {
            if (NMAX < 0) throw new ArgumentException();
            this.NMAX = NMAX;
            keys = new Key[NMAX + 1]; // make this of length NMAX??
            pq = new int[NMAX + 1];
            qp = new int[NMAX + 1]; // make this of length NMAX??
            for (int i = 0; i <= NMAX; i++) qp[i] = -1;
        }

        protected int this[int i]
        {
            get { return pq[i]; }
        }

        #region Implementation of IEnumerable

        public IEnumerator<int> GetEnumerator()
        {
            return (IEnumerator<int>) pq.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        /**
     * Is the priority queue empty?
     * @return true if the priority queue is empty; false otherwise
     */

        public bool isEmpty()
        {
            return N == 0;
        }

        /**
     * Is i an index on the priority queue?
     * @param i an index
     * @throws java.lang.IndexOutOfBoundsException unless (0 &le; i < NMAX)
     */

        public bool contains(int i)
        {
            if (i < 0 || i >= NMAX) throw new ArgumentOutOfRangeException();
            return qp[i] != -1;
        }

        /**
     * Returns the number of keys on the priority queue.
     * @return the number of keys on the priority queue
     */

        public int size()
        {
            return N;
        }

        /**
     * Associates key with index i.
     * @param i an index
     * @param key the key to associate with index i
     * @throws java.lang.IndexOutOfBoundsException unless 0 &le; i < NMAX
     * @throws java.util.IllegalArgumentException if there already is an item associated with index i
     */

        public void insert(int i, Key key)
        {
            if (i < 0 || i >= NMAX) throw new ArgumentOutOfRangeException();
            if (contains(i)) throw new ArgumentException("index is already in the priority queue");
            N++;
            qp[i] = N;
            pq[N] = i;
            keys[i] = key;
            swim(N);
        }

        /**
     * Returns an index associated with a minimum key.
     * @return an index associated with a minimum key
     * @throws java.util.NoSuchElementException if priority queue is empty
     */

        public int minIndex()
        {
            if (N == 0) throw new InvalidOperationException("Priority queue underflow");
            return pq[1];
        }

        /**
     * Returns a minimum key.
     * @return a minimum key
     * @throws java.util.NoSuchElementException if priority queue is empty
     */

        public Key minKey()
        {
            if (N == 0) throw new InvalidOperationException("Priority queue underflow");
            return keys[pq[1]];
        }

        /**
     * Removes a minimum key and returns its associated index.
     * @return an index associated with a minimum key
     * @throws java.util.NoSuchElementException if priority queue is empty
     */

        public int delMin()
        {
            if (N == 0) throw new ArgumentException("Priority queue underflow");
            int min = pq[1];
            exch(1, N--);
            sink(1);
            qp[min] = -1; // delete
            keys[pq[N + 1]] = default(Key); // to help with garbage collection
            pq[N + 1] = -1; // not needed
            return min;
        }

        /**
     * Returns the key associated with index i.
     * @param i the index of the key to return
     * @return the key associated with index i
     * @throws java.lang.IndexOutOfBoundsException unless 0 &le; i < NMAX
     * @throws java.util.NoSuchElementException no key is associated with index i
     */

        public Key keyOf(int i)
        {
            if (i < 0 || i >= NMAX) throw new InvalidOperationException();
            if (!contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            return keys[i];
        }

        /**
     * Change the key associated with index i to the specified value.
     * @param i the index of the key to change
     * @param key change the key assocated with index i to this key
     * @throws java.lang.IndexOutOfBoundsException unless 0 &le; i < NMAX
     * @deprecated Replaced by changeKey()
     */

        public void change(int i, Key key)
        {
            changeKey(i, key);
        }

        /**
     * Change the key associated with index i to the specified value.
     * @param i the index of the key to change
     * @param key change the key assocated with index i to this key
     * @throws java.lang.IndexOutOfBoundsException unless 0 &le; i < NMAX
     * @throws java.util.NoSuchElementException no key is associated with index i
     */

        public void changeKey(int i, Key key)
        {
            if (i < 0 || i >= NMAX) throw new InvalidOperationException();
            if (!contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            keys[i] = key;
            swim(qp[i]);
            sink(qp[i]);
        }

        /**
     * Decrease the key associated with index i to the specified value.
     * @param i the index of the key to decrease
     * @param key decrease the key assocated with index i to this key
     * @throws java.lang.IndexOutOfBoundsException unless 0 &le; i < NMAX
     * @throws java.lang.IllegalArgumentException if key &ge; key associated with index i
     * @throws java.util.NoSuchElementException no key is associated with index i
     */

        public void decreaseKey(int i, Key key)
        {
            if (i < 0 || i >= NMAX) throw new InvalidOperationException();
            if (!contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            if (keys[i].CompareTo(key) <= 0)
                throw new InvalidOperationException(
                    "Calling decreaseKey() with given argument would not strictly decrease the key");
            keys[i] = key;
            swim(qp[i]);
        }

        /**
     * Increase the key associated with index i to the specified value.
     * @param i the index of the key to increase
     * @param key increase the key assocated with index i to this key
     * @throws java.lang.IndexOutOfBoundsException unless 0 &le; i < NMAX
     * @throws java.lang.IllegalArgumentException if key &le; key associated with index i
     * @throws java.util.NoSuchElementException no key is associated with index i
     */

        public void increaseKey(int i, Key key)
        {
            if (i < 0 || i >= NMAX) throw new InvalidOperationException();
            if (!contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            if (keys[i].CompareTo(key) >= 0)
                throw new InvalidOperationException(
                    "Calling increaseKey() with given argument would not strictly increase the key");
            keys[i] = key;
            sink(qp[i]);
        }

        /**
     * Remove the key associated with index i.
     * @param i the index of the key to remove
     * @throws java.lang.IndexOutOfBoundsException unless 0 &le; i < NMAX
     * @throws java.util.NoSuchElementException no key is associated with index i
     */

        public void delete(int i)
        {
            if (i < 0 || i >= NMAX) throw new InvalidOperationException();
            if (!contains(i)) throw new InvalidOperationException("index is not in the priority queue");
            int index = qp[i];
            exch(index, N--);
            swim(index);
            sink(index);
            keys[i] = default(Key);
            qp[i] = -1;
        }


        /**************************************************************
    * General helper functions
    **************************************************************/

        private bool greater(int i, int j)
        {
            return keys[pq[i]].CompareTo(keys[pq[j]]) > 0;
        }

        private void exch(int i, int j)
        {
            int swap = pq[i];
            pq[i] = pq[j];
            pq[j] = swap;
            qp[pq[i]] = i;
            qp[pq[j]] = j;
        }


        /**************************************************************
    * Heap helper functions
    **************************************************************/

        private void swim(int k)
        {
            while (k > 1 && greater(k/2, k))
            {
                exch(k, k/2);
                k = k/2;
            }
        }

        private void sink(int k)
        {
            while (2*k <= N)
            {
                int j = 2*k;
                if (j < N && greater(j, j + 1)) j++;
                if (!greater(k, j)) break;
                exch(k, j);
                k = j;
            }
        }


        public IEnumerator<int> iterator()
        {
            return new HeapIterator(pq, N, keys);
        }

        private class HeapIterator : IEnumerator<int>
        {
            // create a new pq
            private readonly IndexMinPQ<Key> copy;
            private int _current;

            // add all elements to copy of heap
            // takes linear time since already in heap order so no keys move
            public HeapIterator(int[] pq, int N, Key[] keys)
            {
                copy = new IndexMinPQ<Key>(pq.Length - 1);
                for (int i = 1; i <= N; i++)
                    copy.insert(pq[i], keys[pq[i]]);
            }

            private bool HasNext()
            {
                return !copy.isEmpty();
            }

            #region Implementation of IDisposable

            public void Dispose()
            {
            }

            #endregion

            #region Implementation of IEnumerator

            public bool MoveNext()
            {
                if (!HasNext()) throw new InvalidOperationException();
                _current = copy.delMin();
                return copy.size() != 0;
            }

            public void Reset()
            {
            }

            public int Current
            {
                get { return _current; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            #endregion
        }
    }
}