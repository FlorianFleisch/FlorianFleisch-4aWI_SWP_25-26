using Common;

namespace SortingAlgorithms
{
    public static class SortStrategyFactory
    {
        public static ISortStrategy<T> Create<T>(SortStrategyType strategyType) where T : IComparable<T>
        {
            return strategyType switch
            {
                SortStrategyType.Insertion => new InsertionSortStrategy<T>(),
                _ => new BubbleSortStrategy<T>()
            };
        }
    }
}
