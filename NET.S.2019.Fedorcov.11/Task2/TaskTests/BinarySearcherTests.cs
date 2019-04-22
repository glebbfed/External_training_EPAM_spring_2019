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
            int[] array = { 0, 19, 3, 1, 5 };

            Comparison<int> comparison = (x, y) => x.CompareTo(y);

            Assert.AreEqual(1, BinarySearcher.BinarySearch(array, 19, Comparer<int>.Create(comparison)));
        }
        [TestCase]
        public void BinarySearchTest2()
        {
            int[] array = { 19, 209, 1082, 148, 8 };

            Comparison<int> comparison = (x, y) => x.CompareTo(y);

            Assert.AreEqual(3, BinarySearcher.BinarySearch(array, 148, Comparer<int>.Create(comparison)));
        }
        [TestCase]
        public void BinarySearchTest3()
        {
            char[] array = { 'a', 'h', '3', '9', 'ð' };

            Comparison<char> comparison = (x, y) => x.CompareTo(y);

            Assert.AreEqual(1, BinarySearcher.BinarySearch(array, 'h', Comparer<char>.Create(comparison)));
        }
        [TestCase]
        public void BinarySearchTest4()
        {
            string[] array = { "asda", "dasdasd", "gleb", "0", " " };

            Comparison<string> comparison = (x, y) => x.CompareTo(y);

            Assert.AreEqual(2, BinarySearcher.BinarySearch(array, "gleb", Comparer<string>.Create(comparison)));
        }
    }
}