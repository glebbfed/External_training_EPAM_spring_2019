using System.Collections.Generic;

namespace Task4
{
    public class Fibonaccci
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count">Count of Fibonacci numbers</param>
        /// <returns>Fibonacci numbers.</returns>
        public IEnumerable<int> GetFibonacci(int count)
        {
            int prev = 0;
            int number = 1;
            for (int i = 0; i < count; i++)
            {
                yield return number;
                int temp = prev;
                prev = number;
                number = temp + number;
            }
        }
    }
}
