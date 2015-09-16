using System;

namespace Lib.Common.Ds.Pq
{
    public class IndexMinPQ<T>
    {
        private int N;
        private int[] _pq;
        private T[] _keys;

        /// <summary>
        /// Create priority queue of capacity maxN
        /// </summary>
        public IndexMinPQ(int maxN)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Insert item, associate with k
        /// </summary>
        public void Insert(int k, T t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Change the item associated with k to item
        /// </summary>
        public void Change(int k, T t)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Is k associated with some item
        /// </summary>
        public bool Contains(int k)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove k and its associated item
        /// </summary>
        public void Delete(int k)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a minimal item
        /// </summary>
        public T Min()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Return a minimal item's index
        /// </summary>
        public int MinIndex()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove a minimal item and return its index
        /// </summary>
        public int DelMin()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Is the priority queue empty
        /// </summary>
        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Number of items in the priority queue
        /// </summary>
        public int Size()
        {
            throw new NotImplementedException();
        }
    }
}
