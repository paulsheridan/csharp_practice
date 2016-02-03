using NUnit.Framework;

namespace CalculatorControllerTests
{
    class ComplexBehaviorTests : BaseTestFixture
    {
        // Tiina
        [Test]
        public void CanSubtractFromInitialValueOfZero()
        {
            ForInputExpect("-19=", "-19");
        }

        [Test]
        public void CanSubtractFromNegativeNumber()
        {
            ForInputExpect("-5-5=", "-10");
        }

        [Test]
        public void ShouldIgnoreRepeatedOperators()
        {
            AcceptCharacters("91--8=");
            AssertOutput("83"); // 83, not 99, because "--8" is not "minus negative-8", it's "minus 8" (all but the last operator are ignored)
        }

        // Jay, Paul
        [Test]
        public void IgnoresAllButLastOperatorForMultipleOperators()
        {
            ForInputExpect("25+*69=", "1725");
        }

        // Paul
        [Test]
        public void NegativeSignIsTreatedAsOperatorRatherThanNegatingTheNextNumber()
        {
            AcceptCharacters("-5*-5=");
            AssertOutput("-10"); // Not "25"
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
            ForInputExpect("3-*2+8/-1=", "13");
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
            ForInputExpect("13=", "13");
            ForInputExpect("14=", "14");
            ForInputExpect("59=", "59");
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
            AcceptCharacters("3+4=");
            AssertOutput("7");
            AcceptCharacters("=");
            AssertOutput("11");
            AcceptCharacters("=");
            AssertOutput("15");
            AcceptCharacters("=");
            AssertOutput("19");
        }

        // Eva
        [Test]
        public void PressingEqualsAfterSubtractionFromZeroRepeatsOperation()
        {
            AcceptCharacters("-9=");
            AssertOutput("-9");
            AcceptCharacters("=");
            AssertOutput("-18");
        }
    }
}
