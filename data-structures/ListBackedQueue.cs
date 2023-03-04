using System;

namespace data_structures
{
    internal class ListBackedQueue<T>
    {

        private LinkedList<T> queue;

        //== constructors ==
        public ListBackedQueue()
        {
            queue = new LinkedList<T>();
        }


        //== public methods ==
        public void Add(T item)
        {
            queue.AddLast(item);
        }

        public T Remove()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty queue exception!");
            }
            return queue.RemoveFirst();
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty queue exception!");
            }
            return queue.PeekFirst();
        }

        public bool IsEmpty()
        {
            return queue.IsEmpty();
        }

        public int Size()
        {
            return queue.Size();
        }

        public Iterator<T> Iterator()
        {
            return queue.Iterator();
        }

    }
}
