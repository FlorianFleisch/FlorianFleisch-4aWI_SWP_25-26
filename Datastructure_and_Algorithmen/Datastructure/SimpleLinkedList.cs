using Common;
using System.Threading;

namespace Datastructure
{
    public class SimpleLinkedList<T>
    {
        public Node<T>? head { get; private set; }
        private int _Count;

        public void InsertAfter(T elementBefore, T elementToInsert)
        {
            Node<T>? before = GetNode(elementBefore);

            if (before != null)
            {
                Node<T> newNode = new Node<T>(elementToInsert);
                newNode.nodeafter = before.nodeafter;
                before.nodeafter = newNode;
                _Count++;
            }
        }

        public void InsertBefore(T elementAfter, T elementToInsert)
        {
            Node<T>? before = GetNodeBefore(elementAfter);
            if (head.data.Equals(elementAfter))
            {
                Node<T> node = new Node<T>(elementToInsert);
                node.nodeafter = head;
                head = node;
                _Count++;
            }
            if (before != null)
            {
                Node<T> newNode = new Node<T>(elementToInsert);
                newNode.nodeafter = before.nodeafter;
                before.nodeafter = newNode;
                _Count++;
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
                while (current.nodeafter != null)
                {
                    current = current.nodeafter;
                }
                current.nodeafter = newNode;
            }
            _Count++;
        }

        public Node<T>? GetNode(T toFind)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (current.data.Equals(toFind))
                    return current;
                current = current.nodeafter;
            }
            return null;
        }

        public Node<T>? GetNodeBefore(T toFind)
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (current.nodeafter.data.Equals(toFind))
                    return current;
                current = current.nodeafter;
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
                current = current.nodeafter;
            }            return Final_Data;
        }

        public bool Contains(T data) 
        {
            Node<T>? current = head;
            while (current != null)
            {
                if (current.data.Equals(data))
                    return true;
                current = current.nodeafter;
            }
            return false;
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
                current = current.nodeafter;
            }
            return null;
        }

        public int Count() => _Count;
      
        public T GetFirst()
        {
            if (head == null)
                throw new InvalidOperationException("Head is Null here");
            return head.data;
        }

        public void RemoveFirst()
        {
            if (head == null)
                return;

            head = head.nodeafter;
            _Count--;
        }

        public void AddFirst(T data)
        {
            Node<T> toAdd = new(data);
            toAdd.nodeafter = head;
            head = toAdd;
            _Count++;
        }
    }
}