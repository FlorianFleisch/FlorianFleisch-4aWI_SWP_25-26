using Common;
using SortingAlgorithms;

namespace Datastructure
{
    public class DoubleLinkedList<T> : ISortableCollection<T> where T : IComparable<T>
    {
        private Node<T>? _Head;
        private Node<T>? _Tail;
        private int _Count;

        private ISortStrategy<T> _SortStrategy = SortStrategyFactory.Create<T>(SortStrategyType.Bubble);

        public void SetSortStrategy(ISortStrategy<T> strategy)
        {
            _SortStrategy = strategy;
        }

        public void SetSortStrategy(SortStrategyType strategyType)
        {
            _SortStrategy = SortStrategyFactory.Create<T>(strategyType);
        }

        public void Sort()
        {
            _SortStrategy.Sort(this);
        }

        public int Count()
        {
            return _Count;
        }

        public T Get(int index)
        {
            int i = 0;
            var current = _Head;

            while (current != null)
            {
                if (i == index)
                    return current.data;

                i++;
                current = current.nodeafter;
            }

            throw new IndexOutOfRangeException();
        }

        public void Swap(int indexA, int indexB)
        {
            if (indexA == indexB)
                return;

            Node<T>? a = _Head;
            Node<T>? b = _Head;

            int i = 0;
            while (a != null && i < indexA)
            {
                a = a.nodeafter;
                i++;
            }

            i = 0;
            while (b != null && i < indexB)
            {
                b = b.nodeafter;
                i++;
            }

            if (a == null || b == null)
                throw new IndexOutOfRangeException();

            T temp = a.data;
            a.data = b.data;
            b.data = temp;
        }

        public void AddFirst(T value)
        {
            Node<T> newNode = new(value);

            if (_Head == null)
            {
                _Head = _Tail = newNode;
                return;
            }

            newNode.nodeafter = _Head;
            _Head.nodebefore = newNode;
            _Head = newNode;
        }

        public void AddLast(T value)
        {
            Node<T> newNode = new(value);

            if (_Tail == null)
            {
                _Head = _Tail = newNode;
                return;
            }

            _Tail.nodeafter = newNode;
            newNode.nodebefore = _Tail;
            _Tail = newNode;
        }
    }
}
