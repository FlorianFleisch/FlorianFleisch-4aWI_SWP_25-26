using System;
using System.IO;
using NUnit.Framework;
using Datastructure;

namespace Datastructure.Tests
{
    [TestFixture]
    public class SimpleLinkedListTests
    {
        [Test]
        public void PrintAll_EmptyList_WritesNothing()
        {
            var list = new SimpleLinkedList();
            using var sw = new StringWriter();
            Console.SetOut(sw);

            list.PrintAll();

            Assert.That(sw.ToString(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Add_ThenPrintAll_PrintsValuesInInsertionOrder()
        {
            var list = new SimpleLinkedList();
            using var sw = new StringWriter();
            Console.SetOut(sw);

            list.Add(10);
            list.Add(20);
            list.Add(30);
            list.PrintAll();

            var expected = $"10{Environment.NewLine}20{Environment.NewLine}30{Environment.NewLine}";
            Assert.AreEqual(expected, sw.ToString());
        }
    }
}
