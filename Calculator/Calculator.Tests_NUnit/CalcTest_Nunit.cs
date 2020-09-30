using NUnit.Framework;

namespace Calculator.Tests_NUnit
{
    [TestFixture]
    public class CalcTest_Nunit
    {
        [Test]
        public void Calc_Substracts_50_and_25_results_25()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Subtract(50, 25);

            //Assert
            Assert.AreEqual(25, result);
            Assert.That(result, Is.EqualTo(25));

        }
    }
}
