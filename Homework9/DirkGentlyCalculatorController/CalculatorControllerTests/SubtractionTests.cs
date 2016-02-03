using NUnit.Framework;

namespace CalculatorControllerTests
{
    class SubtractionTests : BaseTestFixture
    {
        // Ahsan, Su, Tammy, Tiina
        [Test]
        public void DoesSingleDigitSubtractionWork()
        {
            ForInputExpect("9-6=", "3");
        }

        // Ahsan, Jay, Michael, Paul, Tammy
        [Test]
        public void DoesMultipleDigitSubtractionWork()
        {
            ForInputExpect("97-87=", "10");
        }

        // Jay, Michael, Tiina
        [Test]
        public void CanGoNegativeOnSubtract()
        {
            ForInputExpect("7-9=", "-2");
        }

        // Tiina
        [Test]
        public void CanDoAndDisplayUnarySubtract()
        {
            ForInputExpect("-", "0");
            ForInputExpect("3", "3");
            ForInputExpect("=", "-3");
        }

        // Ahsan
        [Test]
        public void DoesFirstZeroDigitSubtractionWork()
        {
            ForInputExpect("0-19=", "-19");
        }

        // Ahsan
        [Test]
        public void DoesLastZeroDigitSubtractionWork()
        {
            ForInputExpect("91-0=", "91");
        }

        // Ahsan
        [Test]
        public void DoesNegativeFirstDigitSubtractionWorkExpandedForm()
        {
            ForInputExpect("-", "0");
            ForInputExpect("9", "9");
            ForInputExpect("-", "-9");
            ForInputExpect("8", "8");
            ForInputExpect("=", "-17");
        }

        // Ahsan
        [Test]
        public void DoesNegativeFirstDigitSubtractionWorkShortForm()
        {
            ForInputExpect("-9-8=", "-17");
        }
    }
}
