
namespace data_structures
{
    internal interface Iterator<T>
    {
        bool HasNext();
        T Next();
    }
}
