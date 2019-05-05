
namespace Task2
{
    public class DiagonalMatrix<T>: Matrix<T>
    {
        public DiagonalMatrix(params T[] elements)
        {
            Side = elements.Length;
            Length = elements.Length * elements.Length;

            matrix = new T[elements.Length, elements.Length];

            int counter = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = 0; j < elements.Length; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = elements[counter++];
                    }
                    else
                    {
                        matrix[i, j] = default(T);
                    }
                }
            }
        }

        /// <summary>
        /// Override addition operator.
        /// </summary>
        public static SquareMatrix<T> operator +(DiagonalMatrix<T> matrixA, Matrix<T> matrixB)
        {
            T[] newElements = new T[matrixA.Length];

            int counter = 0;
            for (int i = 0; i < matrixA.Side; i++)
            {
                for (int j = 0; j < matrixA.Side; j++)
                {
                    newElements[counter] = (dynamic)matrixA[i, j] + (dynamic)matrixB[i, j];
                    counter++;
                }
            }

            return new SquareMatrix<T>(newElements);
        }
    }
}
