using System;
using Calculator;
using NUnit.Framework;

namespace CalculatorControllerTests
{
    public class SimpleMathOperation
    {
        public int Add(int a, int b)
        {
            int x = a + b;
            return x;
        }

        public int Subtract(int a, int b)
        {
            int x = a - b;
            return x;
        }

        public int Multiply(int a, int b)
        {
            int x = a*b;
            return x;
        }
        
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                //Error: Cannot divide by zero
            }
            int x = a / b;
            return x;
        }

        [TestFixture]
        public class SimpleMathTest
        {
            private readonly CalculatorController _controller = new CalculatorController();
        
            [Test]
            public void SimpleAdditionTest()
            {
                SimpleMathOperation smo = new SimpleMathOperation();
                _controller.AcceptCharacter('3');
                int operandA = Convert.ToInt32(_controller.GetOutput());

                _controller.AcceptCharacter('1');
                // You may want to use "calc" to verify what the current state of the calculator is after you
                // enter "3" and then "1".
                int operandB = Convert.ToInt32(_controller.GetOutput());

                // This is testing the SimpleMathOperation class more than it is testing the CalculatorController
                // class.  Rather than writing a SimpleMathOperation class, try figuring out what intputs you
                // would need to give to the _controller CalculatorController instance in order to get its
                // output to be "4".
                int result = smo.Add(operandA, operandB);
                Assert.AreEqual(4, result);
            }

            [Test]
            public void SimpleSubtractionTest()
            {
                SimpleMathOperation smo = new SimpleMathOperation();
                _controller.AcceptCharacter('3');
                int operandA = Convert.ToInt32(_controller.GetOutput());
                _controller.AcceptCharacter('1');
                int operandB = Convert.ToInt32(_controller.GetOutput());
                int result = smo.Subtract(operandA, operandB);
                Assert.AreEqual(2, result);
            }

            [Test]
            public void SimpleMultiplicationTest()
            {
                SimpleMathOperation smo = new SimpleMathOperation();
                _controller.AcceptCharacter('3');
                int operandA = Convert.ToInt32(_controller.GetOutput());
                _controller.AcceptCharacter('1');
                int operandB = Convert.ToInt32(_controller.GetOutput());
                int result = smo.Multiply(operandA, operandB);
                Assert.AreEqual(3, result);
            }

            [Test]
            public void SimpleDivisionTest()
            {
                SimpleMathOperation smo = new SimpleMathOperation();
                _controller.AcceptCharacter('3');
                int operandA = Convert.ToInt32(_controller.GetOutput());
                _controller.AcceptCharacter('1');
                int operandB = Convert.ToInt32(_controller.GetOutput());
                int result = smo.Divide(operandA, operandB);
                Assert.AreEqual(3, result);
            }
        }
    }
}
