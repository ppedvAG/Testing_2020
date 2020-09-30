using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Subtract(10, 5);

            //Assert
            Assert.AreEqual(5, result);
        }
    }
}
