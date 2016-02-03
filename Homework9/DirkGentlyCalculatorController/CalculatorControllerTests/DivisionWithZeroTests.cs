using NUnit.Framework;

namespace CalculatorControllerTests
{
    [TestFixture]
    class DivisionWithZeroTests : BaseTestFixture
    {
        // Ahsan, Alex, Bryan, Jay, Michael, Paul, Su, Tammy, Tiina, Yana
        [Test]
        public void CanNotDivideByZero()
        {
            ForInputExpect("5/0=", "Cannot divide by zero");
        }

        // Ahsan, Jay, Jeff, Michael, Tammy
        [Test]
        public void CanDivideZeroByAnyNumberExceptZero()
        {
            ForInputExpect("0/1725=", "0");
        }

        [Test]
        public void CannotDivideZeroByZero()
        {
            ForInputExpect("0/0=", "Result is undefined");
        }


        // Tiina, making sure that we don't falsely give the "divide by zero" error if a valid number is being entered
        // Kudos to Tiina for thinking of a really tricky test case.  :-)
        [Test]
        public void CanDivideByNumberWithLeadingZero()
        {
            ForInputExpect("3/01=", "3");  // the zero should be ignored and not make the calculation fail
        }

    }
}
