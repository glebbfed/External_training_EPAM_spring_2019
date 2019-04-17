using System;
namespace Day03
{
    public static class GCD
    {
        /// <summary>
        /// Swap method.
        /// </summary>
        /// <param name="x">First number</param>
        /// <param name="y">Second number</param>
        private static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }
        /// <summary>
        /// Method that implements the GCD algorithm for two or more numbers. 
        /// </summary>
        /// <param name="numbers">Numbers</param>
        /// <returns></returns>

        public delegate int CalcGCD(ref int[] numbers, ref int i);

        public static int Calculate(out long time, CalcGCD method, params int[] numbers)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            if (numbers == null)
                throw new ArgumentNullException();
            if (numbers.Length < 2)
                throw new ArgumentException();
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[j] == int.MinValue)
                    throw new ArgumentException();
            }

            int i = 0;
            if (numbers[i] < 0)
                numbers[i] = Math.Abs(numbers[i]);
            while (i + 1 < numbers.Length)
            {
                if (numbers[i + 1] < 0)
                    numbers[i + 1] = Math.Abs(numbers[i + 1]);

                if (numbers[i] == 0)
                {
                    numbers[i] = numbers[i + 1];
                }

                if (numbers[i + 1] == 0)
                {
                    numbers[i + 1] = numbers[i];
                }
                method(ref numbers, ref i);
                i++;
    `       }
            i--;
            time = watch.ElapsedMilliseconds;
            return numbers[i];


        }
        // Euclidian algorithm.
        private static void EuclidGCD(ref int[] numbers, ref int i)
        {
                while (numbers[i] != numbers[i + 1])
                {
                    if (numbers[i] <= numbers[i + 1])
                    {
                        numbers[i + 1] = numbers[i + 1] - numbers[i];
                    }
                    else
                    {
                        numbers[i] = numbers[i] - numbers[i + 1];
                    }
                }

        }
        
        // Binary algorithm.
        private static void BinaryGCD(ref int[] numbers, ref int i)
        {
                if (numbers[i] != numbers[i + 1])
                {
                    int shift = 0;
                    while (((numbers[i] | numbers[i + 1]) & 1) == 0)
                    {
                        shift++;
                        numbers[i] >>= 1;
                        numbers[i + 1] >>= 1;
                    }

                    while ((numbers[i] & 1) == 0)
                    {
                        numbers[i] >>= 1;
                    }
                    do
                    {
                        while ((numbers[i + 1] & 1) == 0)
                        {
                            numbers[i + 1] >>= 1;
                        }
                        if (numbers[i] > numbers[i + 1])
                        {
                            Swap(ref numbers[i], ref numbers[i + 1]);
                        }
                        numbers[i + 1] -= numbers[i];
                    } while (numbers[i + 1] != 0);
                    numbers[i] <<= shift;
                    numbers[i + 1] = numbers[i];
                }
        }

        public static void Main(string[] args)
        {

        }
    }
}