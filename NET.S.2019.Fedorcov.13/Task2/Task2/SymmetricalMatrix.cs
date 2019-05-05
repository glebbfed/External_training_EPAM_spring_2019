using System;

namespace Task2
{
    public class SymmetricalMatrix<T> : Matrix<T>
    {
        public SymmetricalMatrix(params T[] elements)
        {
            bool isFound = false;
            int numberOfDiagonalElements = 1;
            while (elements.Length - numberOfDiagonalElements > 0 && !isFound)
            {
                int elementsInMatrix = 2 * elements.Length - numberOfDiagonalElements;
                double squareMatrixSide = Math.Sqrt(elementsInMatrix);

                if (squareMatrixSide - Math.Floor(squareMatrixSide) == 0 && squareMatrixSide == numberOfDiagonalElements)
                {
                    Side = (int)squareMatrixSide;
                    Length = Side * Side;

                    matrix = new T[Side, Side];

                    int counter = 0;
                    for (int i = 0; i < Side; i++)
                    {
                        for (int j = i; j < Side; j++)
                        {
                            matrix[i, j] = elements[counter++];
                        }
                    }

                    counter = 0;
                    for (int i = 0; i < Side; i++)
                    {
                        for (int j = i; j < Side; j++)
                        {
                            matrix[j, i] = elements[counter++];
                        }
                    }

                    isFound = true;
                }

                numberOfDiagonalElements++;
            }

            if (!isFound)
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Override addition operator.
        /// </summary>
        public static SquareMatrix<T> operator +(SymmetricalMatrix<T> matrixA, Matrix<T> matrixB)
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
