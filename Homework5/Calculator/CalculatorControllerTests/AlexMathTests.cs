using System;
using NUnit.Framework;
using Calculator;

namespace CalculatorControllerTests
{
    class AlexMathTests
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

        private bool DoMath(char @operator)
        {
            decimal expectedResult = 0;
            Random random = new Random();
            decimal number1 = random.Next(0, int.MaxValue);
            decimal number2 = random.Next(0, int.MaxValue);
            switch (@operator)
            {
                case '+':
                    expectedResult = number1 + number2;
                    break;
                case '-':
                    expectedResult = number1 - number2;
                    break;
                case '*':
                    expectedResult = number1 * number2;
                    break;
                case '/':
                    expectedResult = number1 / number2;
                    break;
            }
            
            string mathExpression = string.Format("{0}{1}{2}=", number1.ToString(), @operator.ToString(), number2.ToString());

            foreach (char expressionChar in mathExpression)
            {
                _controller.AcceptCharacter(expressionChar);
            }

            return Convert.ToDecimal(_controller.GetOutput()) == expectedResult;
        }

//        private double unifyPresicion(double number)
//        {
//            const double presicionMultiplier = 100000000.0;
//            return Math.Ceiling(number*presicionMultiplier)/presicionMultiplier;
//        }

        [Test]
        public void CanDoAddition()
        {
            Assert.IsTrue(DoMath('+'));
        }

        [Test]
        public void CanDoSubtraction()
        {
            Assert.IsTrue(DoMath('-'));
        }

        [Test]
        public void CanDoMultiplication()
        {
            Assert.IsTrue(DoMath('*'));
        }

        [Test]
        public void CanDoDivision()
        {
            Assert.IsTrue(DoMath('/'));
        }
    }
}
