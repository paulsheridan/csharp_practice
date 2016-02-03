using NUnit.Framework;

namespace CalculatorControllerTests
{
    class LargeNumberTests : BaseTestFixture
    {
        // Tiina
        [Test]
        public void CanEnterValueNearMaxInt()
        {
            ForInputExpect((int.MaxValue - 10) + "=", (int.MaxValue - 10).ToString());
        }

        // Tiina
        [Test]
        public void CanAddNearMaxInt()
        {
            ForInputExpect((int.MaxValue - 10) + "+9=", (int.MaxValue - 1).ToString());
        }

        // Tiina
        [Test]
        public void CanSubtractLargeNumbers()
        {
            ForInputExpect(int.MaxValue + "-" + (int.MaxValue - 1789) + "=", "1789");
            ForInputExpect("c", "0");
            ForInputExpect((int.MaxValue - 4567) + "-" + (int.MaxValue).ToString() + "=", "-4567");
        }

        // Tiina, modified by Mickey with insight from Tammy
        [Test]
        public void CanDivideLargeNumbers()
        {
            ForInputExpect("999999999999999/10000=", "99999999999.9999");
        }

        // Tiina, modified by Mickey
        [Test]
        public void CanDivideLargeNumbersWithDecimalResult()
        {
            ForInputExpect("456456456/10000=", "45645.6456");
        }


        // This is the "long form" of "CanExceedMaxInt()", without the helper functions.
        // When you find yourself writing a test like this, it's a good indicator that you may
        // want to consider writing some helper functions to handle the "busy-work" of the
        // test (such as entering each character of a number manually).
        [Test]
        public void CanExceedMaxIntLongForm()
        {
            // Enter Int.MaxValue
            Controller.AcceptCharacter('2');
            Controller.AcceptCharacter('1');
            Controller.AcceptCharacter('4');
            Controller.AcceptCharacter('7');
            Controller.AcceptCharacter('4');
            Controller.AcceptCharacter('8');
            Controller.AcceptCharacter('3');
            Controller.AcceptCharacter('6');
            Controller.AcceptCharacter('4');
            Controller.AcceptCharacter('7');

            // Addition
            Controller.AcceptCharacter('+');

            // Enter Int.MaxValue again
            Controller.AcceptCharacter('2');
            Controller.AcceptCharacter('1');
            Controller.AcceptCharacter('4');
            Controller.AcceptCharacter('7');
            Controller.AcceptCharacter('4');
            Controller.AcceptCharacter('8');
            Controller.AcceptCharacter('3');
            Controller.AcceptCharacter('6');
            Controller.AcceptCharacter('4');
            Controller.AcceptCharacter('7');

            // Display the answer
            Controller.AcceptCharacter('=');

            const long expectedResult = (long)int.MaxValue + int.MaxValue;
            Assert.AreEqual(expectedResult.ToString(), Controller.GetOutput());
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
        public void CanDisplayLargerValuesThanCanBeEntered()
        {
            ForInputExpect("999999999999999+999999999999999=", "2E+15");
        }

        // Tammy
        [Test]
        public void CanMultiplyVeryLargeValues()
        {
            ForInputExpect("999999999999999*999999999999999=", "9.99999999999998E+29");
        }

        // We can't actually do this test.  long.MaxValue is 9223372036854775807, which is more than 16 characters.  
        // WinCalc only allows us to enter numbers up to 16 digits.
//        [Test]
//        public void CanExceedMaxLong()
//        {
//            EnterNumber(long.MaxValue);
//            AcceptCharacters("+");
//            EnterNumber(long.MaxValue);
//            AcceptCharacters("=");
//
//            Decimal expectedResult = new Decimal(long.MaxValue) + new decimal(long.MaxValue);
//
//            AssertOutput(expectedResult.ToString());
//        }
    }
}
