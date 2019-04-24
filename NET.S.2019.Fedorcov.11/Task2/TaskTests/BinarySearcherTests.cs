using System.Collections.Generic;
using NUnit.Framework;
using Task2;
using System;

namespace Tests
{
    public class BynarySearcherTestsTests
    {

        [TestCase]
        public void BinarySearchTest1()
        {
            int[] array = { 19, 209, 1082, 148, 8 };

            Comparison<int> comparison = (x, y) => x.CompareTo(y);

            Assert.AreEqual(2, BinarySearcher.BinarySearch(array, 1082, Comparer<int>.Create(comparison)));
        }
        [TestCase]
        public void BinarySearchTest2()
        {
            string[] array = { "asda", "dasdasd", "gleb", "0", " " };

            Comparison<string> comparison = (x, y) => x.CompareTo(y);

            Assert.AreEqual(2, BinarySearcher.BinarySearch(array, "gleb", Comparer<string>.Create(comparison)));
        }
    }
}