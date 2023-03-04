
namespace data_structures
{
    internal class ListIterator<T> : Iterator<T>
    {

        private IterableNode<T> node;

        public ListIterator(IterableNode<T> node)
        {
            this.node = node;
        }

        public bool HasNext()
        {
            return node != null;
        }

        public T Next()
        {
            T value = node.Value();
            node = node.Next();
            return value;
        }
    }
}
