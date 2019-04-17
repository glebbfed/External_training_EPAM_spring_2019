using System;

namespace Day03
{
    public static class Extension
    {
        /// <summary>
        /// A method that converts a real number into a binary representation.
        /// </summary>
        /// <param name="number">Numbers</param>
        /// <returns></returns>
        public static string BinaryRepresentation(this double number)
        {
            string binaryRepresentation = Convert.ToString(BitConverter.DoubleToInt64Bits(number), 2);
            string zeros = "";
            
            for (int i = binaryRepresentation.Length; i < 64; i++)
            {
                zeros += "0";
            }
            binaryRepresentation = zeros + binaryRepresentation;
            return binaryRepresentation;
        }
    }
}
