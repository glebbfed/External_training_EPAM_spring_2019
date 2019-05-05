using System;

namespace Task2
{
    public class SquareMatrix<T>: Matrix<T>
    {
        public SquareMatrix(params T[] elements)
        {
            double squareMatrixSide = Math.Sqrt(elements.Length);

            if (squareMatrixSide - Math.Floor(squareMatrixSide) != 0)
            {
                throw new ArgumentException();
            }
            else
            {
                Side = (int)squareMatrixSide;
                Length = elements.Length;

                matrix = new T[Side, Side];

                for (int i = 0; i < Side; i++)
                {
                    for (int j = 0; j < Side; j++)
                    {
                        matrix[i, j] = elements[i * Side + j];
                    }
                }
            }
        }

        /// <summary>
        /// Override addition operator.
        /// </summary>
        public static SquareMatrix<T> operator +(SquareMatrix<T> matrixA, Matrix<T> matrixB)
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
