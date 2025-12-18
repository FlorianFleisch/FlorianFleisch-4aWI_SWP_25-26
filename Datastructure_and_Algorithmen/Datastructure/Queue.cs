namespace Datastructure
{
    public class Queue<T>
    {
        private SimpleLinkedList<T> list = new SimpleLinkedList<T>();

        public void Enqueue(T item)
        {
            list.Add(item);
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue ist leer!");

            T first = Peek();
            list.RemoveFirst();
            return first;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Queue ist leer!");

            return list.GetFirst();
        }

        public int Count => list.Count();

        public bool IsEmpty() => Count == 0;

        public List<T> ToList()
        {
            return list.GetAllNodes();
        }
    }
}
