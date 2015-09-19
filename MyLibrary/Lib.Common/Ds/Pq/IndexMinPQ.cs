using System;

namespace Lib.Common.Ds.Pq
{
    public class IndexMinPQ<TKey> where TKey : IComparable<TKey>
    {
        private readonly int _maxN;
        private readonly int[] _pq;//internal heap structure 1-based indices
        private readonly int[] _qp;//inverse of _pq[], _qp[i] gives the position of i in _pq, (index j such that _pq[j] is i)
        private readonly TKey[] _keys;//key values, _keys[i] stands for priority of i
        private int N;

        /// <summary>
        /// Create priority queue of capacity maxN+1
        /// </summary>
        public IndexMinPQ(int maxN)
        {
            _maxN = maxN + 1;
            N = 0;
            _pq = new int[maxN + 1];
            _qp = new int[maxN + 1];
            _keys = new TKey[maxN + 1];
            for (var i = 0; i < maxN; i++)
            {
                _qp[i] = -1;
            }
        }

        /// <summary>
        /// Insert item, associate with index i
        /// </summary>
        public void Insert(int i, TKey t)
        {
            if (i < 0 || i >= _maxN) throw new IndexOutOfRangeException();
            if (Contains(i)) throw new InvalidOperationException(string.Format("Index {0} already exists", i));

            _keys[i] = t;
            N++;
            _qp[i] = N;
            _pq[N] = i;
            Swim(N);
        }

        // <param name="i">heap structure index</param>
        private void Swim(int i)
        {
            while (i > 1 && Less(i, i / 2))
            {
                Exchange(i, i / 2);
                i = i / 2;
            }
        }

        // <param name="i">heap structure index</param>
        private bool Less(int i, int j)
        {
            return _keys[_pq[i]].CompareTo(_keys[_pq[j]]) < 0;
        }

        // <param name="i">heap structure index</param>
        // <param name="j">heap structure index</param>
        private void Exchange(int i, int j)
        {
            var swap = _pq[i];
            _pq[i] = _pq[j];
            _pq[j] = swap;
            _qp[_pq[i]] = i;
            _qp[_pq[j]] = j;
        }

        /// <summary>
        /// Change the item associated with i to t
        /// </summary>
        public void ChangeKey(int i, TKey t)
        {
            if (i < 0 || i >= _maxN) throw new IndexOutOfRangeException();
            if (!Contains(i)) throw new InvalidOperationException(string.Format("Index {0} does not exist", i));

            _keys[i] = t;
            Swim(_qp[i]);
            Sink(_qp[i]);
        }

        /// <summary>
        /// Remove a minimal item and return its index
        /// </summary>
        public int DelMin()
        {
            if (IsEmpty()) throw new InvalidOperationException("Queue is empty");
            var min = _pq[1];
            Exchange(1, N);
            Sink(1);
            _keys[_pq[N]] = default(TKey);
            _qp[min] = -1;
            _pq[N] = -1;//can be removed?
            N--;
            return min;
        }

        /// <summary>
        /// Remove i and its associated item
        /// </summary>
        public void Delete(int i)
        {
            if (i < 0 || i >= _maxN) throw new IndexOutOfRangeException();
            if (!Contains(i)) throw new InvalidOperationException(string.Format("Index {0} does not exist", i));
            Exchange(_qp[i], N);
            Swim(_qp[i]);
            Sink(_qp[i]);

            _keys[i] = default(TKey);
            _qp[i] = -1;
            _pq[N] = -1;
            N--;
        }

        private void Sink(int i)
        {
            while (i * 2 <= N)
            {
                var j = i * 2;
                if (i * 2 + 1 < N && Less(i * 2 + 1, i * 2))
                {
                    j++;
                }
                if (!Less(j, i)) break;
                {
                    Exchange(j, i);
                }

                i = j;
            }
        }

        /// <summary>
        /// Return a minimal item
        /// </summary>
        public TKey Min()
        {
            return _keys[_pq[1]];
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
        public bool Contains(int i)
        {
            return _qp[i] != -1;
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