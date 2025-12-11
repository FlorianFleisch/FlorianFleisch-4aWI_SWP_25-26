namespace Datastructure
{
    public class Stack<T>
    {
        private SimpleLinkedList<T> list = new SimpleLinkedList<T>();

        public void Push(T item)
        {
            list.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack ist leer!");

            T last = Peek();
            list.RemoveFirst();
            return last;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack ist leer!");

            return list.GetFirst();
        }

        public int Count => list.Count();

        public bool IsEmpty() => list.Count() == 0;

        public List<T> ToList()
        {
            return list.GetAllNodes();
        }
    }
}
