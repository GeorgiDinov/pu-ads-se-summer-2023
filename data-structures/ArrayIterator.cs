
namespace data_structures
{
    internal class ArrayIterator<T> : Iterator<T>
    {

        private int position;
        private object[] array;

        public ArrayIterator(object[] array)
        {
            this.position = 0;
            this.array = array;
        }

        public bool HasNext()
        {
            return position < array.Length && array[position] != null;
        }

        public T Next()
        {
            return (T)array[position++];
        }
    }
}
