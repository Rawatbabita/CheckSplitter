using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckSplitterLib;

namespace CheckSplitterTests
{
    [TestClass]
    public class CheckSplitterTests
    {
        [TestMethod]
        public void TestSplitAmount()
        {
            // Arrange
            var checkSplitter = new CheckSplitter();

            // Act
            var splitAmount = checkSplitter.SplitAmount(100, 4);

            // Assert
            Assert.AreEqual(25, splitAmount);
        }

        [TestMethod]
        public void TestSplitAmount_WithZeroTotalAmount()
        {
            // Arrange
            var checkSplitter = new CheckSplitter();

            // Act
            var splitAmount = checkSplitter.SplitAmount(0, 4);

            // Assert
            Assert.AreEqual(0, splitAmount);
        }

        [TestMethod]
        public void TestSplitAmount_WithNegativeNumberOfPeople()
        {
            // Arrange
            var checkSplitter = new CheckSplitter();

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => checkSplitter.SplitAmount(100, -1));
        }

        [TestMethod]
        public void TestCalculateTipPerPerson_WithEmptyMealCosts()
        {
            // Arrange
            var checkSplitter = new CheckSplitter();
            var mealCosts = new Dictionary<string, decimal>();

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => checkSplitter.CalculateTipPerPerson(mealCosts, 10));
        }

        [TestMethod]
        public void TestCalculateTipPerPerson_WithInvalidTipPercentage()
        {
            // Arrange
            var checkSplitter = new CheckSplitter();
            var mealCosts = new Dictionary<string, decimal> { { "Person1", 50 }, { "Person2", 50 } };

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => checkSplitter.CalculateTipPerPerson(mealCosts, -10));
        }

        [TestMethod]
        public void TestCalculateTipPerPerson_WithZeroMealCosts()
        {
            // Arrange
            var checkSplitter = new CheckSplitter();
            var mealCosts = new Dictionary<string, decimal> { { "Person1", 0 }, { "Person2", 0 } };

            // Act
            var tipPerPerson = checkSplitter.CalculateTipPerPerson(mealCosts, 10);

            // Assert
            Assert.AreEqual(0, tipPerPerson["Person1"]);
            Assert.AreEqual(0, tipPerPerson["Person2"]);
        }

        [TestMethod]
        public void TestCalculateTipPerPerson_WithLargeTipPercentage()
        {
            // Arrange
            var checkSplitter = new CheckSplitter();
            var mealCosts = new Dictionary<string, decimal> { { "Person1", 50 }, { "Person2", 50 } };

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => checkSplitter.CalculateTipPerPerson(mealCosts, 110));
        }

        [TestMethod]
        public void TestCalculateTipPerPerson_WithZeroTipPercentage()
        {
            // Arrange
            var checkSplitter = new CheckSplitter();
            var mealCosts = new Dictionary<string, decimal> { { "Person1", 50 }, { "Person2", 50 } };

            // Act
            var tipPerPerson = checkSplitter.CalculateTipPerPerson(mealCosts, 0);

            // Assert
            Assert.AreEqual(0, tipPerPerson["Person1"]);
            Assert.AreEqual(0, tipPerPerson["Person2"]);
        }

        [TestMethod]
        public void TestCalculateTipPerPerson_WithDecimalTipPercentage()
        {
            // Arrange
            var checkSplitter = new CheckSplitter();
            var mealCosts = new Dictionary<string, decimal> { { "Person1", 50 }, { "Person2", 50 } };

            // Act
            var tipPerPerson = checkSplitter.CalculateTipPerPerson(mealCosts, 10.5f);

            // Assert
            Assert.AreEqual(0.0525m, tipPerPerson["Person1"]);
            Assert.AreEqual(0.0525m, tipPerPerson["Person2"]);
        }


    }
}
