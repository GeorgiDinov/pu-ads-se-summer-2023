using System;

namespace data_structures
{
    internal class Queue<T>
    {

        private const int DefaultCapacity = 10;
        private int front;
        private int back;
        private object[] queue;

        //== constructors ==
        public Queue() : this(DefaultCapacity)
        {
        }

        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                capacity = DefaultCapacity;
            }
            this.front = 0;
            this.back = 0;
            this.queue = new object[capacity];
        }


        //== public methods ==
        public void Add(T item)
        {
            if (IsFull())
            {
                int numberOfItems = Size();
                int newCapacity = DetermineNewCapacity();
                queue = GetUnwrappedCopy(newCapacity);

                front = 0;
                back = numberOfItems;
            }
            queue[back] = item;
            if (back < queue.Length - 1)
            {
                back++;
            }
            else
            {
                back = 0;//wrap
            }
        }

        public T Remove()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty queue exception!");
            }
            T item = (T)queue[front];
            queue[front] = default(T);
            front++;
            if (IsEmpty())
            {
                front = 0;
                back = 0;
            }
            if (front == queue.Length)
            {
                front = 0;// wrap
            }
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty queue exception!");
            }
            return (T)queue[front];
        }

        public int Size()
        {
            return IsNotWrapped() ? (back - front) : back - front + queue.Length;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public Iterator<T> Iterator()
        {
            object[] unrwappedQueue = GetUnwrappedCopy(queue.Length);
            return new ArrayIterator<T>(unrwappedQueue);
        }


        //== private methods ==
        private bool IsNotWrapped()
        {
            return front <= back;
        }

        private bool IsFull()
        {
            return Size() == queue.Length - 1;
        }

        private object[] GetUnwrappedCopy(int unrappedCopyCapacity)
        {
            object[] copy = new object[unrappedCopyCapacity];
            if (IsNotWrapped())
            {
                Array.Copy(queue, front, copy, 0, Size());
            }
            else
            {
                Array.Copy(queue, front, copy, 0, queue.Length - front);
                Array.Copy(queue, 0, copy, queue.Length - front, back);
            }

            return copy;
        }

        private int DetermineNewCapacity()
        {
            int queueCapacity = queue.Length;
            if (queueCapacity == 0)
            {
                return DefaultCapacity;// to default capacity
            }
            else if (queueCapacity < DefaultCapacity * 2)
            {
                return queueCapacity * 2; // doubled capacity
            }
            else
            {
                return queueCapacity + (queueCapacity / 2);// with 50 % increase of the capacity
            }
        }

        //Uncomment to visualize the wrapping and growing process
        //public void PrintInternalState()
        //{
        //    string result = "";
        //    for (int i = 0; i < queue.Length; i++)
        //    {
        //        result += (i < queue.Length - 1) ? queue[i] + ", " : queue[i] + "";
        //    }
        //    Console.WriteLine("Queue Array = [" + result + "]");
        //}

    }
}
