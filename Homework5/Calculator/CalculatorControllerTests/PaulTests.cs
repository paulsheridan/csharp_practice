using System;
using NUnit.Framework;
using Calculator;

namespace CalculatorControllerTests
{
    [TestFixture]
    public class PaulTests
    {
        // This CalculatorController instance will be created before any test is run, and will be used by each test in turn.
        private readonly CalculatorController _controller = new CalculatorController();

        // The method that is marked with the [SetUp] annotation is run before each test is run.
        // In this case, its purpose is to call Clear() on the CalculatorController so that each test starts with a clean slate.
        [SetUp]
        public void BeforeEachTest()
        {
            _controller.AcceptCharacter('c');
        }

        [Test]
        public void CanEnterSingleDigit()
        {
            _controller.AcceptCharacter('1');
            Assert.That(_controller.GetOutput(), Is.EqualTo("1"));
        }

        [Test]
        public void CanEnterMultipleDigits()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('2');
            _controller.AcceptCharacter('3');
            _controller.AcceptCharacter('4');
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('6');
            _controller.AcceptCharacter('7');
            _controller.AcceptCharacter('8');
            _controller.AcceptCharacter('9');
            Assert.That(_controller.GetOutput(), Is.EqualTo("123456789"));
        }

        [Test]
        public void CanClearAfterlInput()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('c');
            Assert.That(_controller.GetOutput(), Is.Empty);
        }

        [Test]
        public void SimpleAddition()
        {
            _controller.AcceptCharacter('2');
            _controller.AcceptCharacter('+');
            _controller.AcceptCharacter('4');
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("6"));
        }

        [Test]
        public void SimpleAdditionMultipleOperators()
        {
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('+');
            _controller.AcceptCharacter('6');
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("11"));
        }

        [Test]
        public void SimpleSubtractionLargeNumbers()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('2');
            _controller.AcceptCharacter('3');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('4');
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("78"));
        }

        [Test]
        public void SimpleMultiplication()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('2');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('4');
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("48"));
        }

        [Test]
        public void SimpleDivision()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('6');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('4');
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("4"));
        }

        [Test]
        public void AddingNegatives()
        {
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('8');
            _controller.AcceptCharacter('+');
            _controller.AcceptCharacter('8');
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("-10"));
        }

        [Test]
        public void MultiplyingNegatives()
        {
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('3');
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("-8"));
        }

        [Test]
        public void MultiplyingByZero()
        {
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
        }

        [Test]
        public void DividingByZero()
        {
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("Cannot divide by zero"));
        }

    }
}

        
      