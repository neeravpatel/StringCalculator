using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using StringCalculatorNamespace;

namespace StringCalculatorUnitTest
{
    [TestClass]
    public class StringCalculatorUnitTest
    {
        StringCalculator obj = new StringCalculator();

        [TestMethod]
        public void TestAddSimple()
        {

            List<string> testnumbers = new List<string> { "1,2,5" };
            int result = obj.Add(testnumbers);
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void TestAddNewLine()
        {
            List<string> testnumbers1 = new List<string> { "1\r\n", ",2,3" };
            int result1 = obj.Add(testnumbers1);
            Assert.AreEqual(6, result1);

            List<string> testnumbers2 = new List<string> { "1,\r\n", "2,4" };
            int result2 = obj.Add(testnumbers2);
            Assert.AreEqual(7, result2);
        }

        [TestMethod]
        public void TestAddCustomDelimiter()
        {
            List<string> testnumbers = new List<string> { "//;\r\n", "1;3;4" };
            int result = obj.Add(testnumbers);
            Assert.AreEqual(8, result);

            List<string> testnumbers2 = new List<string> { "//$\r\n", "1$2$3" };
            int result2 = obj.Add(testnumbers2);
            Assert.AreEqual(6, result2);

            List<string> testnumbers3 = new List<string> { "//@\r\n", "2@3@8" };
            int result3 = obj.Add(testnumbers3);
            Assert.AreEqual(13, result3);
        }

        [TestMethod]
        public void TestAddIgnoreLargeThan1000()
        {
            List<string> testnumbers = new List<string> { "1001,3" };
            int result = obj.Add(testnumbers);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void TestAddDelimiterArbitraryLength()
        {
            List<string> testnumbers = new List<string> { "//***\r\n", "1***2***3" };
            int result = obj.Add(testnumbers);
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void TestAddMultipleDelimiter()
        {
            List<string> testnumbers = new List<string> { "//$,@\r\n", "1$2@3" };
            int result = obj.Add(testnumbers);
            Assert.AreEqual(6, result);
        }


        [TestMethod]
        public void TestAddMultipleDelimiterArbitraryLength()
        {
            List<string> testnumbers1 = new List<string> { "//**,@*\r\n", "1**2@*3" };
            int result1 = obj.Add(testnumbers1);
            Assert.AreEqual(6, result1);

            List<string> testnumbers2 = new List<string> { "//**,@\r\n", "3**3@3" };
            int result2 = obj.Add(testnumbers2);
            Assert.AreEqual(9, result2);

        }

    }
}
