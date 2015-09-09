using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Ds.Pq
{
    /// <summary>
    ///  The MinPQ class represents a Generic min priority queue implementation with 
    ///  a binary heap. Can be used with a comparator instead of the natural order.
    ///  It supports the usual <em>insert</em> and <em>delete-the-minimum</em>
    ///  operations, along with methods for peeking at the minimum key,
    ///  testing if the priority queue is empty, and iterating through the keys.
    ///  This implementation uses a binary heap.
    ///  The Insert and delete-the-minimum operations take logarithmic amortized time.
    /// </summary>
    /// <typeparam name="TKey">the generic type of key on this priority queue</typeparam>
    public class MinPQ<TKey> : IEnumerable<TKey>
    {
        private TKey[] _pq;                           // store items at indices 1 to N
        private int N;                              // number of items on priority queue
        private readonly Comparer<TKey> _comparator; // optional comparator

        public MinPQ(int initCapacity)
        {
            _pq = new TKey[initCapacity + 1];
            N = 0;
        }

        public MinPQ()
            : this(1)
        { }

        public MinPQ(int initCapacity, Comparer<TKey> comparator)
        {
            this._comparator = comparator;
            _pq = new TKey[initCapacity + 1];
            N = 0;
        }

        public MinPQ(Comparer<TKey> comparator)
            : this(1, comparator)
        { }

        /// <summary>
        /// Initializes a priority queue from the array of keys. Takes time proportional to the number of keys, using sink-based heap construction.
        /// </summary>
        public MinPQ(TKey[] keys)
        {
            N = keys.Length;
            _pq = new TKey[keys.Length + 1];
            for (int i = 0; i < N; i++)
                _pq[i + 1] = keys[i];
            for (int k = N / 2; k >= 1; k--)
                Sink(k);
            Assert.IsTrue(IsMinHeap());
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        public int Size()
        {
            return N;
        }

        public TKey Min()
        {
            if (IsEmpty()) throw new InvalidOperationException("Priority queue underflow");
            return _pq[1];
        }

        /// <summary>
        /// helper function to double the size of the heap array
        /// </summary>
        private void Resize(int capacity)
        {
            Assert.IsTrue(capacity > N);
            TKey[] temp = new TKey[capacity];
            for (int i = 1; i <= N; i++)
            {
                temp[i] = _pq[i];
            }
            _pq = temp;
        }

        public void Insert(TKey x)
        {
            // double size of array if necessary
            if (N == _pq.Length - 1) Resize(2 * _pq.Length);

            // add x, and percolate it up to maintain heap invariant
            _pq[++N] = x;
            Swim(N);
            Assert.IsTrue(IsMinHeap());
        }

        public TKey DelMin()
        {
            if (IsEmpty()) throw new InvalidOperationException("Priority queue underflow");
            Exch(1, N);
            TKey min = _pq[N--];
            Sink(1);
            _pq[N + 1] = default(TKey);         // avoid loitering and help with garbage collection
            if ((N > 0) && (N == (_pq.Length - 1) / 4)) Resize(_pq.Length / 2);
            Assert.IsTrue(IsMinHeap());
            return min;
        }

        /// <summary>
        /// Helper functions to restore the heap invariant.
        /// </summary>
        private void Swim(int k)
        {
            while (k > 1 && Greater(k / 2, k))
            {
                Exch(k, k / 2);
                k = k / 2;
            }
        }

        /// <summary>
        /// Helper functions to restore the heap invariant.
        /// </summary>
        private void Sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && Greater(j, j + 1)) j++;
                if (!Greater(k, j)) break;
                Exch(k, j);
                k = j;
            }
        }

        /// <summary>
        /// Helper functions for compares and swaps.
        /// </summary>
        private bool Greater(int i, int j)
        {
            if (_comparator == null)
            {
                return ((IComparable<TKey>)_pq[i]).CompareTo(_pq[j]) > 0;
            }
            else
            {
                return _comparator.Compare(_pq[i], _pq[j]) > 0;
            }
        }

        /// <summary>
        /// Helper functions for compares and swaps.
        /// </summary>
        private void Exch(int i, int j)
        {
            TKey swap = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = swap;
        }

        // is pq[1..N] a min heap?
        private bool IsMinHeap()
        {
            return IsMinHeap(1);
        }

        // is subtree of pq[1..N] rooted at k a min heap?
        private bool IsMinHeap(int k)
        {
            if (k > N) return true;
            int left = 2 * k, right = 2 * k + 1;
            if (left <= N && Greater(k, left)) return false;
            if (right <= N && Greater(k, right)) return false;
            return IsMinHeap(left) && IsMinHeap(right);
        }

        public IEnumerator<TKey> GetEnumerator()
        {
            Reset();

            while (MoveNext())
            {
                yield return Current;
            }
        }

        private bool MoveNext()
        {
            throw new NotImplementedException();
        }

        private void Reset()
        {
            throw new NotImplementedException();
        }

        public TKey Current { get; set; }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}