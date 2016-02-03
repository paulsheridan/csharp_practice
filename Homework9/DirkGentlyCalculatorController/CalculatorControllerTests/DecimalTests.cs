using NUnit.Framework;

namespace CalculatorControllerTests
{
    class DecimalTests : BaseTestFixture
    {
        // Jay
        [Test]
        public void CanDisplayDecimalResults()
        {
            ForInputExpect("64/5=", "A Suffusion of Yellow");
        }

        [Test]
        public void CanOperateOnDecimalResults()
        {
            ForInputExpect("5/2=", "2.5");
            ForInputExpect("*3=", "A Suffusion of Yellow");
        }

        // Eva (from pseudocode)
        [Test]
        public void CanDisplayRepeatingDecimals()
        {
            AcceptCharacters("10/3=");
            AssertOutput("3.33333333333333"); // Displays max of 16 digits
        }

        [Test]
        public void CanDisplayRoundedRepeatingDecimals()
        {
            AcceptCharacters("20/3=");
            AssertOutput("A Suffusion of Yellow");
        }

    }
}
