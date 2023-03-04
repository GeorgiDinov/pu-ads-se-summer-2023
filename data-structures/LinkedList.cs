using System;

namespace data_structures
{
    internal class LinkedList<T>
    {

        private Node<T> head;
        private Node<T> tail;
        private int size;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }


        //== public methods ==
        public void AddFirst(T item)
        {
            if (head == null)
            {
                head = new Node<T>(item);
                tail = head;
            }
            else
            {
                Node<T> node = new Node<T>(item);
                head.Previous = node;
                node.Next = head;
                head = node;
            }
            size++;
        }

        public void AddLast(T item)
        {
            if (tail == null)
            {
                tail = new Node<T>(item);
                head = tail;
            }
            else
            {
                Node<T> node = new Node<T>(item);
                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }
            size++;
        }

        public T RemoveFirst()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty list exception!");
            }
            Node<T> nodeToRemove = head;
            head = head.Next;
            nodeToRemove.Next = default;
            if (head != null)
            {
                head.Previous = default;
            }
            T item = nodeToRemove.Item;
            size--;
            return item;
        }

        public T RemoveLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty list exception!");
            }
            Node<T> nodeToRemove = tail;
            tail = tail.Previous;
            nodeToRemove.Previous = default;
            if (tail != null)
            {
                tail.Next = default;
            }
            T item = nodeToRemove.Item;
            size--;
            return item;
        }

        public T PeekFirst()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty list exception!");
            }
            return head.Item;
        }

        public T PeekLast()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty list exception!");
            }
            return tail.Item;
        }

        /// <summary>
        /// Insertion done at the end of the list passing trough all elements
        /// </summary>
        /// <param name="item">Stored value in the list</param>
        public void Add(T item)
        {
            if (head == null)
            {
                head = new Node<T>(item);
                tail = head;
            }
            else
            {
                Node<T> node = new Node<T>(item);
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = node;
                node.Previous = current;
                tail = node;
            }
            size++;
        }


        public bool IsEmpty()
        {
            return size == 0;
        }

        public int Size()
        {
            return size;
        }

        public Iterator<T> Iterator()
        {
            return new ListIterator<T>(head);
        }


        private class Node<T> : IterableNode<T>
        {
            private T item;
            public T Item { get => item; set => item = value; }

            private Node<T> previous;
            public Node<T> Previous { get => previous; set => previous = value; }

            private Node<T> next;
            public Node<T> Next { get => next; set => next = value; }

            public Node(T item)
            {
                this.Item = item;
                this.Previous = null;
                this.Next = null;
            }


            public T Value()
            {
                return item;
            }

            IterableNode<T> IterableNode<T>.Previous()
            {
                return previous;
            }

            IterableNode<T> IterableNode<T>.Next()
            {
                return next;
            }

        }
    }
}
