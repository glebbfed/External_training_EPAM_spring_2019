using System;
using System.Linq;

namespace Day05
{
    public sealed class Polynomial
    {
        private double[] coeffs;
        private double number;
        /// <summary>
        /// This is a constructor.
        /// </summary>
        /// <param name="number"> The variable.</param>
        /// <param name="coeffs">List of coefficients.</param>
        public Polynomial(double number, params double[] coeffs)
        {
            if (coeffs == null)
                throw new ArgumentNullException();
            this.number = number;
            this.coeffs = new double[coeffs.Length];
            for (int i = 0; i < coeffs.Length; i++)
                this.coeffs[i] = coeffs[i];
        }

        /// <summary>
        /// Calculate sum of monomials.
        /// </summary>
        /// <returns>
        /// Sum in double.
        /// </returns>

        public double CalculateSum()
        {
            double sum = 0;

            for (int i = 0; i < coeffs.Length; i++)
                sum += coeffs[i] * Math.Pow(number, i);

            return sum;
        }
        /// <summary>
        /// Overloaded operator equal of two polynomials.
        /// </summary>
        /// <param name="first">First polynomial</param>
        /// <param name="second">Second polynomial</param>
        /// <returns>True or false</returns>
        public static bool operator ==(Polynomial first, Polynomial second)
        {
            if (ReferenceEquals((object)first, (object)second))
            {
                return true;
            }

            if ((object)first == null || (object)second == null)
            {
                return false;
            }

            return first.coeffs.SequenceEqual(second.coeffs);
        }
        /// <summary>
        /// Overloaded operator is not equal to two polynomials.
        /// </summary>
        /// <param name="first">First polynomial</param>
        /// <param name="second">Second polynomial</param>
        /// <returns>True or false</returns>
        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            return !(pol1 == pol2);
        }

        /// <summary>
        /// Overloaded addition operator of two polynomials.
        /// </summary>
        /// <param name="first">First polynomial</param>
        /// <param name="second">Second polynomial</param>
        /// <returns>The resulting polynomial.</returns>
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            if (first.number != second.number)
                throw new ArgumentException();
            return new Polynomial(first.number ,Sum(first.coeffs, second.coeffs));
        }
        /// <summary>
        /// Overloaded difference operator of two polynomials.
        /// </summary>
        /// <param name="first">First polynomial</param>
        /// <param name="second">Second polynomial</param>
        /// <returns>The resulting polynomial.</returns>
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            if (first.number != second.number)
                throw new ArgumentException();
            return new Polynomial(first.number, Subtr(first.coeffs, second.coeffs));
        }
        /// <summary>
        /// Overloaded multiplication operator of two polynomials.
        /// </summary>
        /// <param name="first">First polynomial</param>
        /// <param name="second">Second polynomial</param>
        /// <returns>The resulting polynomial.</returns>
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            if (first.number != second.number)
                throw new ArgumentException();
            return new Polynomial(first.number, Mult(first.coeffs, second.coeffs));
        }



        /// <summary>
        /// Helper method for calculating the sum of polynomials.
        /// </summary>
        /// <param name="coeffs1">The list of coefficients of the first polynomial.</param>
        /// <param name="coeffs2">The list of coefficients of the second polynomial.</param>
        /// <returns>The list of coefficients of the resulting polynomial.</returns>
        private static double[] Sum(double[] coeffs1, double[] coeffs2)
        {
            double[] longest = (coeffs1.Length > coeffs2.Length) ? coeffs1 : coeffs2;
            double[] shortest = (longest == coeffs1) ? coeffs2 : coeffs1;

            double[] resArr = new double[longest.Length];
            longest.CopyTo(resArr, 0);

            for (int i = 0; i < shortest.Length; i++)
                resArr[i] += shortest[i];

            return resArr;
        }
        /// <summary>
        /// Helper method for calculating the difference of polynomials.
        /// </summary>
        /// <param name="coeffs1">The list of coefficients of the first polynomial.</param>
        /// <param name="coeffs2">The list of coefficients of the second polynomial.</param>
        /// <returns>The list of coefficients of the resulting polynomial.</returns>
        private static double[] Subtr(double[] coeffs1, double[] coeffs2)
        {
            double[] longest = (coeffs1.Length > coeffs2.Length) ? coeffs1 : coeffs2;

            double[] resArr = new double[longest.Length];
            coeffs1.CopyTo(resArr, 0);

            for (int i = 0; i < coeffs2.Length; i++)
                resArr[i] -= coeffs2[i];

            return resArr;
        }
        /// <summary>
        /// Helper method for calculating the composition of polynomials.
        /// </summary>
        /// <param name="coeffs1">The list of coefficients of the first polynomial.</param>
        /// <param name="coeffs2">The list of coefficients of the second polynomial.</param>
        /// <returns>The list of coefficients of the resulting polynomial.</returns>
        private static double[] Mult(double[] coeffs1, double[] coeffs2)
        {
            double[] res = new double[coeffs1.Length + coeffs2.Length - 1];

            for (int i = 0; i < coeffs1.Length; i++)
            {
                for (int j = 0; j < coeffs2.Length; j++)
                {
                    res[i + j] += coeffs1[i] * coeffs2[j];
                }
            }

            return res;
        }


        /// <summary>
        /// Overriding the ToString method
        /// </summary>
        /// <returns>Polynomial in a row.</returns>
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < coeffs.Length; i++)
            {
                str += coeffs[i].ToString() + "*" + number.ToString() + "^" + i.ToString();
                if (i + 1 != coeffs.Length)
                    str += "+";
            }
                
            return str;
        }
        /// <summary>
        /// Overriding the Equals(object) method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True or false</returns>
        public override bool Equals(object obj)
        {
            Polynomial pol = obj as Polynomial;
            if ((object)pol == null)
            {
                return false;
            }

            return pol.coeffs.SequenceEqual(pol.coeffs);
        }
        /// <summary>
        /// Overriding the GetHashCode() method
        /// </summary>
        /// <returns>hash Code</returns>
        public override int GetHashCode()
        {
            return coeffs.GetHashCode();
        }
    }
}
