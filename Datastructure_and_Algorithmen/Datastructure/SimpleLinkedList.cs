using Common;

namespace Datastructure
{
    public class SimpleLinkedList<T>
    {
        public Node<T>? head { get; private set; }

        public void InsertAfter(T elementBefore, T elementToInsert)
        {
            Node<T>? before = GetNode(elementBefore);
            
            if (before != null)
            {
                Node<T> newNode = new Node<T>(elementToInsert);
                newNode.next = before.next;
                before.next = newNode;
            }
        }

        public void InsertBefore(T elementAfter, T elementToInsert)
        {
            Node<T>? before = GetNodeBefore(elementAfter);

            if (before != null)
            {
                Node<T> newNode = new Node<T>(elementToInsert);
                newNode.next = before.next;
                before.next = newNode;
            }
        }
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

        public Node<T>? GetNode(T toFind)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (current.data.Equals(toFind))
                    return current;
                current = current.next;
            }
            return null;
        }

        public Node<T>? GetNodeBefore(T toFind)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (current.next.data.Equals(toFind))
                    return current;
                current = current.next;
            }
            return null;
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

        public int? Position(T element)
        {
            int position = 0;
            Node<T>? current = head;
            while (current != null)
            {
                if (current.data.Equals(element))
                {
                    return position;
                }
                position = position + 1;
                current = current.next;
            }
            return null;
        }
    }
}
