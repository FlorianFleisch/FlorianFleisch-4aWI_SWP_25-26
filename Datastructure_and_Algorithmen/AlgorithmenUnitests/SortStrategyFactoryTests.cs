using Common;
using SortingAlgorithms;

namespace AlgorithmenUnitests
{
    [TestFixture]
    public class SortStrategyFactoryTests
    {
        [Test]
        public void Create_Returns_BubbleSort_For_Bubble_Type()
        {
            var strategy = SortStrategyFactory.Create<int>(SortStrategyType.Bubble);

            Assert.That(strategy, Is.TypeOf<BubbleSortStrategy<int>>());
        }

        [Test]
        public void Create_Returns_InsertionSort_For_Insertion_Type()
        {
            var strategy = SortStrategyFactory.Create<int>(SortStrategyType.Insertion);

            Assert.That(strategy, Is.TypeOf<InsertionSortStrategy<int>>());
        }
    }
}