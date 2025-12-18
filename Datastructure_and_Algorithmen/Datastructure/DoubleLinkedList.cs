using Common;
using SortingAlgorithms;
using System;
using System.Collections.Generic;

namespace Datastructure
{
    public class DoubleLinkedList<T> : ISortableCollection<T> where T : IComparable<T>
    {
        private Node<T>? _head;
        private Node<T>? _tail;
        private int _count;

        private ISortStrategy<T> _sortStrategy = new BubbleSortStrategy<T>();

        public DoubleLinkedList()
        {
        }

        public void SetSortStrategy(ISortStrategy<T> strategy)
        {
            _sortStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public void Sort()
        {
            _sortStrategy.Sort(this);
        }

        public int Count()
        {
            return _count;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            Node<T> current = _head!;
            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }
            return current.Value;
        }

        public void Swap(int indexA, int indexB)
        {
            if (indexA < 0 || indexA >= _count || indexB < 0 || indexB >= _count)
                throw new IndexOutOfRangeException();

            if (indexA == indexB) return;

            Node<T> nodeA = GetNodeByIndex(indexA)!;
            Node<T> nodeB = GetNodeByIndex(indexB)!;

            T temp = nodeA.Value;
            nodeA.Value = nodeB.Value;
            nodeB.Value = temp;
        }

        public void AddFirst(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (_head == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Previous = newNode;
                _head = newNode;
            }

            _count++;
        }

        public void AddLast(T value)
        {
            Node<T> newNode = new Node<T>(value);

            if (_tail == null)
            {
                _head = _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Previous = _tail;
                _tail = newNode;
            }

            _count++;
        }

        public Node<T>? GetNode(int index)
        {
            return GetNodeByIndex(index);
        }

        public T[] GetAllNodes()
        {
            T[] values = new T[_count];
            Node<T>? current = _head;
            int index = 0;

            while (current != null)
            {
                values[index] = current.Value;
                current = current.Next;
                index++;
            }

            return values;
        }

        public void SwapNodes(int indexA, int indexB)
        {
            Swap(indexA, indexB);
        }

        public void SwapNodes(Node<T> nodeA, Node<T> nodeB)
        {
            if (nodeA == null || nodeB == null) throw new ArgumentNullException();
            if (ReferenceEquals(nodeA, nodeB)) return;

            (nodeA.Value, nodeB.Value) = (nodeB.Value, nodeA.Value);
        }

        public Node<T>? GetNode(T value)
        {
            Node<T>? current = _head;
            while (current != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Value, value))
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        private Node<T>? GetNodeByIndex(int index)
        {
            if (index < 0 || index >= _count) return null;

            Node<T> current = _head!;
            for (int i = 0; i < index; i++)
            {
                current = current.Next!;
            }
            return current;
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Previous { get; set; }
        public Node(T value)
        {
            Value = value;
        }
    }
}
