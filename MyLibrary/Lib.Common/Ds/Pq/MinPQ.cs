using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Common.Ds.Pq
{
    public class MinPQ<Key> where Key : IComparable<Key>
    {
        public MinPQ()
        { }

        public MinPQ(int max)
        { }

        public MinPQ(Key[] a)
        { }

        public void Insert(Key k)
        {
            throw new NotImplementedException();
        }

        public Key Min()
        {
            throw new NotImplementedException();
        }

        public Key DelMin()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
    }
}