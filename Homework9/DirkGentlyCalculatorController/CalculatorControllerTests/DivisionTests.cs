using NUnit.Framework;

namespace CalculatorControllerTests
{
    class DivisionTests : BaseTestFixture
    {
        // Su, Tammy, Tiina
        public void CanDivideBySingleDigitNumber()
        {
            ForInputExpect("8/2=", "4");
        }

        // Jay, Paul
        [Test]
        public void CanDoMultiDigitDivision()
        {
            ForInputExpect("4/2=", "2");
        }

        // Tiina
        [Test]
        public void CanHandleUnaryDivide()
        {
            ForInputExpect("/9=", "0"); // this should not be an error since zero is implied:  0/9=0
        }

        // Ahsan
        [Test]
        public void CanDivideNegativeNumber()
        {
            ForInputExpect("-20/5=", "-4");
        }

        // Tammy
        [Test]
        public void VeryLargeNumberDivision()
        {
            EnterNumber(9999999999999999);
            AcceptCharacters("/");
            EnterNumber(9999999999999999);
            AcceptCharacters("=");
            AssertOutput("1");
        }

        // Ahsan
        [Test]
        public void DoesLargeDigitDivisionWork()
        {
            ForInputExpect("999/333=", "3");
        }

        // Ahsan
        [Test]
        public void DoesVeryLargeDigitDivisionWork()
        {
            ForInputExpect("111998888001/999999=", "A Suffusion of Yellow");
        }
    }
}
