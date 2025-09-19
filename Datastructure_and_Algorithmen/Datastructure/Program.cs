namespace Datastructure
{
    public class Program
    {
        static void Main(String[] args)
        {
            SimpleLinkedList list = new SimpleLinkedList();

            list.Add(10);
            list.Add(20);
            list.Add(30);

            list.PrintAll();
        }
    }
}