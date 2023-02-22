using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculatorLibrary;
using System;

namespace SimpleCalculator.UnitTest
{
    [TestClass]
    public class CalculatorUnitTest
    {
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
            Calculator calculator = new Calculator();

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

            Calculator calculator = new Calculator();
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
            new Calculator().Sum(1, 1);
        }
    }
}
  