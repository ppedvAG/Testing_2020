using Xunit;

namespace Calculator.Test_xUnit
{
    public class CalcTests_xUnit
    {
        [Fact]
        public void Calc_Substract_10_and_5_Results_5()
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Subtract(10, 5);

            //Assert
            Assert.Equal(5, result);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(12, 4, 18)]
        [InlineData(-7, 4, -11)]
        public void Calc_Subtract(int a, int b, int expected)
        {
            //Arrange
            var calc = new Calc();

            //Act
            var result = calc.Subtract(a, b);

            //Assert
            Assert.Equal(expected, result);
        }
    }
}
