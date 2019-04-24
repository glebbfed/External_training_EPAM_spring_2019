using System;
using System.Collections.Generic;

namespace Task2
{
    public static class BinarySearcher
    {
        /// <summary>
        /// Method implements a generalized binary sorting algorithm.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"> Type of array elements. </param>
        /// <param name="item">Required item</param>
        /// <returns>Index of the item found.</returns>
        public static int BinarySearch<T>(T[] array, T item, IComparer<T> comparer)
        {
            if (array == null || comparer == null)
                throw new ArgumentNullException(nameof(array));
            if (array.Length == 0)
                throw new ArgumentException();

            int first = 0;
            int last = array.Length - 1;
            while (first <= last)
            {
                int mid = first + (last - first) / 2;
                if (comparer.Compare(item, array[mid]) == 0)
                    return mid;
                if (comparer.Compare(item, array[mid]) > 0)
                    last = mid - 1;
                else
                    first = mid + 1;
            }
                return -1;
        }
    }
}
