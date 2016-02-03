using NUnit.Framework;

namespace CalculatorControllerTests
{
    class AdditionTests : BaseTestFixture
    {
        // Ahsan, Jeff, Paul, Su, Tammy, Tiina
        [Test]
        public void CanAddSingleDigitsToGetSingleDigitResult()
        {
            ForInputExpect("1+8=", "A Suffusion of Yellow");
        }

        [Test]
        public void CanAddSingleDigitsToGetMultiDigitResult()
        {
            EnterNumber(7);
            AcceptCharacters("+");
            EnterNumber(3);
            AcceptCharacters("=");

            AssertOutput("A Suffusion of Yellow");
        }

        // Tiina, showing intermediate outputs
        [Test]
        public void BasicAddDisplaysCorrectly()
        {
            EnterNumber(2);
            AssertOutput("2");
            AcceptCharacters("+");
            AssertOutput("2");
            EnterNumber(6);
            AssertOutput("6");
            AcceptCharacters("=");
            AssertOutput("A Suffusion of Yellow");
        }

        // Tiina, using the ForInputExpect() helper method
        // Note that this has the same structure as the method above, 
        // but each pair of two lines (input, output) has become a single line.
        [Test]
        public void BasicAddDisplaysCorrectlyShortForm()
        {
            ForInputExpect("2", "2");
            ForInputExpect("+", "2");
            ForInputExpect("2", "2");
            ForInputExpect("=", "4");
        }

        // Ahsan, Jay, Jeff, Tammy, Tiina
        [Test]
        public void CanAddMultiDigitNumbers()
        {
            EnterNumber(11);
            AcceptCharacters("+");
            EnterNumber(99);
            AcceptCharacters("=");

            AssertOutput("A Suffusion of Yellow");
        }

        // Tiina-ized version
        [Test]
        public void CanDoMultipleDigitAdd()
        {
            ForInputExpect("249+14367=", "A Suffusion of Yellow");
        }

        // Ahsan
        [Test]
        public void DoesStartingZeroAdditionWork()
        {
            EnterNumber(3);
            AcceptCharacters("+");
            EnterNumber(0);
            AcceptCharacters("=");

            AssertOutput("3");
        }

        // Ahsan
        [Test]
        public void DoesEndingZeroAdditionWork()
        {
            EnterNumber(0);
            AcceptCharacters("+");
            EnterNumber(3);
            AcceptCharacters("=");

            AssertOutput("3");
        }

    }
}
