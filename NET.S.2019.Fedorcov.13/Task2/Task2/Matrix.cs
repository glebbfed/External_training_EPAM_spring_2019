using System;

namespace Task2
{
    public abstract class Matrix<T>
    {
        protected T[,] matrix;

        public delegate void MatrixHandler();

        public event MatrixHandler OnElementWasChanged;

        public int Side
        {
            get;
            protected set;
        }

        public int Length
        {
            get;
            protected set;
        }

        public T this[int i, int j]
        {
            get
            {
                return matrix[i, j];
            }
            set
            {
                OnElementWasChanged += ChangingEvent;
                matrix[i, j] = value;
            }
        }

        public T[,] ReturnMatrix
        {
            get { return matrix; }
            protected set { }
        }

        public void ChangedElement()
        {
            OnElementWasChanged?.Invoke();
        }

        protected void ChangingEvent()
        {
            Console.WriteLine("Element was changed!");
        }
    }
}
