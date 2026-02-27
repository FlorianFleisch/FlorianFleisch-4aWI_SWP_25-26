using NUnit.Framework;
using Datastructure;
using System;

namespace Datastructure.Tests
{
    [TestFixture]
    public class QueueTests
    {
        [Test]
        public void Enqueue_Dequeue_Works_With_Single_Element()
        {
            var queue = new Queue<int>();

            queue.Enqueue(42);

            Assert.That(queue.Count, Is.EqualTo(1));
            Assert.That(queue.IsEmpty(), Is.False);

            int result = queue.Dequeue();

            Assert.That(result, Is.EqualTo(42));
            Assert.That(queue.Count, Is.EqualTo(0));
            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void FIFO_Order_Is_Preserved()
        {
            var queue = new Queue<string>();

            queue.Enqueue("erste");
            queue.Enqueue("zweite");
            queue.Enqueue("dritte");

            Assert.That(queue.Dequeue(), Is.EqualTo("erste"));
            Assert.That(queue.Dequeue(), Is.EqualTo("zweite"));
            Assert.That(queue.Dequeue(), Is.EqualTo("dritte"));

            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void Peek_Returns_Front_Element_Without_Removing()
        {
            var queue = new Queue<int>();

            queue.Enqueue(100);
            queue.Enqueue(200);

            Assert.That(queue.Peek(), Is.EqualTo(100));
            Assert.That(queue.Peek(), Is.EqualTo(100)); // mehrmals aufrufen
            Assert.That(queue.Count, Is.EqualTo(2));

            queue.Dequeue();
            Assert.That(queue.Peek(), Is.EqualTo(200));
        }

        [Test]
        public void Dequeue_On_Empty_Queue_Throws_InvalidOperationException()
        {
            var queue = new Queue<int>();

            Assert.That(queue.IsEmpty(), Is.True);
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public void Peek_On_Empty_Queue_Throws_InvalidOperationException()
        {
            var queue = new Queue<string>();

            Assert.Throws<InvalidOperationException>(() => queue.Peek());
        }

        [Test]
        public void Count_And_IsEmpty_Work_Correctly_After_Multiple_Operations()
        {
            var queue = new Queue<int>();

            Assert.That(queue.Count, Is.EqualTo(0));
            Assert.That(queue.IsEmpty(), Is.True);

            queue.Enqueue(1);
            queue.Enqueue(2);
            Assert.That(queue.Count, Is.EqualTo(2));
            Assert.That(queue.IsEmpty(), Is.False);

            queue.Dequeue();
            Assert.That(queue.Count, Is.EqualTo(1));

            queue.Dequeue();
            Assert.That(queue.Count, Is.EqualTo(0));
            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void Works_With_Large_Number_Of_Elements()
        {
            var queue = new Queue<int>();
            const int n = 1000;

            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(i);
            }

            Assert.That(queue.Count, Is.EqualTo(n));

            for (int i = 0; i < n; i++)
            {
                Assert.That(queue.Dequeue(), Is.EqualTo(i));
            }

            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void ToList_Returns_Elements_In_Correct_Order_For_Debugging()
        {
            var queue = new Queue<string>();

            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");

            var list = queue.ToList();

            Assert.That(list, Has.Count.EqualTo(3));
            Assert.That(list[0], Is.EqualTo("A"));
            Assert.That(list[1], Is.EqualTo("B"));
            Assert.That(list[2], Is.EqualTo("C"));
        }

        [Test]
        public void Queue_Works_With_Reference_Types()
        {
            var queue = new Queue<object>();

            var obj1 = new object();
            var obj2 = new object();

            queue.Enqueue(obj1);
            queue.Enqueue(obj2);

            Assert.That(queue.Dequeue(), Is.SameAs(obj1));
            Assert.That(queue.Dequeue(), Is.SameAs(obj2));
        }

        [Test]
        public void Multiple_Enqueue_Dequeue_Cycles()
        {
            var queue = new Queue<int>();

            queue.Enqueue(10);
            queue.Enqueue(20);
            Assert.That(queue.Dequeue(), Is.EqualTo(10));

            queue.Enqueue(30);
            Assert.That(queue.Dequeue(), Is.EqualTo(20));
            Assert.That(queue.Dequeue(), Is.EqualTo(30));

            Assert.That(queue.IsEmpty(), Is.True);
        }
    }
}