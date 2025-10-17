namespace Common
{
    public class NodeSimple<T>
    {
        public T data;
        public NodeSimple<T>? next;

        public NodeSimple(T data)
        {
            this.data = data;
        }
    }
}