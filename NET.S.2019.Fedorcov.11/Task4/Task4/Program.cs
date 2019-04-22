using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonaccci fibonaccciNumbers = new Fibonaccci();
            Console.WriteLine("Enter count of numbers!");
            string countOfNumbers = Console.ReadLine();
            int count = Int32.Parse(countOfNumbers);
            foreach (int n in fibonaccciNumbers.GetFibonacci(count))
            {
                Console.WriteLine(n);
            }
            Console.ReadKey();
        }
    }
}
