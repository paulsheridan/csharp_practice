using NUnit.Framework;
using Calculator;

namespace CalculatorControllerTests
{
    [TestFixture]
    public class BryanTests
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
            _controller.AcceptCharacter('3');

            // An example of a constraint other than "Is"  In this case, the Substring() method of the
            // "Contains" class returns a constraint that requires that the value being tested contain the
            // substring "3".
            Assert.That(_controller.GetOutput(), Contains.Substring("3"));

            Assert.That(_controller.GetOutput(), Is.EqualTo("13"));
        }
        [Test]
        public void CanClearCurrentDisplay()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('3');
            _controller.AcceptCharacter('c');

            Assert.That(_controller.GetOutput(), Is.Empty);
        }

        // You may wish to open "calc" and enter "0", "1", "2" to see whether this test
        // correctly represents your expectations.
        [Test]
        public void CanEnterAnyDigitConsecutively()
        {
            for (int i = 0; i < 9; i++)
            {
                _controller.AcceptCharacter((char) i);
                Assert.That(_controller.GetOutput(), Is.EqualTo(i.ToString()));
            }
        }
        [Test]
        public void CanNotDivideByZero()
        {
            _controller.AcceptCharacter('3');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('=');

            Assert.That(_controller.GetOutput(), Is.EqualTo("Cannot divide by zero"));
        }
        
    }
}
