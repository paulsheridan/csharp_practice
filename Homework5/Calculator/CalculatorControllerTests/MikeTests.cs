using NUnit.Framework;
using Calculator;

namespace CalculatorControllerTests
{
    [TestFixture]
    public class MikeTests
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
        public void CanEnterMultiDigitNumbers()
        {
            _controller.AcceptCharacter('1');
            Assert.That(_controller.GetOutput(), Is.EqualTo("1"));

            _controller.AcceptCharacter('2');
            Assert.That(_controller.GetOutput(), Is.EqualTo("12"));

            _controller.AcceptCharacter('3');
            Assert.That(_controller.GetOutput(), Is.EqualTo("123"));

            _controller.AcceptCharacter('4');
            Assert.That(_controller.GetOutput(), Is.EqualTo("1234"));

            _controller.AcceptCharacter('5');
            Assert.That(_controller.GetOutput(), Is.EqualTo("12345"));

            _controller.AcceptCharacter('6');
            Assert.That(_controller.GetOutput(), Is.EqualTo("123456"));

            _controller.AcceptCharacter('7');
            Assert.That(_controller.GetOutput(), Is.EqualTo("1234567"));

            _controller.AcceptCharacter('8');
            Assert.That(_controller.GetOutput(), Is.EqualTo("12345678"));

            _controller.AcceptCharacter('9');
            Assert.That(_controller.GetOutput(), Is.EqualTo("123456789"));

            _controller.AcceptCharacter('+');
            Assert.That(_controller.GetOutput(), Is.EqualTo("+"));

            // What happens if you run "calc", and enter a number, then "+", and
            // then "-"?
            _controller.AcceptCharacter('-');
            Assert.That(_controller.GetOutput(), Is.EqualTo("-"));

            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("="));

            _controller.AcceptCharacter('/');
            Assert.That(_controller.GetOutput(), Is.EqualTo("/"));

            _controller.AcceptCharacter('*');
            Assert.That(_controller.GetOutput(), Is.EqualTo("*"));
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
    }
}
