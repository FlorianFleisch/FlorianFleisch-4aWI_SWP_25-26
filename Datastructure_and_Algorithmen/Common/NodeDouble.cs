namespace Common
{
    public class NodeDouble<T>
    {
        public T data;
        public NodeDouble<T>? nodeafter;
        public NodeDouble<T>? nodebefore;

        public NodeDouble(T data)
        {
            this.data = data;
        }
    }
}