using System;

namespace Lib.Common.Ds.Pq
{
    public class IndexMinPQ<TKey> where TKey : IComparable<TKey>
    {
        private readonly int _maxN;
        private readonly int[] _pq;
        private readonly TKey[] _keys;
        private int N;

        /// <summary>
        /// Create priority queue of capacity maxN
        /// </summary>
        public IndexMinPQ(int maxN)
        {
            _maxN = maxN + 1;
            N = 0;
            _pq = new int[maxN + 1];
            _keys = new TKey[maxN + 1];
            for (var i = 0; i < maxN; i++)
            {
                _pq[i] = -1;
            }
        }

        /// <summary>
        /// Insert item, associate with k
        /// </summary>
        public void Insert(int k, TKey t)
        {
            if (k < 0 || k >= _maxN) throw new IndexOutOfRangeException();
            if (Contains(k)) throw new InvalidOperationException(string.Format("Index {0} already exists", k));

            _keys[++N] = t;
            _pq[k] = N;
            Swim(N);
        }

        private void Swim(int k)
        {
            while (k > 1 && Less(k, k / 2))
            {
                Exchange(k, k / 2);
                k = k / 2;
            }
        }

        private bool Less(int i, int j)
        {
            return _keys[i].CompareTo(_keys[j]) < 0;
        }

        private void Exchange(int i, int j)
        {
            var k = _keys[i];
            _keys[i] = _keys[j];
            _keys[j] = k;

            var p = _pq[i - 1];
            _pq[i - 1] = _pq[j - 1];
            _pq[j - 1] = p;
        }

        /// <summary>
        /// Change the item associated with k to item
        /// </summary>
        public void Change(int k, TKey t)
        {
            ChangeKey(k, t);
        }

        public void ChangeKey(int k, TKey t)
        {
            if (!Contains(k)) throw new InvalidOperationException(string.Format("Index {0} does not exist", k));

            _keys[k] = t;
            Swim(k);
            Sink(k);
        }

        /// <summary>
        /// Remove a minimal item and return its index
        /// </summary>
        public int DelMin()
        {
            if (IsEmpty()) throw new InvalidOperationException("Queue is empty");

            var min = _pq[1];
            _pq[1] = _pq[N];
            _keys[1] = _keys[N];
            _pq[N--] = -1;
            Sink(1);
            return min;
        }

        /// <summary>
        /// Remove k and its associated item
        /// </summary>
        public void Delete(int k)
        {
            if (k < 0 || k >= _maxN) throw new IndexOutOfRangeException();
            if (!Contains(k)) throw new InvalidOperationException(string.Format("Index {0} does not exist", k));

            _keys[k] = _keys[N];
            _pq[k] = _pq[N];
            _pq[N--] = -1;
            Sink(k);
        }

        private void Sink(int k)
        {
            while (k * 2 <= N)
            {
                var j = k * 2;
                if (k * 2 + 1 < N && Less(k * 2 + 1, k * 2))
                {
                    j++;
                }
                if (!Less(j, k)) break;
                {
                    Exchange(j, k);
                }

                k = j;
            }
        }

        /// <summary>
        /// Return a minimal item
        /// </summary>
        public TKey Min()
        {
            return _keys[1];
        }

        /// <summary>
        /// Return a minimal item's index
        /// </summary>
        public int MinIndex()
        {
            return _pq[1];
        }

        /// <summary>
        /// Is k associated with some item
        /// </summary>
        public bool Contains(int k)
        {
            return _pq[k] != -1;
        }

        /// <summary>
        /// Is the priority queue empty
        /// </summary>
        public bool IsEmpty()
        {
            return N == 0;
        }

        /// <summary>
        /// Number of items in the priority queue
        /// </summary>
        public int Size()
        {
            return N;
        }
    }
}
