using NUnit.Framework;

namespace CalculatorControllerTests
{
    class MultiplicationTests : BaseTestFixture
    {
        // Michael, Su, Tammy, Tiina
        [Test]
        public void CanDoMultiplication()
        {
            ForInputExpect("4*5=", "20");
        }

        // Ahsan, Jay, Michael, Paul
        [Test]
        public void CanDoMultiDigitMultiplication()
        {
            AcceptCharacters("25*69=");
            AssertOutput("1725");
        }

        // Ahsan, Tiina
        [Test]
        public void CanMultiplyNegative()
        {
            ForInputExpect("-7*3=", "-21");
        }

        // Tiina
        [Test]
        public void CanHandleUnaryMultiply()
        {
            ForInputExpect("*9=", "0");  // implied zero: 0*9=0
        }

        // Ahsan
        [Test]
        public void CanMultiplyZeroBySomething()
        {
            ForInputExpect("0*9=", "0");
        }

        // Ahsan, Michael, Paul, Tammy, Yana
        [Test]
        public void CanMultiplyByZero()
        {
            ForInputExpect("9*0=", "0");
        }

        // Ahsan
        [Test]
        public void DoesLargeDigitMultiplicationWork()
        {
            ForInputExpect("111*999=", "110889");
        }

        // Ahsan
        [Test]
        public void DoesVeryLargeDigitMultiplicationWork()
        {
            ForInputExpect("111999*999999=", "111998888001");
        }
    }
}
