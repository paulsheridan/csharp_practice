using NUnit.Framework;
using Calculator;

namespace CalculatorControllerTests
{
    [TestFixture]
    public class TammyNumberManipulationTests
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
        public void CanSubtractSingleDigits()
        {


//            Assert.That(_controller.CanEnterSingleDigit(5), Is.EqualTo(2)); // i want to show that 5 - 3 = 2... that will be in the code....


        }
        [Test]
        public void CanSubtractMultipleDigits()
        {

//            Assert.That(_controller.CanEnterMultipleDigits(13), Is.EqualTo(2)); //i want to show that if you enter multiple digits then subtract (which will be in the code) 11, the answer will be 2.
//            Assert.That(_controller.CanEnterMultipleDigits(97), Is.EqualTo(10));//same story, i want to show that multiple digits '97' minus a multiple digit '87', will result in '10'.

        }
        [Test]
        public void CanAddSingleDigits()
        {


//            Assert.That(_controller.CanEnterSingleDigit(2), Is.EqualTo(5)); // i want to show that 2 +  3 = 5... that will be in the code....


        }
        [Test]
        public void CanAddMultipleDigits()
        {

//            Assert.That(_controller.CanEnterMultipleDigits(13), Is.EqualTo(20)); //i want to show that if you enter multiple digits then add (which will be in the code) 7, the answer will be 20.
//            Assert.That(_controller.CanEnterMultipleDigits(27), Is.EqualTo(40));//same story, i want to show that multiple digits '27' added to a multiple digit '13', will result in '40'.

        }
        [Test]
        public void CanMultiplySingleDigits()
        {


//            Assert.That(_controller.CanEnterSingleDigit(2), Is.EqualTo(6)); // i want to show that 2 *  3 = 6... that will be in the code....


        }
        [Test]
        public void CanMultiplyMultipleDigits()
        {

//            Assert.That(_controller.CanEnterMultipleDigits(5), Is.EqualTo(20)); 
//            Assert.That(_controller.CanEnterMultipleDigits(27), Is.EqualTo(40));

        }
        [Test]
        public void CanDivideSingleDigits()
        {


//            Assert.That(_controller.CanEnterSingleDigit(6), Is.EqualTo(2)); // i want to show that 6 *  3 = 2... that will be in the code....


        }
        public void CanDivideMultipleDigits()
        {

//            Assert.That(_controller.CanEnterMultipleDigits(100), Is.EqualTo(10)); 
//            Assert.That(_controller.CanEnterMultipleDigits(40), Is.EqualTo(10));

        }
    }
}
