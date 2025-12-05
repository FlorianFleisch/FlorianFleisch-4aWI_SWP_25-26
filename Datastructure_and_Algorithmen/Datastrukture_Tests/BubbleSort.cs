using NUnit.Framework;
using Datastructure;
using Common;
using System;

namespace LinkedListTests
{
    [TestFixture]
    public class BubbleSortStrategyTests
    {
        [Test]
        public void BubbleSort_Sorts_DoubleLinkedList_Ints()
        {
            var list = new DoubleLinkedList<int>();
            list.AddLast(5);
            list.AddLast(3);
            list.AddLast(8);
            list.AddLast(1);

            list.Sort();

            var result = ToArray(list);
            Assert.That(result, Is.EqualTo(new[] { 1, 3, 5, 8 }));
        }

        [Test]
        public void BubbleSort_Sorts_EmptyList_WithoutError()
        {
            var list = new DoubleLinkedList<int>();

            list.Sort();

            var result = ToArray(list);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Sort_Uses_CurrentStrategy()
        {
            var list = new DoubleLinkedList<int>();
            list.AddLast(2);
            list.AddLast(1);

            var strategy = new FakeStrategy<int>();
            list.SetSortStrategy(strategy);

            list.Sort();

            Assert.That(strategy.WasCalled, Is.True);
        }

        [Test]
        public void BubbleSort_Works_On_Any_ISortableCollection()
        {
            var data = new[] { 4, 2, 7, 1 };
            var collection = new FakeCollection<int>(data);
            var strategy = new BubbleSortStrategy<int>();

            strategy.Sort(collection);

            Assert.That(collection.Data, Is.EqualTo(new[] { 1, 2, 4, 7 }));
        }

        private static T[] ToArray<T>(ISortableCollection<T> collection) where T : IComparable<T>
        {
            var result = new T[collection.Count];
            for (int i = 0; i < collection.Count; i++)
                result[i] = collection.Get(i);
            return result;
        }

        private class FakeStrategy<T> : ISortStrategy<T> where T : IComparable<T>
        {
            public bool WasCalled { get; private set; }

            public void Sort(ISortableCollection<T> collection)
            {
                WasCalled = true;
            }
        }

        private class FakeCollection<T> : ISortableCollection<T> where T : IComparable<T>
        {
            public T[] Data { get; }

            public FakeCollection(T[] data)
            {
                Data = data;
            }

            public int Count => Data.Length;

            public T Get(int index)
            {
                return Data[index];
            }

            public void Swap(int indexA, int indexB)
            {
                var temp = Data[indexA];
                Data[indexA] = Data[indexB];
                Data[indexB] = temp;
            }
        }
    }
}
