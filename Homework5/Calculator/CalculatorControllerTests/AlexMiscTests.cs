using NUnit.Framework;
using Calculator;

namespace CalculatorControllerTests
{
    class AlexMiscTests
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
        public void CanNotDivideByZero()
        {
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("Division by 0"));
        }

        [Test]
        public void CanProcessDecimals()
        {
            _controller.AcceptCharacter('.');
            Assert.That(_controller.GetOutput(), Contains.Substring("."));
        }
    }
}
