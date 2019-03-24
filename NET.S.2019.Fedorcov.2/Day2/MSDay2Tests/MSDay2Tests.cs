using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Day2;
using System.Linq;

namespace MSDay2Tests
{
    [TestClass]
    public class MSDay2Tests
    {
        [TestMethod]
        public void FilterDigitTest()
        {
            List<int> list = new List<int>() { 1, 3, 4, 7, 17, 8 };
            List<int> list2 = Methods.FilterDigit(list, 7);
            List<int> list3 = new List<int>() { 7, 17 };
            Assert.AreEqual(true, list2.SequenceEqual(list3));
        }

        [TestMethod]
        public void InsertNumberTest1()
        {            
            Assert.AreEqual(9, Methods.InsertNumber(8, 15, 0, 0));
        }
        [TestMethod]
        public void InsertNumberTest2()
        {
            Assert.AreEqual(15, Methods.InsertNumber(15, 15, 0, 0));
        }
        [TestMethod]
        public void InsertNumberTest3()
        {
            Assert.AreEqual(120, Methods.InsertNumber(8, 15, 3, 8));
        }
    }
}
