using NUnit.Framework;
using Datastructure;

namespace LinkedListTests
{
    [TestFixture]
    public class DoubleLinkedListTests
    {
        [Test]
        public void AddFirst_WorksCorrectly()
        {
            var list = new DoubleLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            var nodes = list.GetAllNodes();
            Assert.That(nodes, Is.EqualTo(new[] { 2, 1 }));
        }

        [Test]
        public void AddLast_WorksCorrectly()
        {
            var list = new DoubleLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            var nodes = list.GetAllNodes();
            Assert.That(nodes, Is.EqualTo(new[] { 1, 2, 3 }));
        }

        [Test]
        public void SwapNodes_SwapsData()
        {
            var list = new DoubleLinkedList<string>();
            list.AddLast("A");
            list.AddLast("B");
            var nodeA = list.GetNode("A");
            var nodeB = list.GetNode("B");
            list.SwapNodes(nodeA!, nodeB!);
            var nodes = list.GetAllNodes();
            Assert.That(nodes, Is.EqualTo(new[] { "B", "A" }));
        }

        [Test]
        public void Sort_UsesBubbleSort_ByDefault()
        {
            var list = new DoubleLinkedList<int>();
            list.AddLast(5);
            list.AddLast(3);
            list.AddLast(8);
            list.AddLast(1);
            list.Sort();
            var result = list.GetAllNodes();
            Assert.That(result, Is.EqualTo(new[] { 1, 3, 5, 8 }));
        }

        [Test]
        public void AddFirst_DoesNotCrash_WhenGettingNodes()
        {
            var list = new DoubleLinkedList<int>();
            list.AddFirst(42);
            var nodes = list.GetAllNodes();
            Assert.That(nodes, Is.EqualTo(new[] { 42 }));
        }
    }
}