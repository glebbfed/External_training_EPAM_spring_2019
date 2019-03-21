using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortClass;
using System.Linq;

namespace SortingTest
{
    [TestClass]
    public class SortingTests
    {
        [TestMethod]
        public void MergeSortTest()
        {
            int[] arr1 = new int[] { 6, 2, 9, 1, 3, 2 };
            int[] arr2 = new int[] { 1, 2, 2, 3, 6, 9 };
            int[] arr3 = Sorting.MergeSort(arr1);
            Assert.AreEqual(true, arr2.SequenceEqual(arr3));
        }

        [TestMethod]
        public void QuickSortTest()
        {
            int[] arr1 = new int[] { 6, 2, 9, 1, 3, 2 };
            int[] arr2 = new int[] { 1, 2, 2, 3, 6, 9 };
            int[] arr3 = Sorting.QuickSort(arr1, 0, arr1.Length - 1);
            Assert.AreEqual(true, arr2.SequenceEqual(arr3));
        }
    }
}
