using NETUnitTestUzduotis.Services;

namespace NETUnitTestUzduotis.Tests
{
    public class MathTests
    {
        const int a = 5; 
        const int b = 7;

        IMathService mathService;
        
        [Fact]
        public void Sum_Test()
        {
            //Arrange
            mathService = new MathService();
            //Act
            int result = mathService.Sum(a, b);
            //Assert
            Assert.Equal(12, result);
        }
        [Fact]
        public void Subtract_Test()
        {
            //Arrange
            mathService = new MathService();
            int expectedResult = a - b;
            //Act
            int result = mathService.Subtract(a, b);
            //Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void Multiply_Test()
        {
            //Arrange
            mathService = new MathService();
            //Act
            int result = mathService.Multiply(a, b);
            //Assert
            Assert.Equal(35, result);
        }

    }
}