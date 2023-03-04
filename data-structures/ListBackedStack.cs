using System;

namespace data_structures
{
    internal class ListBackedStack<T>
    {
        private LinkedList<T> stack;

        public ListBackedStack()
        {
            stack = new LinkedList<T>();
        }

        public void Push(T item)
        {
            stack.AddFirst(item);
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty stack exception!");
            }
            return stack.RemoveFirst();
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty stack exception!");
            }
            return stack.PeekFirst();
        }

        public bool IsEmpty()
        {
            return stack.IsEmpty();
        }

        public int Size()
        {
            return stack.Size();
        }

        public Iterator<T> Iterator()
        {
            return stack.Iterator();
        }

    }
}
