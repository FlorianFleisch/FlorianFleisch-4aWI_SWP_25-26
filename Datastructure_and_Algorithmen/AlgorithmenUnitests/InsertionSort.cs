using SortingAlgorithms;

namespace AlgorithmenUnitests
{
    public class InsertionSortStrategyTests
    {
        [Test]
        public void Sort_SortingEmptyList_DoesNotThrowsExeptions()
        {
            var list = new MockSortableCollection<int>([]);
            var bubble = new InsertionSortStrategy<int>();
            bubble.Sort(list);
            Assert.That(list.Items, Is.Empty);
        }

        [Test]
        public void Sort_SortNumbers_WorksWithInts()
        {
            var data = new[] { 4, 2, 7, 1 };
            var collection = new MockSortableCollection<int>(data);
            var strategy = new InsertionSortStrategy<int>();

            strategy.Sort(collection);

            Assert.That(collection.Items, Is.EqualTo(new[] { 1, 2, 4, 7 }));
        }

        [Test]
        public void Sort_SortPersons_WorksWithPerson()
        {
            var data = new[] { 4, 2, 7, 1 };
            var collection = new MockSortableCollection<int>(data);
            var strategy = new InsertionSortStrategy<int>();

            strategy.Sort(collection);

            Assert.That(collection.Items, Is.EqualTo(new[] { 1, 2, 4, 7 }));
        }
    }
}
