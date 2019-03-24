using System;
using System.Collections.Generic;


namespace Day2
{
    public class Methods
    {
        /// <summary>
        /// This method inserts the bits of the first number into another number.
        /// </summary>
        /// <param name="numberSource"> First number.</param>
        /// <param name="numberln">Second number.</param>
        /// <param name="i">Start index.</param>
        /// <param name="j">End index.</param>
        /// <returns></returns>
        public static int InsertNumber(int numberSource, int numberln, int i, int j)
        {
            if (i < 0 || i > 31 || j < 0 || j > 31 || numberSource == 0 || numberln == 0 || i > j)
                throw new ArgumentException();

            string source = Convert.ToString(numberSource, 2);
            string ln = Convert.ToString(numberln, 2);
            char[] byteSource = source.ToCharArray();
            char[] byteln = ln.ToCharArray();
            Array.Reverse(byteSource);
            Array.Reverse(byteln);
            if (byteSource.Length < j)
            {
                int t = byteSource.Length;
                Array.Resize(ref byteSource, j);
                for (int _i = t; _i < byteSource.Length; _i++)
                    byteSource[_i] = '0';
            }

            if (byteln.Length < j)
            {
                int t = byteln.Length;
                Array.Resize(ref byteln, j);
                for (int _i = t; _i < byteln.Length; _i++)
                    byteln[_i] = '0';
            }
            int k = 0;
            while (i <= j && i < byteSource.Length)
            {
                
                byteSource[i] = byteln[k];
                i++;
                k++;
            }
            Array.Reverse(byteSource);
            source = new string(byteSource);
            source = Convert.ToString(Convert.ToInt32(source, 2), 10);
            numberSource = Convert.ToInt32(source);
            return numberSource;
        }

        /// <summary>
        /// This method selects from the list the numbers that contain the given digit.
        /// </summary>
        /// <param name="list">Start list of numbers.</param>
        /// <param name="digit">Given digit.</param>
        /// <returns>Number after insertion.</returns>
        public static List<int> FilterDigit(List<int> list, int digit)
        {
            if (list == null)
                throw new ArgumentNullException();
            if (digit < 0 || digit > 9)
                throw new ArgumentException();
            List<int> newList = new List<int>();
            foreach (int i in list)
            {
                string temp = i.ToString();                  
                if (temp.Contains(digit.ToString()))
                    newList.Add(i);
            }
            return newList;
        }

        /// <summary>
        /// This method calculates the root of degree n of a.
        /// </summary>
        /// <param name="a">Given number.</param>
        /// <param name="power">Required root degree.</param>
        /// <param name="accuracy">The accuracy of the calculation.</param>
        /// <returns>Found root.</returns>
        public static double FindNthRoot(double a, int power, double accuracy)
        {
            if (power < 0 || accuracy > 1 || accuracy < 0)
                throw new ArgumentException();
            double res = a;
            double prev = 0;
            while (Math.Abs(prev - res) > accuracy)
            {
                prev = res;
                res = (1.0 / power) * ((power - 1) * res + a / (Math.Pow(res, power - 1)));
            }
            return res;
        }

        /// <summary>
        /// Method that calculates the time of the method NextBiggerThan.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The running time of the method in milliseconds.</returns>
        public static long NextBiggerThanTime(int number)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            NextBiggerThan(number);
            return (watch.ElapsedMilliseconds);


        }


        /// <summary>
        /// This method searches for the nearest number consisting of the digits of the source number.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The nearest greater number or -1, if there is none or -1 if there is none.</returns>
        public static int? NextBiggerThan(int number)
        {
            if (number < 0 || number == int.MaxValue)
                throw new ArgumentException();
            if (number.ToString()[number.ToString().Length - 1] == '0')
                return -1;
            string bufString = number.ToString();
            char[] buf = bufString.ToCharArray();
            List<string> list = new List<string>();
            NextBiggerThanHelper(buf.Length, buf,  list);
            int[] numbers = new int[list.Count];
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                numbers[i] = Convert.ToInt32(list[i]);
            }
            int result = number;
            for (int i = 0; i < numbers.Length; i++)
                if (number == numbers[i])
                    result = numbers[i+1];
            if (result == number)
                return -1;
            else
                return result;
        }

        /// <summary>
        /// Helper method of a method NextBiggerThan that finds all possible combinations of a number from its digits.
        /// </summary>
        /// <param name="count">Count of digits.</param>
        /// <param name="buf">Buffer from char.</param>
        /// <param name="list">List with combinations.</param>
        private static void NextBiggerThanHelper(int count, char[] buf, List<string> list)
        {
            if (count == 0)
                list.Add(string.Join("", buf));

            char str = ' ';

            for (int i = 0; i < count; i++)
            {
                NextBiggerThanHelper(count - 1, buf, list);
                int j;
                if (count % 2 == 0)
                    j = 0;
                else
                    j = i;
                str = buf[j];
                buf[j] = buf[count - 1];
                buf[count - 1] = str;
            }

        }
    }
}
