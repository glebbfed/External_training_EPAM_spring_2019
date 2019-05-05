using System.Collections.Generic;

namespace Task3
{
    public class BinarySearchTree<T>
    {
        public BinarySearchTree(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public T Data
        {
            get;
            private set;
        }

        public BinarySearchTree<T> Left
        {
            get;
            private set;
        }

        public BinarySearchTree<T> Right
        {
            get;
            private set;
        }

        public void Insert(T data, IComparer<T> comparer)
        {
            if (comparer.Compare(Data, data) > 0)
            {
                if (Left == null)
                {
                    Left = new BinarySearchTree<T>(data);
                }
                else
                {
                    Left.Insert(data, comparer);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new BinarySearchTree<T>(data);
                }
                else
                {
                    Right.Insert(data, comparer);
                }
            }
        }

        public int Compare(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return 1;
            }
            else if (a.Length < b.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public int Compare(int a, int b)
        {
            if (a > b)
            {
                return 1;
            }
            else if (a < b)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<T> PreOrderBypass()
        {
            foreach (T data in PreOrder(this))
            {
                yield return data;
            }
        }

        public IEnumerable<T> InOrderBypass()
        {
            foreach (T data in InOrder(this))
            {
                yield return data;
            }
        }

        public IEnumerable<T> PostOrderBypass()
        {
            foreach (T data in PostOrder(this))
            {
                yield return data;
            }
        }

        private IEnumerable<T> PreOrder(BinarySearchTree<T> node)
        {
            if (node != null)
            {
                yield return node.Data;

                foreach (T data in PreOrder(node.Left))
                {
                    yield return data;
                }

                foreach (T data in PreOrder(node.Right))
                {
                    yield return data;
                }
            }
        }

        private IEnumerable<T> InOrder(BinarySearchTree<T> node)
        {
            if (node != null)
            {
                foreach (T data in InOrder(node.Left))
                {
                    yield return data;
                }

                yield return node.Data;

                foreach (T data in InOrder(node.Right))
                {
                    yield return data;
                }
            }
        }

        private IEnumerable<T> PostOrder(BinarySearchTree<T> node)
        {
            if (node != null)
            {
                foreach (T data in PostOrder(node.Left))
                {
                    yield return data;
                }

                foreach (T data in PostOrder(node.Right))
                {
                    yield return data;
                }

                yield return node.Data;
            }
        }


    }
}
