using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        [TestCategory("Unit Tests")]
        public void Calc_Substract_10_and_5_Results_5()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Subtract(10, 5);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        [TestCategory("Unit Tests")]
        public void Calc_Substract_N7_and_12_Results_N19()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Subtract(-7, 12);

            //Assert
            Assert.AreEqual(-19, result);
        }


        [TestMethod]
        public void Calc_Substract_0_and_0_Results_0()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Subtract(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        //[ExpectedException(typeof(OverflowException))] //oldSchool

        public void Calc_Substract_N10_and_MAX_throws()
        {
            var calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Subtract(-10, int.MaxValue));
            //calc.Subtract(-10, int.MaxValue);
        }

        [TestMethod]
        [DataRow(1, 2, -1)]
        [DataRow(12, 4, 8)]
        [DataRow(-7, 4, -11)]
        public void Calc_Subtract(int a, int b, int expected)
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Subtract(a, b);

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}
