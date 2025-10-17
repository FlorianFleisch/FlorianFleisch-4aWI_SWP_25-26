namespace Common
{
    public class Node<T>
    {
        public T data;
        public Node<T>? nodeafter;
        public Node<T>? nodebefore;

        public Node(T data)
        {
            this.data = data;
        }
    }
}