using System;
using System.Text;
using Ds.Queue;
using Lib.Common.Ds.Common;
using Lib.Common.Ds.Common.Enumeration;

namespace Lib.Common.Ds.Queue
{
    public class Queue<T> : LinkedListEnumerable<T>, IQueue<T>
    {
        private int _n;
        private LinkNode<T> _last;

        public Queue()
        {
            _n = 0;
            First = null;
            _last = null;
        }

        #region IQueue

        public void Enqueue(T item)
        {
            var temp = First;
            First = new LinkNode<T> { Value = item, Next = temp };

            if (_last == null) _last = First;

            ++_n;
        }

        public T Dequeue()
        {
            if (IsEmpty()) throw new InvalidOperationException();

            var item = _last.Value;

            if (First.Next == null)
            {
                First = null;
                _last = null;
            }
            else
            {
                var current = First;

                while (current.Next != _last)
                {
                    current = current.Next;
                }

                _last = current;
                _last.Next = null;
            }

            --_n;

            return item;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException();

            return First.Value;
        }

        public bool IsEmpty()
        {
            return First == null;
        }

        public int Size()
        {
            return _n;
        }

        #endregion

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var n in this)
            {
                sb.Append(n + " ");
            }

            return sb.ToString();
        }
    }
}