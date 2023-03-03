using System;
using System.Collections.Generic;

namespace dijkstra_shortest_path
{
    //AKA Priority Queue
    internal class BinaryHeap<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 10;
        private IComparer<T> comparer;
        private int size;
        private object[] heap;

        //== constructors ==
        public BinaryHeap() : this(DefaultCapacity)
        {
        }

        public BinaryHeap(int initialCapacity) : this(initialCapacity, null)
        {
        }

        public BinaryHeap(IComparer<T> comparer) : this(DefaultCapacity, comparer)
        {
        }

        public BinaryHeap(int initialCapacity, IComparer<T> comparer)
        {
            this.size = 0;
            if (initialCapacity < 0)
            {
                //we are not throwing an exception
                initialCapacity = DefaultCapacity;
            }
            this.heap = new object[initialCapacity];
            this.comparer = comparer;
        }


        //== public methods ==
        public void Add(T item)
        {
            if (IsFull())
            {
                GrowBackingHeapSize();
            }
            heap[size] = item;
            FixAbove(size);
            size++;
        }

        public T Remove()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty Priority Queue");
            }
            T item = (T)heap[0];
            heap[0] = heap[size - 1];
            heap[size - 1] = default(T);
            size--;
            FixBellow(0, size - 1);
            return item;
        }

        public T Remove(T item)
        {
            if (IsEmpty())
            {
                throw new Exception("Empty Priority Queue");
            }
            int position = IndexOf(item);
            if (position < 0)
            {
                throw new Exception("Element not found!");
            }
            T itemToRemove = Remove(position);
            return itemToRemove;
        }

        public T Poll()
        {
            if (IsEmpty())
            {
                return default(T);
            }
            T item = (T)heap[0];
            heap[0] = heap[size - 1];
            heap[size - 1] = null;
            size--;
            FixBellow(0, size - 1);
            return item;
        }

        public T Poll(T item)
        {
            if (IsEmpty())
            {
                return default(T);
            }
            int position = IndexOf(item);
            if (position < 0)
            {
                return default(T);
            }
            T itemToRemove = Remove(position);
            return itemToRemove;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty Priority Queue");
            }
            T item = (T)heap[0];
            return item;
        }

        public int Size()
        {
            return size;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }


        //== private methods ==
        private T Remove(int position)
        {
            //get the item from the heap
            T itemToRemove = (T)heap[position];

            // handle if it's the last element, no hepify needed
            if (position == size - 1)
            {
                heap[position] = default(T);
                size--;
                return itemToRemove;
            }

            //replace the item with the last entry in the heap
            heap[position] = heap[size - 1];
            heap[size - 1] = default(T);
            size--;

            T replacement = (T)heap[position];
            T parent = (T)heap[GetParent(position)];

            //check how the replacement meets the heap property
            bool isReplacementBeforeParent = comparer != null ? comparer.Compare(replacement, parent) > 1 : replacement.CompareTo(parent) > 1;

            if (position == 0 || isReplacementBeforeParent)
            {
                FixBellow(position, size - 1);
            }
            else
            {
                FixAbove(position);
            }

            return itemToRemove;
        }

        private int IndexOf(T item)
        {
            for (int i = 0; i < size; i++)
            {
                T current = (T)heap[i];
                if (current.Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        private bool IsFull()
        {
            return size == heap.Length;
        }

        //== Heapify bottom up ==
        private void FixAbove(int startIndex)
        {
            if (comparer != null)
            {
                FixAboveWithComparer(startIndex);
            }
            else
            {
                FixAboveComparable(startIndex);
            }
        }


        private void FixAboveComparable(int index)
        {
            T newValue = (T)heap[index];
            while (index > 0 && newValue.CompareTo((T)heap[GetParent(index)]) < 1)
            {
                heap[index] = heap[GetParent(index)];
                index = GetParent(index);
            }
            heap[index] = newValue;
        }

        private void FixAboveWithComparer(int index)
        {
            T newValue = (T)heap[index];
            while (index > 0 && comparer.Compare(newValue, (T)heap[GetParent(index)]) < 1)
            {
                heap[index] = heap[GetParent(index)];
                index = GetParent(index);
            }
            heap[index] = newValue;
        }

        //== Hepify top bottom ==
        private void FixBellow(int index, int lastHeapIndex)
        {
            if (comparer != null)
            {
                FixBellowWithComparer(index, lastHeapIndex);
            }
            else
            {
                FixBellowComparable(index, lastHeapIndex);
            }
        }

        private void FixBellowComparable(int index, int lastHeapIndex)
        {
            int childToSwap;
            while (index <= lastHeapIndex)
            {
                int leftChild = GetChild(index, true);
                int rightChild = GetChild(index, false);
                if (leftChild <= lastHeapIndex)
                {
                    if (rightChild > lastHeapIndex)
                    {
                        childToSwap = leftChild;
                    }
                    else
                    {
                        T left = (T)heap[leftChild];
                        T right = (T)heap[rightChild];
                        childToSwap = left.CompareTo(right) < 1 ? leftChild : rightChild;
                    }

                    T current = (T)heap[index];
                    T swapCandidate = (T)heap[childToSwap];
                    if (current.CompareTo(swapCandidate) > 0)
                    {
                        T temp = (T)heap[index];
                        heap[index] = heap[childToSwap];
                        heap[childToSwap] = temp;
                    }
                    else
                    {
                        break;
                    }
                    index = childToSwap;
                }
                else
                {
                    break;
                }
            }
        }

        private void FixBellowWithComparer(int index, int lastHeapIndex)
        {
            int childToSwap;
            while (index <= lastHeapIndex)
            {
                int leftChild = GetChild(index, true);
                int rightChild = GetChild(index, false);
                if (leftChild <= lastHeapIndex)
                {
                    if (rightChild > lastHeapIndex)
                    {
                        childToSwap = leftChild;
                    }
                    else
                    {
                        T left = (T)heap[leftChild];
                        T right = (T)heap[rightChild];
                        childToSwap = comparer.Compare(left, right) < 1 ? leftChild : rightChild;
                    }

                    T current = (T)heap[index];
                    T swapCandidate = (T)heap[childToSwap];
                    if (comparer.Compare(current, swapCandidate) > 0)
                    {
                        T temp = (T)heap[index];
                        heap[index] = heap[childToSwap];
                        heap[childToSwap] = temp;
                    }
                    else
                    {
                        break;
                    }
                    index = childToSwap;
                }
                else
                {
                    break;
                }
            }
        }

        private int GetParent(int index)
        {
            return (index - 1) / 2;
        }

        private int GetChild(int index, bool left)
        {
            return (2 * index) + (left ? 1 : 2);
        }

        private void GrowBackingHeapSize()
        {
            int newCapacity;
            int heapCapacity = heap.Length;

            if (heapCapacity == 0)
            {
                newCapacity = DefaultCapacity;// to default capacity
            }
            else if (heapCapacity < DefaultCapacity * 2)
            {
                newCapacity = heapCapacity * 2; // doubled capacity
            }
            else
            {
                newCapacity = heapCapacity + (heapCapacity / 2);// with 50 % increase of the capacity
            }
            GrowBackingHeapSize(newCapacity);
        }

        private void GrowBackingHeapSize(int newCapacity)
        {
            object[] heapCopy = new object[newCapacity];
            Array.Copy(heap, 0, heapCopy, 0, size);
            heap = heapCopy;
        }


    }//== end of class ==
}
