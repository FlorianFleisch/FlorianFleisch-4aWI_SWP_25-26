using NUnit.Framework;
using Datastructure;

namespace LinkedListTests
{
    [TestFixture]
    public class SimpleLinkedListTests
    {
        [Test]
        public void AddFirst_AddsElementAtHead()
        {
            var list = new SimpleLinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            var nodes = list.GetAllNodes();
            Assert.That(nodes, Is.EqualTo(new[] { 2, 1 }));
        }

        [Test]
        public void AddLast_AddsElementAtEnd()
        {
            var list = new SimpleLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            var nodes = list.GetAllNodes();
            Assert.That(nodes, Is.EqualTo(new[] { 1, 2, 3 }));
        }

        [Test]
        public void GetNode_ReturnsCorrectNode()
        {
            var list = new SimpleLinkedList<string>();
            list.AddLast("A");
            list.AddLast("B");
            var node = list.GetNode("B");
            Assert.That(node, Is.Not.Null);
            Assert.That(node!.data, Is.EqualTo("B"));
        }

        [Test]
        public void Position_ReturnsCorrectIndex()
        {
            var list = new SimpleLinkedList<string>();
            list.AddLast("A");
            list.AddLast("B");
            list.AddLast("C");
            Assert.That(list.Position("A"), Is.EqualTo(0));
            Assert.That(list.Position("B"), Is.EqualTo(1));
            Assert.That(list.Position("C"), Is.EqualTo(2));
            Assert.That(list.Position("X"), Is.Null);
        }
    }
}
