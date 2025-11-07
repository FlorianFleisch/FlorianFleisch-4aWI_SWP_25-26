using Common;
using System.Collections.Generic;

namespace Datastructure
{
    public class BubbleSortStrategy<T> : ISortStrategy<T>
    {
        public void Sort(DoubleLinkedList<T> list)
        {
            if (list.Head == null) return;

            bool swapped;
            do
            {
                swapped = false;
                Node<T> current = list.Head;
                while (current.nodeafter != null)
                {
                    if (Comparer<T>.Default.Compare(current.data, current.nodeafter.data) > 0)
                    {
                        list.SwapNodes(current, current.nodeafter);
                        swapped = true;
                    }
                    current = current.nodeafter;
                }
            } while (swapped);
        }
    }
}