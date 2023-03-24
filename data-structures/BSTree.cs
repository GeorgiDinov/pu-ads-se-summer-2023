using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures
{
    internal class BSTree<T> where T : IComparable<T>
    {

        private BSTnode<T> root;


        public BSTree()
        {
            this.root = null;
        }

        public void Insert(T item)
        {
            if (this.root == null)
            {
                root = new BSTnode<T>(item);
            }
            else
            {
                root.Insert(item);
            }
        }

        public T Get(T item)
        {
            if (root != null)
            {
                BSTnode<T> node = root.Get(item);
                return node != null ? node.Data : default;
            }
            return default;
        }

        public void Delete(T item)
        {
            root = Delete(root, item);
        }

        private BSTnode<T> Delete(BSTnode<T> subtreeRoot, T item)
        {
            if (subtreeRoot == null)
            {
                return subtreeRoot;
            }

            if (subtreeRoot.IsBigger(item))
            {
                subtreeRoot.LeftChild = Delete(subtreeRoot.LeftChild, item);
            }
            else if (subtreeRoot.IsSmaller(item))
            {
                subtreeRoot.RightChild = Delete(subtreeRoot.RightChild, item);
            }
            else
            {
                if (subtreeRoot.LeftChild == null)
                {
                    return subtreeRoot.RightChild;
                }
                else if (subtreeRoot.RightChild == null)
                {
                    return subtreeRoot.LeftChild;
                }

                subtreeRoot.Data = subtreeRoot.RightChild.Min();
                subtreeRoot.RightChild = Delete(subtreeRoot.RightChild, subtreeRoot.Data);
            }
            return subtreeRoot;
        }

        public T Min()
        {
            return root != null ? root.Min() : default;
        }

        public T Max()
        {
            return root != null ? root.Max() : default;
        }

        public void TraverseInOrder()
        {
            if (root != null)
            {
                Console.Write("In order: ");
                root.TraverseInOrder();
                Console.WriteLine();
            }
        }

        public void TraversePreOrder()
        {
            if (root != null)
            {
                Console.Write("Pre order: ");
                root.TraversePreOrder();
                Console.WriteLine();
            }
        }

        public void TraversePostOrder()
        {
            if (root != null)
            {
                Console.Write("Post order: ");
                root.TraversePostOrder();
                Console.WriteLine();
            }
        }



        //Inner class start
        private class BSTnode<T> where T : IComparable<T>
        {
            private T data;

            public T Data
            {
                get { return data; }
                set { data = value; }
            }

            private BSTnode<T> leftChild;

            public BSTnode<T> LeftChild
            {
                get { return leftChild; }
                set { leftChild = value; }
            }

            private BSTnode<T> rightChild;

            public BSTnode<T> RightChild
            {
                get { return rightChild; }
                set { rightChild = value; }
            }


            public BSTnode(T data)
            {
                this.data = data;
                this.leftChild = null;
                this.rightChild = null;
            }

            public void Insert(T item)
            {
                if (IsEqual(item))
                {
                    // in this implementation we do not support duplicates
                    return;
                }

                if (IsBigger(item))
                {
                    if (leftChild == null)
                    {
                        leftChild = new BSTnode<T>(item);
                    }
                    else
                    {
                        leftChild.Insert(item);
                    }
                }
                else
                {
                    if (rightChild == null)
                    {
                        rightChild = new BSTnode<T>(item);
                    }
                    else
                    {
                        rightChild.Insert(item);
                    }
                }
            }

            public BSTnode<T> Get(T item)
            {
                if (IsEqual(item))
                {
                    return this;
                }

                if (IsBigger(item))
                {
                    if (leftChild != null)
                    {
                        return leftChild.Get(item);
                    }
                }
                else
                {
                    if (rightChild != null)
                    {
                        return rightChild.Get(item);
                    }
                }
                return null;
            }

            public T Min()
            {
                return leftChild != null ? leftChild.Min() : data;
            }

            public T Max()
            {
                return leftChild != null ? rightChild.Max() : data;
            }

            public void TraverseInOrder()
            {
                if (leftChild != null)
                {
                    leftChild.TraverseInOrder();
                }
                Console.Write(this);
                if (rightChild != null)
                {
                    rightChild.TraverseInOrder();
                }
            }

            public void TraversePreOrder()
            {
                Console.Write(this);
                if (leftChild != null)
                {
                    leftChild.TraversePreOrder();
                }
                if (rightChild != null)
                {
                    rightChild.TraversePreOrder();
                }
            }

            public void TraversePostOrder()
            {
                if (leftChild != null)
                {
                    leftChild.TraversePostOrder();
                }
                if (rightChild != null)
                {
                    rightChild.TraversePostOrder();
                }
                Console.Write(this);
            }


            public override string ToString()
            {
                return "(" + data + ")";
            }


            public bool IsSmaller(T item)
            {
                return this.data.CompareTo(item) < 0;
            }


            public bool IsBigger(T item)
            {
                return this.data.CompareTo(item) > 0;
            }

            public bool IsEqual(T item)
            {
                return this.data.CompareTo(item) == 0;
            }

        }// end of inner class 
    }
}
