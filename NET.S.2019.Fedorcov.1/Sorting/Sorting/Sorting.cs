using System;


namespace SortClass
{
    public static class Sorting
    {
        /// <summary>
        /// This method implements a quick sort algorithm.
        /// </summary>
        /// <param name="array">This is a sortable array.</param>
        /// <param name="first">Left border of the sorted part of the array.</param>
        /// <param name="last">Right border of the sorted part of the array.</param>
        /// <returns>Returns a sorted array.</returns>
        public static int[] QuickSort(int[] array, int first, int last)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0 || first < 0 || last < 0)
                throw new ArgumentException();
            int mid = array[(last - first) / 2 + first];
            int temp;
            int i = first;
            int j = last;
            while (i <= j)
            {
                while (array[i] < mid && i <= last)
                    i++;
                while (array[j] > mid && j >= first)
                    j--;
                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
                if (j > first)
                    QuickSort(array, first, j);
                if (i < last)
                    QuickSort(array, i, last);
            }
            return array;
        }
        /// <summary>
        /// This method implements a merge sort algorithm.
        /// </summary>
        /// <param name="array">This is a sortable array.</param>
        /// <returns>Returns a sorted array.</returns>
        public static int[] MergeSort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException();
            if (array.Length == 1)
                return array;
            int mid = array.Length / 2;
            int[] arr1 = new int[mid];
            int i;
            for (i = 0; i < arr1.Length; i++)
                arr1[i] = array[i];
            int[] arr2 = new int[array.Length - mid];
            for (int j = 0; j < arr2.Length; j++)
            {
                arr2[j] = array[i];
                i++;
            }
            return Merge(MergeSort(arr1), MergeSort(arr2));


        }
        /// <summary>
        /// This is a helper method for the MergeSort.
        /// </summary>
        /// <param name="arr1">The left part of the sorted array.</param>
        /// <param name="arr2">The right part of the sorted array.</param>
        /// <returns>Returns the sorted part of the array.</returns>
        private static int[] Merge(int[] arr1, int[] arr2)
        {
            int index1 = 0;
            int index2 = 0;
            int[] merged = new int[arr1.Length + arr2.Length];
            for (int i = 0; i < merged.Length; i++)
            {
                if (index1 < arr1.Length && index2 < arr2.Length)
                {
                    if (arr1[index1] > arr2[index2] && index2 < arr2.Length)
                    {
                        merged[i] = arr2[index2];
                        index2++;

                    }
                    else
                    {
                        merged[i] = arr1[index1];
                        index1++;

                    }
                }
                else
                {
                    if (index2 < arr2.Length)
                    {
                        merged[i] = arr2[index2];
                        index2++;

                    }
                    else
                    {
                        merged[i] = arr1[index1];
                        index1++;
                    }
                }
            }
            return merged;


        }
    }
}
