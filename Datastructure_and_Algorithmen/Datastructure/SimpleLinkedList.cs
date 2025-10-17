using Common;

namespace Datastructure
{
    public class SimpleLinkedList<T>
    {
        public NodeSimple<T>? head { get; private set; }

        public void InsertAfter(T elementBefore, T elementToInsert)
        {
            NodeSimple<T>? before = GetNode(elementBefore);

            if (before != null)
            {
                NodeSimple<T> newNode = new NodeSimple<T>(elementToInsert);
                newNode.next = before.next;
                before.next = newNode;
            }
        }

        public void InsertBefore(T elementAfter, T elementToInsert)
        {
            NodeSimple<T>? before = GetNodeBefore(elementAfter);
            if (head.data.Equals(elementAfter))
            {
                NodeSimple<T> node = new NodeSimple<T>(elementToInsert);
                node.next = head;
                head = node;
            }
            if (before != null)
            {
                NodeSimple<T> newNode = new NodeSimple<T>(elementToInsert);
                newNode.next = before.next;
                before.next = newNode;
            }
        }
        public void Add(T value)
        {
            NodeSimple<T> newNode = new NodeSimple<T>(value);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                NodeSimple<T> current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
            }
        }

        public NodeSimple<T>? GetNode(T toFind)
        {
            NodeSimple<T>? current = head;
            while (current != null)
            {
                if (current.data.Equals(toFind))
                    return current;
                current = current.next;
            }
            return null;
        }

        public NodeSimple<T>? GetNodeBefore(T toFind)
        {
            NodeSimple<T>? current = head;
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
            NodeSimple<T>? current = head;
            List<T> Final_Data = new();
            while (current != null)
            {
                Final_Data.Add(current.data);
                current = current.next;
            }
            return Final_Data;
        }

        public NodeSimple<T>? ContainsData(T Data)
        {
            NodeSimple<T> current = head;
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
            NodeSimple<T>? current = head;
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