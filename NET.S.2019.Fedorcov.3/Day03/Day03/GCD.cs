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
        /// Method that implements the Euclidean algorithm for two or more numbers. 
        /// </summary>
        /// <param name="numbers">Numbers</param>
        /// <returns></returns>
        public static int EuclidGCD(params int[] numbers)
        {
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
                if (numbers[i+1] < 0)
                    numbers[i + 1] = Math.Abs(numbers[i + 1]);

                if (numbers[i] == 0)
                {
                    numbers[i] = numbers[i + 1];
                }

                if (numbers[i + 1] == 0)
                {
                    numbers[i + 1] = numbers[i];
                }

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

                i++;
            }
            i--;
            return numbers[i];

        }
        /// <summary>
        /// Method that calculates the execution time of the Euclidean algorithm
        /// </summary>
        /// <param name="numbers">Numbers</param>
        /// <returns></returns>
        public static long EuclidGCDTime(params int[] numbers)
        {
            EuclidGCD(numbers);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            EuclidGCD(numbers);
            return watch.ElapsedMilliseconds;
        }
        /// <summary>
        /// Method that implements the Binary algorithm for two or more numbers.
        /// </summary>
        /// <param name="numbers">Numbers</param>
        /// <returns></returns>
        public static int BinaryGCD(params int[] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException();
            if (numbers.Length < 2)
                throw new ArgumentException();
            for (int j = 0; j < numbers.Length; j++)
            {
                if (numbers[j] == int.MinValue)
                    throw new ArgumentException();
            }

            int shift = 0;

            int i = 0;
            if (numbers[i] < 0)
                numbers[i] = Math.Abs(numbers[i]);

            while (i + 1 < numbers.Length)
            {
                if (numbers[i + 1] < 0)
                    numbers[i + 1] = Math.Abs(numbers[i + 1]);

                while (((numbers[i] | numbers[i + 1]) & 1) == 0)
                {
                    numbers[i] >>= 1;
                    numbers[i + 1] >>= 1;
                    shift++;
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

                i++;
            }
            return numbers[i] << shift;
        }
        /// <summary>
        /// Method that calculates the execution time of the Bynary algorithm
        /// </summary>
        /// <param name="numbers">Numbers</param>
        /// <returns></returns>
        public static long BinaryGCDTime(params int[] numbers)
        {
            BinaryGCD(numbers);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            BinaryGCD(numbers);
            return watch.ElapsedMilliseconds;

        }

        public static void Main(string[] args)
        {

        }
    }
}
