using Common;

namespace AlgorithmenUnitests
{
    public class MockSortableCollection<T> : ISortableCollection<T> where T : IComparable<T>    
    {
        public T[] Items { get; private set; }

        public MockSortableCollection(T[] items)
        {
            Items = items.ToArray(); 
        }

        public int Count() => Items.Length;

        public T Get(int index) => Items[index];

        public void Swap(int i, int j)
        {
            T temp = Items[i];
            Items[i] = Items[j];
            Items[j] = temp;
        }
    }
}
