using System;
using SortClass;
namespace Day01
{
    
    class Program
    {
       
        static void Main(string[] args)
        {
            int[] array = new int[] { 19, 5, 23, 13, 109, 1, 7, 2, 5 };
            array = Sorting.QuickSort(array, 0, array.Length - 1);
            foreach (int i in array)
                Console.WriteLine(i);
            int[] array2 = new int[] { 19, 5, 23, 13, 109, 1, 7, 2, 5 };
            array2 = Sorting.MergeSort(array2);
            foreach (int j in array2)
                Console.WriteLine(j);
            


            Console.ReadLine();
        }
    }
}
