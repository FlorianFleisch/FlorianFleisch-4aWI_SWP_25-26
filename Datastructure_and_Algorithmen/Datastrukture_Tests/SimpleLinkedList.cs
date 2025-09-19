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
    }
}
