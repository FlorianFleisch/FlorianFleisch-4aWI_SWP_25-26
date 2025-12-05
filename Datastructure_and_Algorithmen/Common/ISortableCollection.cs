using System;

namespace Common
{
    public interface ISortableCollection<T> where T : IComparable<T>
    {
        int Count();
        T Get(int index);
        void Swap(int indexA, int indexB);
    }
}
