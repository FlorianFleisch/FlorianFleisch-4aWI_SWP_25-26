using Common;

namespace Datastructure
{
    public class SimpleLinkedList<T>
    {
        public Node<T>? head { get; private set; }

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
            }
        }
        public List<T> GetAllNodes()
        {
            Node<T>? current = head;
            List<T> Final_Data = new();
            while (current != null)
            {
                Final_Data.Add(current.data);
                current = current.next;
            }
            return Final_Data;  
        }

        public Node<T>? ContainsData(T Data)
        {
            Node<T> current = head;
            while (current.next != null)
            {
                if (current.data.Equals(Data))
                {
                    return current;
                }
                current = current.next;
            }
            return null;
        }
    }
}
