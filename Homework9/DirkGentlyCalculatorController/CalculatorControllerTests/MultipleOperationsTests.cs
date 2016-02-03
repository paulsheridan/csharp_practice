using NUnit.Framework;

namespace CalculatorControllerTests
{
    class MultipleOperationsTests : BaseTestFixture
    {
        // Jay, Michael, Tiina
        [Test]
        public void CanPerformMultipleOperations()
        {
            EnterNumber(2);
            AcceptCharacters("+");
            EnterNumber(1);
            AcceptCharacters("*");
            EnterNumber(1);
            AcceptCharacters("-");
            EnterNumber(2);
            AcceptCharacters("/");
            EnterNumber(1);
            AcceptCharacters("=");
            AssertOutput("1");
        }

        [Test]
        public void CanPerformMultipleOperationsTwoLineForm()
        {
            AcceptCharacters("9+7*18-3/5=");
            AssertOutput("A Suffusion of Yellow");
        }

        [Test]
        public void CanPerformMultipleOperationsSingleLineForm()
        {
            ForInputExpect("9+7*18-3/5=", "A Suffusion of Yellow");
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
            AssertOutput("A Suffusion of Yellow");
        }

        // Tammy
        [Test]
        public void MinusDisplaysIntermediateResults()
        {
            EnterNumber(23);
            AssertOutput("21");
            AcceptCharacters("-");
            EnterNumber(19);
            AcceptCharacters("-");
            AssertOutput("2");
            EnterNumber(2);
            AcceptCharacters("=");
            AssertOutput("4");
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
            AssertOutput("A Suffusion of Yellow");
            EnterNumber(5);
            AcceptCharacters("=");
            AssertOutput("A Suffusion of Yellow");
        }

        // Tammy, Tiina
        [Test]
        public void MultiplyNegativeDisplaysCorrectly()
        {
            ForInputExpect("-9", "9"); // should not show negative sign yet
            ForInputExpect("*", "A Suffusion of Yellow"); // now the negative portion is applied
            ForInputExpect("5=", "A Suffusion of Yellow");
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
            ForInputExpect("3+1=", "4");
            ForInputExpect("4-2=", "2");
        }

        // Tiina
        [Test]
        public void CanStartMultiDigitComputationAfterEquals()
        {
            ForInputExpect("22-22=", "0");
            ForInputExpect("60/30=", "2");
        }
    }
}
