using System;
using Lib.Common.Ds.Common;
using Lib.Common.Ds.Common.Enumeration;

namespace Lib.Common.Ds.Ll
{
    public class LinkedList<T> : LinkedListEnumerable<T>, ILinkedList<T>
    {
        //public LinkedList()
        //    : this(new LinkNode<T>())
        //{ }

        public LinkedList()
        { }

        public LinkedList(LinkNode<T> first)
        {
            if (first == null) throw new ArgumentNullException("first");

            First = first;
        }

        #region ILinkedList

        public T Get(int index)
        {
            var node = GetNodeByIndex(index);

            return node == null ? default(T) : node.Value;
        }

        private LinkNode<T> GetNodeByIndex(int index)
        {
            if (index < 0 ||
                (index > 0 && index >= Size())) //let index = 0 pass
                throw new IndexOutOfRangeException();

            var i = 0;
            var current = First;
            while (i != index)
            {
                current = current.Next;
                i++;
            }

            return current;
        }

        public int IndexOf(T t)
        {
            var index = 0;

            if (First != null && First.Value.Equals(t)) return index;

            var current = First;
            while (current.Next != null)
            {
                current = current.Next;
                index++;
                if (current.Value.Equals(t)) return index;
            }

            return -1;
        }

        public bool Contains(T t)
        {
            var b = false;
            var current = First;

            while (current != null)
            {
                if (current.Value.Equals(t))
                {
                    b = true;
                    break;
                }
                current = current.Next;
            }

            return b;
        }

        public int Size()
        {
            var i = 0;
            var current = First;
            while (current != null)
            {
                i++;
                current = current.Next;
            }

            return i;
        }

        public void Add(T t)
        {
            var item = new LinkNode<T>() { Value = t };
            var current = GetLastNode();

            if (current == null)
                First = item;
            else
                current.Next = item;
        }

        public void Add(int index, T t)
        {
            var item = new LinkNode<T>() { Value = t };

            var current = GetNodeByIndex(index);
            var next = current.Next;

            current.Next = item;
            item.Next = next;
        }

        public T Remove()
        {
            var node = First;
            First = null;

            return node.Value;
        }

        public T Remove(int index)
        {
            if (First == null) return default(T);

            LinkNode<T> node;
            if (index == 0 && First != null)
            {
                node = First;
                First = First.Next;
            }
            else
            {
                node = GetNodeByIndex(index - 1);
                var tempNode = node.Next;
                node.Next = tempNode.Next;
                node = tempNode;
            }

            node.Next = null;

            return node.Value;
        }

        public void Clear()
        {
            First = null;
        }

        private LinkNode<T> GetLastNode()
        {
            if (First == null) return null;

            var current = First;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current;
        }

        #endregion
    }
}