using System;

namespace data_structures
{
    internal class Stack<T>
    {
        private const int DefaultCapacity = 10;
        private int size;
        private object[] stack;

        //== constructors ==
        public Stack() : this(DefaultCapacity)
        {
        }

        public Stack(int capacity)
        {
            this.size = 0;
            if (capacity < 0)
            {
                capacity = DefaultCapacity;
            }
            this.stack = new object[capacity];
        }

        //== public methods ==
        public void Push(T item)
        {
            if (IsFull())
            {
                GrowBackingStackSize();
            }
            stack[size++] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty stack exception!");
            }
            T item = (T)stack[size - 1];
            stack[size - 1] = default(T);
            size--;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty stack exception!");
            }
            return (T)stack[size - 1];
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        public Iterator<T> Iterator()
        {
            object[] reversedStack = GetReversedCopyOfTheStack();
            return new ArrayIterator<T>(reversedStack);
        }


        //== private methods ==
        private object[] GetReversedCopyOfTheStack()
        {
            object[] stackCopy = new object[size];
            for (int copyIndex = 0, stackIndex = size - 1; stackIndex >= 0; copyIndex++, stackIndex--)
            {
                stackCopy[copyIndex] = stack[stackIndex];
            }
            return stackCopy;
        }

        private bool IsFull()
        {
            return size == stack.Length;
        }

        private void GrowBackingStackSize()
        {
            int newCapacity;
            int stackCapacity = stack.Length;

            if (stackCapacity == 0)
            {
                newCapacity = DefaultCapacity;// to default capacity
            }
            else if (stackCapacity < DefaultCapacity * 2)
            {
                newCapacity = stackCapacity * 2; // doubled capacity
            }
            else
            {
                newCapacity = stackCapacity + (stackCapacity / 2);// with 50 % increase of the capacity
            }
            GrowBackingStackSize(newCapacity);
        }

        private void GrowBackingStackSize(int newCapacity)
        {
            object[] stackCopy = new object[newCapacity];
            Array.Copy(stack, 0, stackCopy, 0, size);
            stack = stackCopy;
        }

    }
}
