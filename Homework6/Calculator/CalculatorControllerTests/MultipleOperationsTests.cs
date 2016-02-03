using NUnit.Framework;

namespace CalculatorControllerTests
{
    class MultipleOperationsTests : BaseTestFixture
    {
        // Jay, Michael, Tiina
        [Test]
        public void CanPerformMultipleOperations()
        {
            EnterNumber(9);
            AcceptCharacters("+");
            EnterNumber(7);
            AcceptCharacters("*");
            EnterNumber(18);
            AcceptCharacters("-");
            EnterNumber(3);
            AcceptCharacters("/");
            EnterNumber(5);
            AcceptCharacters("=");
            AssertOutput("57");
        }

        [Test]
        public void CanPerformMultipleOperationsTwoLineForm()
        {
            AcceptCharacters("9+7*18-3/5=");
            AssertOutput("57");
        }

        [Test]
        public void CanPerformMultipleOperationsSingleLineForm()
        {
            ForInputExpect("9+7*18-3/5=", "57");
        }
        
        // Tammy
        [Test]
        public void PlusDisplaysIntermediateResults()
        {
            EnterNumber(23);
            AssertOutput("23");
            AcceptCharacters("+");
            EnterNumber(9);
            AcceptCharacters("+");
            AssertOutput("32");
            EnterNumber(5);
            AcceptCharacters("=");
            AssertOutput("37");
        }

        // Tammy
        [Test]
        public void MinusDisplaysIntermediateResults()
        {
            EnterNumber(23);
            AssertOutput("23");
            AcceptCharacters("-");
            EnterNumber(9);
            AcceptCharacters("-");
            AssertOutput("14");
            EnterNumber(5);
            AcceptCharacters("=");
            AssertOutput("9");
        }

        // Tammy
        [Test]
        public void CanCombineAdditionAndSubtraction()
        {
            EnterNumber(23);
            AssertOutput("23");
            AcceptCharacters("+");
            EnterNumber(9);
            AcceptCharacters("-");
            AssertOutput("32");
            EnterNumber(5);
            AcceptCharacters("=");
            AssertOutput("27");
        }

        // Tammy, Tiina
        [Test]
        public void MultiplyNegativeDisplaysCorrectly()
        {
            ForInputExpect("-9", "9"); // should not show negative sign yet
            ForInputExpect("*", "-9"); // now the negative portion is applied
            ForInputExpect("5=", "-45");
        }

        // Ahsan, Paul, Yana
        [Test]
        public void CanAddOneNegativeAndAnotherPositiveNumber()
        {
            AcceptCharacters("-5+8=");
            AssertOutput("3");
        }

        // Tiina
        [Test]
        public void CanStartNewComputationAfterEquals()
        {
            //  Omitting use of Clear key - assumption is new number after equals is start of new computation
            //  3+4=4+5=   should yield 7 then 9
            ForInputExpect("3+4=", "7");
            ForInputExpect("4+5=", "9");
        }

        // Tiina
        [Test]
        public void CanStartMultiDigitComputationAfterEquals()
        {
            ForInputExpect("2342-342=", "2000");
            ForInputExpect("6000/30=", "200");
        }
    }
}
