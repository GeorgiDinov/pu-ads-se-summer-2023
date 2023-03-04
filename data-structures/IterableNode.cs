
namespace data_structures
{
    internal interface IterableNode<T>
    {
        T Value();
        IterableNode<T> Previous();
        IterableNode<T> Next();
    }
}
