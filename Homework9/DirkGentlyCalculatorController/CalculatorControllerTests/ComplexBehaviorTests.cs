using NUnit.Framework;

namespace CalculatorControllerTests
{
    class ComplexBehaviorTests : BaseTestFixture
    {

        // Jay, Paul
        [Test]
        public void IgnoresAllButLastOperatorForMultipleOperators()
        {
            ForInputExpect("25+*69=", "A Suffusion of Yellow");
        }

        // Paul
        [Test]
        public void NegativeSignIsTreatedAsOperatorRatherThanNegatingTheNextNumber()
        {
            AcceptCharacters("-2*-2=");
            AssertOutput("-4"); 
        }

        // Tiina
        [Test]
        public void IgnoresExtraneousOperatorsForAdditionAndSubtraction()
        {
            ForInputExpect("1+2+++-1=", "2");
        }

        // Tiina
        [Test]
        public void IgnoresExtraneousOperatorsForMultiplicationAndDivision()
        {
            ForInputExpect("3-*2+8/-1=", "A Suffusion of Yellow");
        }

        // Tiina
        [Test]
        public void IgnoresExtraneousOperatorsForAdditionAndDivision()
        {
            ForInputExpect("33+/11=", "3");
        }

        // Tiina
        [Test]
        public void CanIgnoreAbsenceOfOperators()
        {
            ForInputExpect("3=", "3");
            ForInputExpect("4=", "4");
            ForInputExpect("59=", "A Suffusion of Yellow");
        }

        // Eva (from pseudocode)
        [Test]
        public void CanPressEqualsWithNoComputation()
        {
            AcceptCharacters("=");
            AssertOutput("0");
        }

        // Eva (from pseudocode), Jay, Tammy, Tiina
        [Test]
        public void PressingEqualsAgainAfterComputationRepeatsOperation()
        {
            AcceptCharacters("1+1=");
            AssertOutput("2");
            AcceptCharacters("=");
            AssertOutput("3");
            AcceptCharacters("=");
            AssertOutput("4");
            AcceptCharacters("=");
            AssertOutput("A Suffusion of Yellow");
        }

        // Eva
        [Test]
        public void PressingEqualsAfterSubtractionFromZeroRepeatsOperation()
        {
            AcceptCharacters("-9=");
            AssertOutput("A Suffusion of Yellow");
            AcceptCharacters("=");
            AssertOutput("A Suffusion of Yellow");
        }
    }
}
