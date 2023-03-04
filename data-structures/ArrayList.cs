using System;

namespace data_structures
{
    internal class ArrayList<T>
    {

        private const int DefaultCapacity = 10;
        private int size;
        private object[] arrayList;


        //== constructors ==
        public ArrayList() : this(DefaultCapacity)
        {

        }

        public ArrayList(int initialCapacity)
        {
            this.size = 0;
            if (initialCapacity < 0)
            {
                initialCapacity = DefaultCapacity;
            }
            this.arrayList = new object[initialCapacity];
        }


        //== public methods ==
        public void Add(T item)
        {
            AddLast(item);
        }

        public void Add(int position, T item)
        {
            if (IsIndexOutOfRange(position))
            {
                throw new IndexOutOfRangeException(IndexOutOfRangeMsg(position));
            }
            if (IsFull())
            {
                int newCapacity = DetermineNewCapacity();
                arrayList = GrowArrayList(newCapacity);
            }

            Array.Copy(arrayList, position, arrayList, position + 1, size - position);
            arrayList[position] = item;
            size++;
        }

        public T Get(int position)
        {
            if (IsIndexOutOfRange(position))
            {
                throw new IndexOutOfRangeException(IndexOutOfRangeMsg(position));
            }
            return (T)arrayList[position];
        }

        public T Remove(int position)
        {
            if (IsIndexOutOfRange(position))
            {
                throw new IndexOutOfRangeException(IndexOutOfRangeMsg(position));
            }
            T itemToRemove = (T)arrayList[position];
            Array.Copy(arrayList, position + 1, arrayList, position, size - position - 1);
            arrayList[size - 1] = null;
            size--;
            return itemToRemove;
        }

        public T Remove(T item)
        {
            int itemPosition = IndexOf(item);
            //if (itemPosition < 0)
            //{
            //    return default(T);
            //}
            return Remove(itemPosition);
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public int Size()
        {
            return size;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public Iterator<T> Iterator()
        {
            object[] arrayListCopy = GrowArrayList(arrayList.Length);
            return new ArrayIterator<T>(arrayListCopy);
        }


        //== private methods ==
        private void AddLast(T item)
        {
            if (IsFull())
            {
                int newCapacity = DetermineNewCapacity();
                arrayList = GrowArrayList(newCapacity);
            }
            arrayList[size++] = item;
        }
        private bool IsFull()
        {
            return size == arrayList.Length;
        }

        private bool IsIndexInRange(int index)
        {
            return index >= 0 && index < arrayList.Length;
        }

        private bool IsIndexOutOfRange(int index)
        {
            if (size == 0)
            {
                return index < 0 || index > size;
            }

            return index < 0 || index >= size;
        }

        private string IndexOutOfRangeMsg(int index)
        {
            return "Index: " + index + ", Size: " + size;
        }

        private int IndexOf(T item)
        {
            if (item == null)
            {
                for (int i = 0; i < size; i++)
                {
                    if (arrayList[i] == null)
                    {
                        return i;
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                T current = (T)arrayList[i];
                if (current.Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        private int DetermineNewCapacity()
        {
            int arrayListCapacity = arrayList.Length;
            if (arrayListCapacity == 0)
            {
                return DefaultCapacity;// to default capacity
            }
            else if (arrayListCapacity < DefaultCapacity * 2)
            {
                return arrayListCapacity * 2; // doubled capacity
            }
            else
            {
                return arrayListCapacity + (arrayListCapacity / 2);// with 50 % increase of the capacity
            }
        }

        private object[] GrowArrayList(int grownListCapacity)
        {
            object[] grownArrayList = new object[grownListCapacity];
            Array.Copy(arrayList, 0, grownArrayList, 0, size);
            return grownArrayList;
        }

    }
}
