using System;
using NUnit.Framework;

namespace CalculatorControllerTests
{
    // By adding ": BaseTestFixture" here, I cause this class to "inherit" its behavior from the
    // class BaseTestFixture.  Thus, I can call the methods "EnterNumber()" and "AssertOutput()" as
    // if they were my own methods.
    //
    // If you want to use these same methods in your test fixtures, you should similarly add
    // ": BaseTestFixture" to your test fixture class declarations.
    [TestFixture]
    public class MickeySimpleNumberEntryTests : BaseTestFixture
    {
        [Test]
        public void DigitsAreAddedToTheRightOfTheCurrentValue()
        {
            // Abstract idea in English:
            // When I enter "1" and then "3" and then "7", the calculator displays "1" and then "13" and then "137".

            // Pseudocode, often following the "when I/then" paradigm
            // When I: enter "1"
            // Then: the calculator should say "1"
            // When I: enter "3"
            // Then: the calculator should say "13"
            // When I: enter "7"
            // Then: the calculator should say "137"

            // Actual test code, where each line (approximately) corresponds to a line of the pseudocode
            EnterNumber(1);
            AssertOutput("1");
            EnterNumber(3);
            AssertOutput("13");
            EnterNumber(7);
            AssertOutput("137");
        }

        [Test]
        public void CanAddSmallNumbers()
        {
            EnterNumber(7);
            AcceptCharacters("+");
            EnterNumber(3);
            AcceptCharacters("=");

            AssertOutput("10");
        }

        [Test]
        public void PlusDisplaysIntermediateResultsLikeEquals()
        {
            EnterNumber(10);
            AcceptCharacters("+");
            EnterNumber(3);
            AcceptCharacters("+");

            AssertOutput("13");

            EnterNumber(15);

            AssertOutput("15");

            AcceptCharacters("=");

            AssertOutput("28");
        }

        // This is the "long form" of "CanExceedMaxInt()", without the helper functions.
        // When you find yourself writing a test like this, it's a good indicator that you may
        // want to consider writing some helper functions to handle the "busy-work" of the
        // test (such as entering each character of a number manually).
        [Test]
        public void CanExceedMaxIntLongForm()
        {
            // Enter Int.MaxValue
            _controller.AcceptCharacter('2');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('4');
            _controller.AcceptCharacter('7');
            _controller.AcceptCharacter('4');
            _controller.AcceptCharacter('8');
            _controller.AcceptCharacter('3');
            _controller.AcceptCharacter('6');
            _controller.AcceptCharacter('4');
            _controller.AcceptCharacter('7');

            // Addition
            _controller.AcceptCharacter('+');

            // Enter Int.MaxValue again
            _controller.AcceptCharacter('2');
            _controller.AcceptCharacter('1');
            _controller.AcceptCharacter('4');
            _controller.AcceptCharacter('7');
            _controller.AcceptCharacter('4');
            _controller.AcceptCharacter('8');
            _controller.AcceptCharacter('3');
            _controller.AcceptCharacter('6');
            _controller.AcceptCharacter('4');
            _controller.AcceptCharacter('7');

            const long expectedResult = (long)int.MaxValue + int.MaxValue;
            Assert.AreEqual(expectedResult.ToString(), _controller.GetOutput());
        }

        [Test]
        public void CanExceedMaxInt()
        {
            EnterNumber(int.MaxValue);
            AcceptCharacters("+");
            EnterNumber(int.MaxValue);
            AcceptCharacters("=");

            const long expectedResult = (long)int.MaxValue + int.MaxValue;
            AssertOutput(expectedResult.ToString());
        }

        [Test]
        public void CanExceedMaxLong()
        {
            EnterNumber(long.MaxValue);
            AcceptCharacters("+");
            EnterNumber(long.MaxValue);
            AcceptCharacters("=");

            Decimal expectedResult = new Decimal(long.MaxValue) + new decimal(long.MaxValue);

            AssertOutput(expectedResult.ToString());
        }
    }
}
