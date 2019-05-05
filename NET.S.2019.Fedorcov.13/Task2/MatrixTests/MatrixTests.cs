using NUnit.Framework;
using Task2;
namespace Tests
{
    public class MatrixTests
    {
        [TestCase]
        public void AddTest1()
        {
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(1, 2, 3, 4);
            SymmetricalMatrix<int> symmetricMatrix = new SymmetricalMatrix<int>(1, 2, 3);

            int[,] expected = new int[,]
            {
                { 2, 4 },
                { 5, 7 }
            };
            int[,] actual = (squareMatrix + symmetricMatrix).ReturnMatrix;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void AddTest2()
        {
            SquareMatrix<int> squareMatrix1 = new SquareMatrix<int>(1, 2, 3, 4);
            SquareMatrix<int> squareMatrix2 = new SquareMatrix<int>(1, 2, 3, 4);

            int[,] expected = new int[,]
            {
                { 2, 4 },
                { 6, 8 }
            };
            int[,] actual = (squareMatrix1 + squareMatrix2).ReturnMatrix;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void AddTest3()
        {
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(1, 2);
            SymmetricalMatrix<int> symmetricMatrix = new SymmetricalMatrix<int>(1, 2, 3);

            int[,] expected = new int[,]
            {
                { 2, 2 },
                { 2, 5 }
            };
            int[,] actual = (diagonalMatrix + symmetricMatrix).ReturnMatrix;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void AddTest4()
        {
            DiagonalMatrix<int> diagonalMatrix1 = new DiagonalMatrix<int>(1, 2);
            DiagonalMatrix<int> diagonalMatrix2 = new DiagonalMatrix<int>(1, 2);

            int[,] expected = new int[,]
            {
                { 2, 0 },
                { 0, 4 }
            };
            int[,] actual = (diagonalMatrix1 + diagonalMatrix2).ReturnMatrix;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void AddTest5()
        {
            SymmetricalMatrix<int> symmetricMatrix = new SymmetricalMatrix<int>(1, 2, 3, 4, 5, 6);
            SquareMatrix<int> squareMatrix = new SquareMatrix<int>(1, 2, 3, 4, 5, 6, 7, 8, 9);
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(1, 2, 3);

            int[,] expected = new int[,]
            {
                { 3, 4, 6 },
                { 6, 11, 11 },
                { 10, 13, 18 }
            };
            int[,] actual = (symmetricMatrix + squareMatrix + diagonalMatrix).ReturnMatrix;

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void AddTest6()
        {
            SymmetricalMatrix<string> symmetricMatrix = new SymmetricalMatrix<string>("1", "2", "3", "4", "5", "6");
            SquareMatrix<string> squareMatrix = new SquareMatrix<string>("1", "2", "3", "4", "5", "6", "7", "8", "9");
            DiagonalMatrix<string> diagonalMatrix = new DiagonalMatrix<string>("1", "2", "3");

            string[,] expected = new string[,]
            {
                { "111", "22", "33" },
                { "24", "452", "56" },
                { "37", "58", "693" }
            };
            string[,] actual = (symmetricMatrix + squareMatrix + diagonalMatrix).ReturnMatrix;

        }
    }
}