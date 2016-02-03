using NUnit.Framework;
using Calculator;

namespace CalculatorControllerTests
{
    [TestFixture]
    public class YanaTests
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
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('4');

            _controller.AcceptCharacter('c');

            Assert.That(_controller.GetOutput(), Is.Empty);
        }
        
        [Test]
        public void CanNotDivideByZero()
        {
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('=');

            Assert.That(_controller.GetOutput(), Is.EqualTo("Cannot be divided by zero"));
        }

        [Test]
        public void CanMultiplyByZero()
        {
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('=');

            Assert.That(_controller.GetOutput(),Is.EqualTo('0'));
        }

        [Test]
        public void CanMultiplyByNegativeNumber()
        {
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('4');
            _controller.AcceptCharacter('=');
            
            Assert.That(_controller.GetOutput(), Is.EqualTo("-20"));
        }

        [Test]
        public void CanDivideByNegativeNumber()
        {
            _controller.AcceptCharacter('2');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('=');

            Assert.That(_controller.GetOutput(), Is.EqualTo("-4"));
        }

        [Test]
        public void CanAddTwoNegativeNumbers()
        {
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('+');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('=');

            Assert.That(_controller.GetOutput(), Is.EqualTo("-10"));
        }

        [Test]
        public void CanAddOneNegativeAndAnotherPositiveNumber()
        {
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('+');
            _controller.AcceptCharacter('8');
            _controller.AcceptCharacter('=');
           
            Assert.That(_controller.GetOutput(), Is.EqualTo("3"));
        }

        [Test]
        public void CanSubtractTwoNegativeNumbers()
        {
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('=');

            Assert.That(_controller.GetOutput(), Is.EqualTo("-10"));
        }

        [Test]
        public void CanEnterDigitsOneAfterAnother()
        {
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('5');
            _controller.AcceptCharacter('=');

            Assert.That(_controller.GetOutput(), Is.EqualTo("505"));
        }
    }
}
