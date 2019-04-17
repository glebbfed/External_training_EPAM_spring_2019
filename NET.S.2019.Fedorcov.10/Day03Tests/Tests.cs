using NUnit.Framework;
using Day03;
using System;
namespace Tests
{
    public class Tests
    {

        [TestCase]
        public void EuclidGCDTest1()
        {
            int expected = 3;
            int actual = GCD.EuclidGCD(3, 300);

            Assert.AreEqual(expected, actual);
        }
        [TestCase]
        public void EuclidGCDTest2()
        {

            int expected = 3;
            int actual = GCD.EuclidGCD(27, 18, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclidGCDTest3()
        {

            int expected = 106;
            int actual = GCD.EuclidGCD(106, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclidGCDTest4()
        {

            int expected = 1;
            int actual = GCD.EuclidGCD(102, 184, 195, 271, 1017, 2018, 2019, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void EuclidGCDTest5()
        {

            int expected = 1;
            int actual = GCD.EuclidGCD(int.MaxValue, 105, 19, 21, 3019);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDTest1()
        {
            int expected = 3;
            int actual = GCD.BinaryGCD(3, 300);

            Assert.AreEqual(expected, actual);
        }
        [TestCase]
        public void BinaryGCDTest2()
        {

            int expected = 3;
            int actual = GCD.BinaryGCD(27, 18, 3);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDTest3()
        {

            int expected = 106;
            int actual = GCD.BinaryGCD(106, 0);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDTest4()
        {

            int expected = 1;
            int actual = GCD.BinaryGCD(102, 184, 195, 271, 1017, 2018, 2019, 8);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDTest5()
        {

            int expected = 1;
            int actual = GCD.BinaryGCD(int.MaxValue, 105, 19, 21, 3019);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryRepresentationTest1()
        {
            double number = -255.255;

            string actual = number.BinaryRepresentation();
            string expected = "1100000001101111111010000010100011110101110000101000111101011100";

            Assert.AreEqual(expected, actual);
        }
        [TestCase]
        public void BinaryRepresentationTest2()
        {
            double number = 255.255;

            string actual = number.BinaryRepresentation();
            string expected = "0100000001101111111010000010100011110101110000101000111101011100";

            Assert.AreEqual(expected, actual);
        }
        [TestCase]
        public void BinaryRepresentationTest3()
        {
            double number = 4294967295.0;

            string actual = number.BinaryRepresentation();
            string expected = "0100000111101111111111111111111111111111111000000000000000000000";

            Assert.AreEqual(expected, actual);
        }
        [TestCase]
        public void BinaryRepresentationTest4()
        {
            double number = double.MinValue;

            string actual = number.BinaryRepresentation();
            string expected = "1111111111101111111111111111111111111111111111111111111111111111";

            Assert.AreEqual(expected, actual);
        }
        [TestCase]
        public void BinaryRepresentationTest5()
        {
            double number = double.MaxValue;

            string actual = number.BinaryRepresentation();
            string expected = "0111111111101111111111111111111111111111111111111111111111111111";

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BinaryGCDMinIntTest()
        {

            Assert.Throws<ArgumentException>(() => GCD.BinaryGCD(256, int.MinValue));
        }
        [TestCase]
        public void BinaryGCDNullTest()
        {

            Assert.Throws<ArgumentNullException>(() => GCD.BinaryGCD(null));
        }
        [TestCase]
        public void BynaryGCDOneNumberTest()
        {

            Assert.Throws<ArgumentException>(() => GCD.BinaryGCD(3));
        }
        [TestCase]
        public void EuclidGCDMinIntTest()
        {

            Assert.Throws<ArgumentException>(() => GCD.EuclidGCD(256, int.MinValue));
        }
        [TestCase]
        public void EuclidGCDNullTest()
        {

            Assert.Throws<ArgumentNullException>(() => GCD.EuclidGCD(null));
        }
        [TestCase]
        public void EuclidGCDOneNumberTest()
        {

            Assert.Throws<ArgumentException>(() => GCD.EuclidGCD(3));
        }
    }
}