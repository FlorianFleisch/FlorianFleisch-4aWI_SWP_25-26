namespace Common
{
    public interface ISortStrategy<T> where T : IComparable<T>
    {
        void Sort(ISortableCollection<T> collection);
    }
}
