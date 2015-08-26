﻿namespace Lib.Common.Ds.Common.Enumeration
{
    public class SequentialSearchStEnumerable<TKey, TValue> : EnumerableEntity<TKey>
    {
        protected LinkNodeST<TKey, TValue> First;

        private LinkNodeST<TKey, TValue> _enumerableItem;

        //public SequentialSearchStEnumerable()
        //{
        //    _enumerableItem = new LinkNodeST<TKey, TValue>();
        //}

        public override bool MoveNext()
        {
            if (_enumerableItem.Next == null) return false;

            _enumerableItem = _enumerableItem.Next;

            return true;
        }

        public override void Reset()
        {
            _enumerableItem = new LinkNodeST<TKey, TValue> {Next = First};
        }

        public override TKey Current
        {
            get
            {
                return _enumerableItem.Key;
            }
        }
    }
}
