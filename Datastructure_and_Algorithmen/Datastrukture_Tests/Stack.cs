using System;
using NUnit.Framework;
using Datastructure;

namespace Tests
{
    [TestFixture]
    public class StackTests
    {
        private Datastructure.Stack<int> stack;

        [SetUp]
        public void Setup()
        {
            stack = new Datastructure.Stack<int>();
        }

        [Test]
        public void Push_IncreasesCount_And_MakesStackNonEmpty()
        {
            Assert.That(stack.IsEmpty(), Is.True);
            Assert.That(stack.Count, Is.EqualTo(0));

            stack.Push(10);
            stack.Push(20);

            Assert.That(stack.IsEmpty(), Is.False);
            Assert.That(stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Pop_ReturnsValuesInLifoOrder_And_DecreasesCount()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            int a = stack.Pop();
            int b = stack.Pop();
            int c = stack.Pop();

            Assert.That(a, Is.EqualTo(3));
            Assert.That(b, Is.EqualTo(2));
            Assert.That(c, Is.EqualTo(1));
            Assert.That(stack.Count, Is.EqualTo(0));
            Assert.That(stack.IsEmpty(), Is.True);
        }

        [Test]
        public void Peek_ReturnsTopElement_WithoutRemovingIt()
        {
            stack.Push(5);
            stack.Push(10);

            int top = stack.Peek();

            Assert.That(top, Is.EqualTo(10));
            Assert.That(stack.Count, Is.EqualTo(2));
            Assert.That(stack.IsEmpty(), Is.False);
        }

        [Test]
        public void Pop_OnEmptyStack_ThrowsInvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => stack.Pop());
            Assert.That(ex!.Message, Is.EqualTo("Stack ist leer!"));
        }

        [Test]
        public void Peek_OnEmptyStack_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Test]
        public void ToList_ReturnsInternalOrder()
        {
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var list = stack.ToList();

            Assert.That(list.Count, Is.EqualTo(3));
            Assert.That(list[0], Is.EqualTo(3));
            Assert.That(list[1], Is.EqualTo(2));
            Assert.That(list[2], Is.EqualTo(1));
        }

        [Test]
        public void IsEmpty_ReflectsStateCorrectly()
        {
            Assert.That(stack.IsEmpty(), Is.True);

            stack.Push(100);
            Assert.That(stack.IsEmpty(), Is.False);

            stack.Pop();
            Assert.That(stack.IsEmpty(), Is.True);
        }
    }
}
