using SortingAlgorithms;
namespace AlgorithmenUnitests
{
    [TestFixture]
    public class BubbleSortStrategyTests
    {
        [Test]
        public void BubbleSort_Sorts_EmptyList_WithoutError()
        {
            var list = new MockSortableCollection<int>([]);
            var bubble = new BubbleSortStrategy<int>();
            bubble.Sort(list);
            Assert.That(list.Items, Is.Empty);
        }

        [Test]
        public void BubbleSort_Works_On_Any_ISortableCollection()
        {
            var data = new[] { 4, 2, 7, 1 };
            var collection = new MockSortableCollection<int>(data);
            var strategy = new BubbleSortStrategy<int>();

            strategy.Sort(collection);

            Assert.That(collection.Items, Is.EqualTo(new[] { 1, 2, 4, 7 }));
        }
    }
}
