using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator.DataAccess;
using SimpleCalculatorLibrary;
using System;
using Moq;
namespace SimpleCalculator.UnitTest
{
    //class MockCalculatorRepo : ICalculatorRepo
    //{
    //    public bool Save(string data)
    //    {
    //        return true;
    //    }
    //}


    [TestClass]
    public class CalculatorUnitTest
    {
        private Calculator calculator = null;
        Mock<ICalculatorRepo> mock = null;

        [TestInitialize]
        public void Init()
        {
            //ICalculatorRepo mock = new MockCalculatorRepo();
            //calculator = new Calculator(mock);

            mock = new Mock<ICalculatorRepo>();
            mock.Setup(m => m.Save(string.Empty)).Returns(true);

            calculator = new Calculator(mock.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            calculator = null;
            mock = null;
        }
        [TestMethod]
        public void Sum_WithValidInput_ShouldGiveValidResult() //Test Casees
        {
            // do not use contitional statemetns
            // do not use iterative statements
            // do not use try catch blocks
            // write only simple statements

            // AAA - Arrange, Act, Assert approach

            // Arrange
            int a = 10;
            int b = 20;
            int expectedResult = 30;
            //Calculator calculator = new Calculator();

            // Act
            int actual = calculator.Sum(a, b);

            // Assert
            Assert.AreEqual(expectedResult, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(NegativeInputException))]
        public void Sum_WithNegativeInput_ShouldThrowExceptiont() //Test Casees
        {
            // do not use contitional statemetns
            // do not use iterative statements
            // do not use try catch blocks
            // write only simple statements

            // AAA - Arrange, Act, Assert approach

            //Calculator calculator = new Calculator();
            calculator.Sum(-1, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(OddInputException))]
        public void Sum_WithOddInput_ShouldThrowExceptiont() //Test Casees
        {
            // do not use contitional statemetns
            // do not use iterative statements
            // do not use try catch blocks
            // write only simple statements

            // AAA - Arrange, Act, Assert approach
            //new Calculator().Sum(1, 1);
            calculator.Sum(1, 1);
        }

        [TestMethod]
        public void Sum_WithValidInput_ShouldCallSaveMethod() //Test Casees
        {
            // do not use contitional statemetns
            // do not use iterative statements
            // do not use try catch blocks
            // write only simple statements

            // AAA - Arrange, Act, Assert approach
            
            calculator.Sum(10, 20);
            mock.Verify(m => m.Save("10 + 20 = 30"), Times.Once());

        }
    }
}
  