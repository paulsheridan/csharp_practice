using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using NUnit.Framework;

namespace CalculatorControllerTests
{
    public class BaseTestFixture
    {
        // This CalculatorController instance will be created before any test is run, and will be used by each test in turn.
        protected readonly CalculatorController _controller = new CalculatorController();

        // The method that is marked with the [SetUp] annotation is run before each test is run.
        // In this case, its purpose is to call Clear() on the CalculatorController so that each test starts with a clean slate.
        [SetUp]
        public void BeforeEachTest()
        {
            _controller.AcceptCharacter('c');
        }

        // These helper functions make it easier to express simple interactions with the calculator, without having to
        // have ten or fifteen lines of "_controller.AcceptCharacter('7');" and so on
        protected void EnterNumber(Decimal input)
        {
            AcceptCharacters(input.ToString());
        }

        protected void AcceptCharacters(string inputString)
        {
            foreach (char expressionChar in inputString)
            {
                _controller.AcceptCharacter(expressionChar);
            }
        }

        protected void AssertOutput(string expectedOutput)
        {
            Assert.That(_controller.GetOutput(), Is.EqualTo(expectedOutput));
        }
    }
}
