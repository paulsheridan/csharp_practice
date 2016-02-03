using NUnit.Framework;
using Calculator;

namespace CalculatorControllerTests
{
    [TestFixture]
    public class TiinaTests
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
        public void InitialStateIsZero()
        {
            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
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
        public void CanEnterEachDigit()
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
            _controller.AcceptCharacter('0');
            Assert.That(_controller.GetOutput(), Is.EqualTo("1234567890")); // overflow yet???
            _controller.AcceptCharacter('C');
            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
        }

        [Test]
        public void CanIgnoreLeadingZeros()
        {
            _controller.AcceptCharacter('0');
            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
            _controller.AcceptCharacter('2');
            Assert.That(_controller.GetOutput(), Is.EqualTo("2")); // not "02"
        }

        [Test]
        public void CanDoBasicAdd() //    +  -  *  /  =  C
        {
            _controller.AcceptCharacter('2');
            Assert.That(_controller.GetOutput(), Is.EqualTo("2"));
            _controller.AcceptCharacter('+');
            Assert.That(_controller.GetOutput(), Is.EqualTo("2"));
            _controller.AcceptCharacter('6');
            Assert.That(_controller.GetOutput(), Is.EqualTo("6"));
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("8"));
        }

        [Test]
        public void CanDoMultipleDigitAdd() //    +  -  *  /  =  C
        {
            _controller.AcceptCharacter('2');
            Assert.That(_controller.GetOutput(), Is.EqualTo("2"));
            _controller.AcceptCharacter('8');
            Assert.That(_controller.GetOutput(), Is.EqualTo("28"));
            _controller.AcceptCharacter('+');
            Assert.That(_controller.GetOutput(), Is.EqualTo("28"));
            _controller.AcceptCharacter('9');
            Assert.That(_controller.GetOutput(), Is.EqualTo("9"));
            _controller.AcceptCharacter('1');
            Assert.That(_controller.GetOutput(), Is.EqualTo("91"));
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("119"));
        }


        [Test]
        public void CanDoBasicSubtract() //    +  -  *  /  =  C
        {
            _controller.AcceptCharacter('7');
            Assert.That(_controller.GetOutput(), Is.EqualTo("7"));
            _controller.AcceptCharacter('-');
            Assert.That(_controller.GetOutput(), Is.EqualTo("7"));
            _controller.AcceptCharacter('3');
            Assert.That(_controller.GetOutput(), Is.EqualTo("3"));
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("4"));
        }

        [Test]
        public void CanDoUnarySubtract() //    +  -  *  /  =  C
        {
            _controller.AcceptCharacter('-');
            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
            _controller.AcceptCharacter('9');
            Assert.That(_controller.GetOutput(), Is.EqualTo("9"));
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("-9"));
        }
               
        [Test]
        public void CanGoNegativeOnSubtract() //    +  -  *  /  =  C
        {
            _controller.AcceptCharacter('7');
            Assert.That(_controller.GetOutput(), Is.EqualTo("7"));
            _controller.AcceptCharacter('-');
            Assert.That(_controller.GetOutput(), Is.EqualTo("7"));
            _controller.AcceptCharacter('9');
            Assert.That(_controller.GetOutput(), Is.EqualTo("9"));
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("-2"));
        }

        [Test]
        public void CanDoBasicMultiply() //    +  -  *  /  =  C
        {
            _controller.AcceptCharacter('4');
            Assert.That(_controller.GetOutput(), Is.EqualTo("4"));
            _controller.AcceptCharacter('*');
            Assert.That(_controller.GetOutput(), Is.EqualTo("4"));
            _controller.AcceptCharacter('5');
            Assert.That(_controller.GetOutput(), Is.EqualTo("5"));
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("20"));
        }

        [Test]
        public void CanHandleUnaryMultiply() //    +  -  *  /  =  C
        {
            _controller.AcceptCharacter('*');
            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
            _controller.AcceptCharacter('9');
            Assert.That(_controller.GetOutput(), Is.EqualTo("9"));
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
        }

        [Test]
        public void CanMultiplyNegative()
        {
            _controller.AcceptCharacter('-');
            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
            _controller.AcceptCharacter('9');
            Assert.That(_controller.GetOutput(), Is.EqualTo("9"));
            _controller.AcceptCharacter('*');
            Assert.That(_controller.GetOutput(), Is.EqualTo("-9"));
            _controller.AcceptCharacter('5');
            Assert.That(_controller.GetOutput(), Is.EqualTo("5"));
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("-45"));
        }

        [Test]
        public void CanDoBasicDivide()
        {
            _controller.AcceptCharacter('8');
            Assert.That(_controller.GetOutput(), Is.EqualTo("8"));
            _controller.AcceptCharacter('/');
            Assert.That(_controller.GetOutput(), Is.EqualTo("8"));
            _controller.AcceptCharacter('2');
            Assert.That(_controller.GetOutput(), Is.EqualTo("2"));
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("4"));
        }

        [Test]
        public void CanHandleUnaryDivide()
        {
            _controller.AcceptCharacter('/');
            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
            _controller.AcceptCharacter('9');
            Assert.That(_controller.GetOutput(), Is.EqualTo("9"));
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
        }

        [Test]
        public void CatchDivideByZero()
        {
            _controller.AcceptCharacter('8');
            Assert.That(_controller.GetOutput(), Is.EqualTo("8"));
            _controller.AcceptCharacter('/');
            Assert.That(_controller.GetOutput(), Is.EqualTo("8"));
            _controller.AcceptCharacter('0');
            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("Error:Divide by 0"));  // or some other shorter message
        }

        [Test]
        public void CatchNotDivideByZero()
        {
            _controller.AcceptCharacter('8');
            Assert.That(_controller.GetOutput(), Is.EqualTo("8"));
            _controller.AcceptCharacter('/');
            Assert.That(_controller.GetOutput(), Is.EqualTo("8"));
            _controller.AcceptCharacter('0');
            Assert.That(_controller.GetOutput(), Is.EqualTo("0"));
            _controller.AcceptCharacter('1');
            Assert.That(_controller.GetOutput(), Is.EqualTo("1"));
            _controller.AcceptCharacter('=');
            Assert.That(_controller.GetOutput(), Is.EqualTo("8"));
        }

        //  CanPerformMultipleOperations   15+3-8*20=
        //  CanAddLargeNumbers
        //  CanSubtractLargeNumbers
        //  CanDivideLargeNumbers
        //  CanMultiplyLargeNumbers
        //
        //
        //  Omitting use of Clear key - assumption is new number after equals is start of new computation
        //  3+4=4+5=   should yield 7 then 9

        // Nonstandard cases
        //  Understands +=  -=  *= and /=  as operating on last result
        //          1+2+= 6     any number -=  0        4*= 16     any number /=  1

        //  CanIgnoreExtraneousOperators  1+2+++= (6) ;   3-+4  (7)
        //   
        //  CanIgnoreAbsenceOfOperators   13=14=59 (13 then 14 then 59)   

        // Boundary Conditions and overflows

        [Test]
        public void CanOverflowMaxInt()
        {
            // set first value to just under max int, Add a reasonable value to it to force it over max int
            // check that the return value now is in Scientific Notation
            // 
            // Do the same for the number of display characters on output screen (8-10 chars??)
        }

        [Test]
        void CanUnderflowOnDivide()
        {
            //  Divide until the number extends past the number of chars available on output screen and then
            //  make sure it is converted to Scientific Notation
        }


        [Test]
        public void CanOverflowAtCorrectValue()
        {
        }

              
    }
}
