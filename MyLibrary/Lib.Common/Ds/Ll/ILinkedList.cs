namespace Lib.Common.Ds.Ll
{
    public interface ILinkedList<T>
    {
        T Get(int index);

        /// <summary>
        /// first occurrence
        /// </summary>
        int IndexOf(T t);

        bool Contains(T t);

        int Size();

        /// <summary>
        /// add item to the end
        /// </summary>
        void Add(T t);

        void Add(int index, T t);

        /// <summary>
        /// remove header
        /// </summary>
        T Remove();

        /// <summary>
        /// remove item in position index
        /// </summary>
        T Remove(int index);

        void Clear();
    }
}