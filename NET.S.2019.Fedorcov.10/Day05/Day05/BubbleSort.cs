using System;
using System.Collections.Generic;


namespace Day05
{
    public static class BubbleSorting
    {
        /// <summary>
        /// Method for searching max element
        /// </summary>
        /// <param name="array">Test array</param>
        /// <returns></returns>
        private static int Max(int[] array)
        {
            int max = int.MinValue;
            foreach (int item in array)
            {
                if (item > max)
                {
                    max = item;
                }
            }
            return max;
        }

        /// <summary>
        /// Method for summ
        /// </summary>
        /// <param name="array">Test array</param>
        /// <returns></returns>
        private static int Sum(int[] array)
        {
            int sum = 0;
            foreach (int element in array)
            {
                sum += element;
            }
            return sum;

        }
        /// <summary>
        /// Method for min
        /// </summary>
        /// <param name="array">Test array</param>
        /// <returns></returns>
        private static int Min(int[] array)
        {
            int min = int.MaxValue;
            foreach (int item in array)
            {
                if (item < min)
                {
                    min = item;
                }
            }
            return min;
        }

        /// <summary>
        /// Swap method
        /// </summary>
        /// <param name="arr1">First row</param>
        /// <param name="arr2">Second row</param>
        private static void Swap(ref int[] arr1, ref int[] arr2)
        {
            int[] buff = arr1;
            arr1 = arr2;
            arr2 = buff;
        }
        /// <summary>
        /// Method that sort rows of array by sum
        /// </summary>
        /// <param name="array">Sorted array</param>
        public static void SortBySum(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (Sum(array[i]) < Sum(array[j]))
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }
        /// <summary>
        /// Method that sort rows of array by max element.
        /// </summary>
        /// <param name="array">Sorted array</param>
        public static void SortByMax(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (Max(array[i]) < Max(array[j]))
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }
        /// <summary>
        /// Method that sort rows of array by min element.
        /// </summary>
        /// <param name="array">Sorted array</param>
        public static void SortByMin(int[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (Min(array[i]) < Min(array[j]))
                    {
                        Swap(ref array[i], ref array[j]);
                    }
                }
            }
        }

        //Comparer for sort by min.
        public class MinSort: IComparer<int[]>
        {
            public int Compare(int[] part1, int[] part2)
            {
                if (Min(part1) > Min(part2))
                {
                    return 1;
                }
                else
                if (Min(part1) < Min(part2))
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        //Comparer for sort by max.
        public class MaxSort : IComparer<int[]>
        {
            public int Compare(int[] part1, int[] part2)
            {
                if (Max(part1) > Max(part2))
                {
                    return 1;
                }
                else
                if (Max(part1) < Max(part2))
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        ////Comparer for sort by sum.
        public class SumSort : IComparer<int[]>
        {
            public int Compare(int[] part1, int[] part2)
            {
                if (Sum(part1) > Sum(part2))
                {
                    return 1;
                }
                else
                if (Sum(part1) < Sum(part2))
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public static int[][] SortWithLogic(int[][] array, IComparer<int[]> logic)
        {
            if (array == null || logic == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                throw new ArgumentException();
            Array.Sort(array, logic);
            return array;
        }

    }
}
