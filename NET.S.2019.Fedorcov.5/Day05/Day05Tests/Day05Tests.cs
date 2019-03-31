using NUnit.Framework;
using Day05;
using System;
namespace Tests
{
    public class BubleSortTests
    {
        [TestCase]
        public void BubbleSortBySumTest()
        {
            int[][] actual = new int[][]
            {
                new int[] {0,2,4,6, 29, 105},
                new int[] {1,3,5,7,9,10323,1,2,3},
                new int[] {11,22}
            };

            int[][] expected = new int[][]
            {
                new int[] {11,22},
                new int[] {0,2,4,6, 29, 105},
                new int[] {1,3,5,7,9,10323,1,2,3}
            };

            BubbleSorting.SortBySum(actual);

            Assert.AreEqual(expected, actual);
        }
        [TestCase]
        public void BubbleSortByMaxTest()
        {
            int[][] actual = new int[][]
            {
                new int[] {0,2,4,6, 29, 105},
                new int[] {1,3,5,7,9,10323,1,2,3},
                new int[] {11,22}
            };

            int[][] expected = new int[][]
            {
                new int[] {11,22},
                new int[] {0,2,4,6, 29, 105},
                new int[] {1,3,5,7,9,10323,1,2,3}
            };

            BubbleSorting.SortByMax(actual);

            Assert.AreEqual(expected, actual);
        }
        [TestCase]
        public void BubbleSortByMinTest()
        {
            int[][] actual = new int[][]
            {
                new int[] {11,22},
                new int[] {1,3,5,7,9,10323,1,2,3},
                new int[] {0,2,4,6, 29, 105}
            };

            int[][] expected = new int[][]
            {
                new int[] {0,2,4,6, 29, 105},
                new int[] {1,3,5,7,9,10323,1,2,3},
                new int[] {11,22}
            };

            BubbleSorting.SortByMin(actual);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BubbleSortByMinNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorting.SortByMin(null));
        }

        [TestCase]
        public void BubbleSortByMaxNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorting.SortByMax(null));
        }

        [TestCase]
        public void BubbleSortBySumNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => BubbleSorting.SortBySum(null));
        }
    }
    public class PolynomailTests
    {
        [TestCase]
        public void PolynomialCalculateSumTest1()
        {
            Polynomial pol = new Polynomial(3, 4, 5);
            double expected = 19;
            double actual = pol.CalculateSum();

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void PolynomialCalculateSumTest2()
        {
            Polynomial pol = new Polynomial(3, 4, 5, 2);
            double expected = 37;
            double actual = pol.CalculateSum();

            Assert.AreEqual(expected, actual);
        }
        [TestCase]
        public void PolynomialToStringTest()
        {
            Polynomial pol = new Polynomial(3, 4, 5, 2);
            string expected = "4*3^0+5*3^1+2*3^2";
            string actual = pol.ToString();

            Assert.AreEqual(expected, actual);
        }
        [TestCase]
        public void PolynomialSumTest()
        {
            Polynomial pol1 = new Polynomial(3, 4, 5, 2);
            Polynomial pol2 = new Polynomial(3, 4, 5, 2);
            Polynomial expected = pol1 + pol2;
            Polynomial actual = new Polynomial(3, 8, 10, 4);

            Assert.AreEqual(true, expected==actual);
        }
        [TestCase]
        public void PolynomialSubtrTest()
        {
            Polynomial pol1 = new Polynomial(3, 4, 5, 2);
            Polynomial pol2 = new Polynomial(3, 4, 5, 2);
            Polynomial expected = pol1 - pol2;
            Polynomial actual = new Polynomial(3, 0, 0, 0);

            Assert.AreEqual(true, expected == actual);
        }
        [TestCase]
        public void PolynomialMultTest()
        {
            Polynomial pol1 = new Polynomial(3, 4, 5);
            Polynomial pol2 = new Polynomial(3, 4, 5);
            Polynomial expected = pol1 * pol2;
            Polynomial actual = new Polynomial(3, 16, 40, 25);

            Assert.AreEqual(true, expected == actual);
        }
    }
}