using NUnit.Framework;
using Calculator;

namespace CalculatorControllerTests
{
    /*
     * Thoughts on testing:
     * 
     * 1. Nothing related to BODMAS (or priority rules)
     * 2. No mix and match of operators
     * 3. assuming positive and negative numbers
     * 4. No decimal numbers (that is no 0.5 ... everything we test needs to be whole number)
     * 5. Assuming division by zero genrates Error string
     * 6. Assuming decimal numbers (not octal or hexa)
     */


    [TestFixture]
    public class AhsanTests
    {
        // This CalculatorController instance will be created before any test is run, and will be used by each test in turn.
        private readonly CalculatorController _controller = new CalculatorController();

        // The method that is marked with the [SetUp] annotation is run before each test is run.
        // In this case, its purpose is to call Clear() on the CalculatorController so that each test starts with a clean slate.
        [SetUp]
        public void BeforeEachTest()
        {
            // Someday, this method will reset the calculator controller to a "like-new" state.
            // I added it to the public interface of the CalculatorController class so that tests
            // can share a CalculatorController instance -- they just need to call "Clear" before 
            // each test.
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
        public void DoesClearWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('c');

            Assert.That(_controller.GetOutput(),Is.EqualTo(""));
        }


        [Test]
        public void DoesSingleDigitAdditionWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('+');
            _controller.AcceptCharacter('8');

            Assert.That(_controller.GetOutput(), Is.EqualTo("9"));
        }

        [Test]
        public void DoesMultipleDigitAdditionWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('+');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');

            Assert.That(_controller.GetOutput(), Is.EqualTo("110"));
        }

        [Test]
        public void DoesStartingZeroAdditionWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('+');
            _controller.AcceptCharacter('0');

            Assert.That(_controller.GetOutput(), Is.EqualTo("11"));
        }

        [Test]
        public void DoesEndingZeroAdditionWork()
        {
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('+');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('0');

            Assert.That(_controller.GetOutput(), Is.EqualTo("10"));
        }

        [Test]
        public void DoesMultipleDigitSubtractionWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('9');

            Assert.That(_controller.GetOutput(), Is.EqualTo("82"));
        }

        [Test]
        public void DoesSingleDigitSubtractionWork()
        {
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('6');

            Assert.That(_controller.GetOutput(), Is.EqualTo("3"));
        }

        [Test]
        public void DoesFirstZeroDigitSubtractionWork()
        {
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('9');

            Assert.That(_controller.GetOutput(), Is.EqualTo("-19"));
        }

        [Test]
        public void DoesLastZeroDigitSubtractionWork()
        {
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('0');

            Assert.That(_controller.GetOutput(), Is.EqualTo("91"));
        }


        [Test]
        public void DoesNegativeFirstDigitSubtractionWork()
        {
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('8');

            Assert.That(_controller.GetOutput(), Is.EqualTo("-17"));
        }

        [Test]
        public void DoesNegativeLastDigitSubtractionWork()
        {
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('8');

            Assert.That(_controller.GetOutput(), Is.EqualTo("99"));
        }


        [Test]
        public void DoesNegativeLastDigitAdditionWork()
        {
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('+');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('8');

            Assert.That(_controller.GetOutput(), Is.EqualTo("83"));
        }

        [Test]
        public void DoesNegativeFirstDigitAdditionWork()
        {
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('+');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('8');

            Assert.That(_controller.GetOutput(), Is.EqualTo("9"));
        }


        [Test]
        public void DoesNegativePositiveDigitMultiplicationWork()
        {
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('8');

            Assert.That(_controller.GetOutput(), Is.EqualTo("-162"));
        }

        [Test]
        public void DoesNegativeNegativeDigitMultiplicationWork()
        {
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('8');

            Assert.That(_controller.GetOutput(), Is.EqualTo("72"));
        }

        [Test]
        public void DoesPositiveNegativeDigitMultiplicationWork()
        {
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('8');

            Assert.That(_controller.GetOutput(), Is.EqualTo("-72"));
        }

        [Test] public void DoesMultipleDigitMultiplicationWork()
        {
            _controller.AcceptCharacter('1'); 
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('8');

            Assert.That(_controller.GetOutput(), Is.EqualTo("180"));
        }

        [Test]
        public void DoesFirstZeroDigitMultiplicationWork()
        {
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('8');

            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
        }


        [Test]
        public void DoesLastZeroDigitMultiplicationWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('0');

            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
        }

        [Test]
        public void DoesLastOneDigitMultiplicationWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('1');

            Assert.That(_controller.GetOutput(), Is.EqualTo("10"));
        }

        [Test]
        public void DoesFirstOneDigitMultiplicationWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('8');

            Assert.That(_controller.GetOutput(), Is.EqualTo("18"));
        }


        [Test]
        public void DoesLargeDigitMultiplicationWork()
        {
            _controller.AcceptCharacter('1'); 
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');

            Assert.That(_controller.GetOutput(), Is.EqualTo("110889"));
        }

        [Test]
        public void DoesVeryLargeDigitMultiplicationWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('*');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');

            Assert.That(_controller.GetOutput(), Is.EqualTo("111998888001"));
        }

        // 
        [Test]
        public void DoesNegativePositiveDigitDivisionWork()
        {
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('3');
            _controller.AcceptCharacter('3');

            Assert.That(_controller.GetOutput(), Is.EqualTo("-3"));
        }

        [Test]
        public void DoesNegativeNegativeDigitDivisionWork()
        {
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('1');

            Assert.That(_controller.GetOutput(), Is.EqualTo("9"));
        }

        [Test]
        public void DoesPositiveNegativeDigitDivisionWork()
        {
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('-');
            _controller.AcceptCharacter('3');

            Assert.That(_controller.GetOutput(), Is.EqualTo("-3"));
        }

        [Test]
        public void DoesMultipleDigitDivisionWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('8');

            Assert.That(_controller.GetOutput(), Is.EqualTo("180"));
        }

        [Test]
        public void DoesFirstZeroDigitDivisionWork()
        {
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('8');

            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
        }


        [Test]
        public void DoesLastZeroDigitDivisionWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('0');

            Assert.That(_controller.GetOutput(), Is.EqualTo("ERROR"));
        }

        [Test]
        public void DoesLastOneDigitDivisionWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('1');

            Assert.That(_controller.GetOutput(), Is.EqualTo("1"));
        }

        [Test]
        public void DoesFirstOneDigitDivisionWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('1');

            Assert.That(_controller.GetOutput(), Is.EqualTo("1"));
        }


        [Test]
        public void DoesLargeDigitDivisionWork()
        {
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('1');

            Assert.That(_controller.GetOutput(), Is.EqualTo("9"));
        }

        [Test]
        public void DoesVeryLargeDigitDivisionWork()
        {
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('8');
            _controller.AcceptCharacter('8');
            _controller.AcceptCharacter('8');
            _controller.AcceptCharacter('8');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('0');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('/');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
            _controller.AcceptCharacter('9');
     
            Assert.That(_controller.GetOutput(), Is.EqualTo("111999"));
        }



    }
}
