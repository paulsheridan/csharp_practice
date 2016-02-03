using NUnit.Framework;

namespace CalculatorControllerTests
{
    [TestFixture]
    class NumberEntryTests : BaseTestFixture
    {
        [Test]
        public void CanEnterSingleDigitNumber()
        {
            EnterNumber(3);
            AssertOutput("3");
        }

        // Tammy
        [Test]
        public void MultipleZerosAreIgnored()
        {
            AcceptCharacters("000");
            AssertOutput("0");
        }

        // Tammy, Tiina
        [Test]
        public void CanIgnoreLeadingZeros()
        {
            EnterNumber(0);
            AssertOutput("0");
            EnterNumber(2);
            AssertOutput("2"); // not "02"
        }


        // Michael, Mike, Su, Tiina, Yana
        public void DigitsAreAddedToTheRightOfTheCurrentValue()
        {
            // Abstract idea in English:
            // When I enter "1" and then "3" and then "7", the calculator displays "1" and then "13" and then "137".

            // Psedocode, often following the "when I/then" paradigm
            // When I: enter "1"
            // Then: the calculator should say "1"
            // When I: enter "3"
            // Then: the calculator should say "13"
            // When I: enter "7"
            // Then: the calculator should say "137"

            // Actual test code, where each line (approximately) corresponds to a line of the pseudocode
//            EnterNumber(1);
//            AssertOutput("1");
//            EnterNumber(3);
//            AssertOutput("13");
//            EnterNumber(7);
//            AssertOutput("137");

            // Shortened yet again with Tiina's one-liner input/expected output method
            ForInputExpect("1", "1");
            ForInputExpect("3", "13");
            ForInputExpect("7", "137");
        }            

        // Jay, Jeff, Michael, Mike, Tiina
        public void CanEnterEachDigit()
        {
            ForInputExpect("1", "1");
            ForInputExpect("2", "12");
            ForInputExpect("3", "123");
            ForInputExpect("4", "1234");
            ForInputExpect("5", "12345");
            ForInputExpect("6", "123456");
            ForInputExpect("7", "1234567");
            ForInputExpect("8", "12345678");
            ForInputExpect("9", "123456789");
            ForInputExpect("0", "1234567890");
        }

        // Tammy
        [Test]
        public void CanEnterUpTo15DigitsAndNoMore()
        {
            AcceptCharacters("123456789123456");
            AssertOutput("123456789123456");
            AcceptCharacters("7");
            AssertOutput("123456789123456");
        }
    }
}
