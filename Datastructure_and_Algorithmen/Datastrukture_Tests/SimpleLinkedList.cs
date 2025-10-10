namespace Datastructure.Tests
{
    [TestFixture]
    public class SimpleLinkedListTests
    {
        [Test]
        public void Add_AddOnePerson_ReturnsAddedPerson()
        {
            SimpleLinkedList<Person> list = new();
            Person person = new("deppen", "fleisch", Person.Genders.m, new DateTime(2000, 1, 1));
            list.Add(person);
            Assert.That(list.head.data, Is.EqualTo(person));
        }

        [Test]
        public void GetAllNodes_ReturnsNodes()
        {
            SimpleLinkedList<Person> list = new();
            Person person = new("deppen", "fleisch", Person.Genders.m, new DateTime(2000, 1, 1));
            list.Add(person);
            list.Add(person);
            Assert.That(list.GetAllNodes(), Is.EqualTo((new List<Person> { person, person })));
        }

        [Test]
        public void GetNode_ReturnsCorrectNode_WhenElementExists()
        {
            var list = new SimpleLinkedList<string>();
            list.Add("Felix");
            list.Add("Max");
            list.Add("Anna");

            var node = list.GetNode("Max");

            Assert.IsNotNull(node);
            Assert.AreEqual("Max", node.data);
        }

        [Test]
        public void GetNodeBefore_ReturnsCorrectNode_WhenElementExists()
        {
            var list = new SimpleLinkedList<string>();
            list.Add("Felix");
            list.Add("Max");
            list.Add("Anna");

            var nodeBefore = list.GetNodeBefore("Anna");

            Assert.IsNotNull(nodeBefore);
            Assert.AreEqual("Max", nodeBefore.data);
        }

        [Test]
        public void InsertAfter_AddsElementDirectlyAfterGivenElement()
        {
            var list = new SimpleLinkedList<string>();
            list.Add("Felix");
            list.Add("Max");
            int? pos = list.Position("Max");
            list.InsertAfter("Felix", "Anna");

            var nodes = list.GetAllNodes();

            Assert.Multiple(() =>
            {
                Assert.AreNotEqual(pos, list.Position("Max"));
                Assert.AreEqual(new List<string> { "Felix", "Anna", "Max" }, nodes);
            });
        }

        [Test]
        public void InsertBefore_AddsElementDirectlyBeforeGivenElement()
        {
            var list = new SimpleLinkedList<string>();
            list.Add("Felix");
            list.Add("Max");
            int? pos = list.Position("Max");
            list.InsertBefore("Max", "Anna");

            var nodes = list.GetAllNodes();

            Assert.Multiple(() =>
            {
                Assert.AreNotEqual(pos, list.Position("Max"));
                Assert.AreEqual(new List<string> { "Felix", "Anna", "Max" }, nodes);
            });
        }

        [Test]
        public void Position_ElementInMiddle_ReturnsCorrectIndex()
        {
            var list = new SimpleLinkedList<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");

            var result = list.Position("B");

            Assert.AreEqual(1, result);
        }
    }
}
