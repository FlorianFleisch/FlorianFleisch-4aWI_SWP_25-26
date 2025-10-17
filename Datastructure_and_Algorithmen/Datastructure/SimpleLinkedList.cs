using Common;

namespace Datastructure
{
    public class SimpleLinkedList<T>
    {
        private Node<T>? _Head;
        private Node<T>? _Tail;


        public void AddFirst(T value)
        {
            Node<T> newNode = new(value);
            if (_Head == null)
            {
                _Head = newNode;
            }
            _Head.nodebefore = newNode;
            newNode.nodeafter = _Head;
            _Head = newNode;
        }



        public void AddLast(T value)
        {
            Node<T> newNode = new(value);

            if (_Head == null) _Head = newNode;
            else
            {
                Node<T> current = _Head;
                while (current.nodeafter != null) 
                    current = current.nodeafter;
                current.nodeafter = newNode;
                newNode.nodebefore = current;
            }
            _Tail = newNode;
        }

        public Node<T>? GetNode(T toFind)
        {
            Node<T>? current = _Head;
            while (current != null)
            {
                if (current.data.Equals(toFind))
                    return current;
                current = current.nodeafter;
            }
            return null;
        }

        public List<T> GetAllNodes()
        {
            Node<T>? current = _Head;
            List<T> Final_Data = new();
            while (current != null)
            {
                Final_Data.Add(current.data);
                current = current.nodeafter;
            }
            return Final_Data;  
        }

        public Node<T>? ContainsData(T Data)
        {
            Node<T> current = _Head;
            while (current.nodeafter != null)
            {
                if (current.data.Equals(Data))
                {
                    return current;
                }
                current = current.nodeafter;
            }
            return null;
        }

        public int? Position(T element)
        {
            int position = 0;
            Node<T>? current = _Head;
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
    }
}
