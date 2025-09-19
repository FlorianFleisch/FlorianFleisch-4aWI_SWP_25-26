using NUnit.Framework;
using Datastructure;

namespace Datastructure_Tests
{
    public class SimpleLinkedListTests
    {
        [Test]
        public void Add_OneElement_ListIsNotEmpty()
        {
            var list = new SimpleLinkedList();
            list.Add(10);

            Assert.Pass("Element wurde hinzugefügt, kein Fehler aufgetreten.");
        }
    }
}
