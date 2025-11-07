using Common;
using System.Collections.Generic;

namespace Datastructure
{
    public class DoubleLinkedList<T>
    {
        private Node<T>? _Head;
        private Node<T>? _Tail;

        public Node<T>? Head => _Head;

        private ISortStrategy<T> _sortStrategy = new BubbleSortStrategy<T>();

        public void SetSortStrategy(ISortStrategy<T> strategy)
        {
            _sortStrategy = strategy;
        }

        public void Sort()
        {
            _sortStrategy.Sort(this);
        }

        public void SwapNodes(Node<T> node1, Node<T> node2)
        {
            if (node1 == node2 || node1 == null || node2 == null) return;
            T temp = node1.data;
            node1.data = node2.data;
            node2.data = temp;
        }

        public void AddFirst(T value)
        {
            Node<T> newNode = new(value);
            if (_Head == null)
            {
                _Head = _Tail = newNode;
            }
            else
            {
                newNode.nodeafter = _Head;
                _Head.nodebefore = newNode;
                _Head = newNode;
            }
        }

        public void AddLast(T value)
        {
            Node<T> newNode = new(value);
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

        public Node<T>? GetNode(T toFind)
        {
            Node<T>? current = _Head;
            while (current != null)
            {
                if (current.data != null && current.data.Equals(toFind))
                    return current;
                current = current.nodeafter;
            }
            return null;
        }

        public List<T> GetAllNodes()
        {
            List<T> result = new();
            Node<T>? current = _Tail;
            while (current != null)
            {
                result.Add(current.data);
                current = current.nodebefore;
            }
            return result;
        }

        public Node<T>? ContainsData(T Data)
        {
            return GetNode(Data);
        }

        public int? Position(T element)
        {
            int position = 0;
            Node<T>? current = _Head;
            while (current != null)
            {
                if (current.data != null && current.data.Equals(element))
                {
                    return position;
                }
                position++;
                current = current.nodeafter;
            }
            return null;
        }
    }
}