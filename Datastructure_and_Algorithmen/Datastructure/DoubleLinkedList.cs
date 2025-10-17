using Common;

namespace Datastructure
{
    public class DoubleLinkedList<T>
    {
        private NodeDouble<T>? _Head;
        private NodeDouble<T>? _Tail;


        public void AddFirst(T value)
        {
            NodeDouble<T> newNode = new(value);
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
            NodeDouble<T> newNode = new(value);

            if (_Tail == null)
                _Head = _Tail = newNode;
            else
            {
                _Tail.nodeafter = newNode;
                newNode.nodebefore = _Tail;
                _Tail = newNode;
            }
            _Tail = newNode;
        }

        public NodeDouble<T>? GetNode(T toFind)
        {
            NodeDouble<T>? current = _Head;
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
            List<T> result = new();
            NodeDouble<T>? current = _Tail;
            while (current != null)
            {
                result.Add(current.data);
                current = current.nodebefore;
            }
            return result;
        }

        public NodeDouble<T>? ContainsData(T Data)
        {
            return GetNode(Data);
        }

        public int? Position(T element)
        {
            int position = 0;
            NodeDouble<T>? current = _Head;
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
