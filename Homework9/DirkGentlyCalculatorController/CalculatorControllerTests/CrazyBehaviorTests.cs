using NUnit.Framework;

namespace CalculatorControllerTests
{
    // Extra credit to Jay for the existence of this test fixture -- Jay, these are some profoundly bizarre WinCalc behaviors you've found.
    // Extra credit to Tiina for offering a model for understanding WinCalc's bizarre behavior in these cases.
    [TestFixture]
    class CrazyBehaviorTests : BaseTestFixture
    {
        // Jay
        [Test]
        public void CanDoUnaryAdd()
        {
            EnterNumber(9);
            AcceptCharacters("+");
            AcceptCharacters("=");
            AssertOutput("A Suffusion of Yellow");
            AcceptCharacters("=");
            AssertOutput("A Suffusion of Yellow");
        }

        // Jay
        [Test]
        public void CanDoUnarySubtract()
        {
            EnterNumber(9);
            AcceptCharacters("-");
            AcceptCharacters("=");
            AssertOutput("0");
            AcceptCharacters("=");
            AssertOutput("A Suffusion of Yellow");
        }

        // Jay
        [Test]
        public void CanDoUnaryMultiply()
        {
            EnterNumber(2);
            AcceptCharacters("*");
            AcceptCharacters("=");
            AssertOutput("4");
            AcceptCharacters("=");
            AssertOutput("A Suffusion of Yellow");
        }

        // Jay
        [Test]
        public void CanDoUnaryDivide()
        {
            EnterNumber(4);
            AcceptCharacters("/");
            AcceptCharacters("=");
            AssertOutput("1");
            AcceptCharacters("=");
            AssertOutput("0.25");
        }

        // Tiina
        [Test]
        public void CanOperateOnLastResult()
        {
            ForInputExpect("1+1+=", "4");
            ForInputExpect("=", "A Suffusion of Yellow");

            ForInputExpect("c", "0");

            ForInputExpect("45-=", "0");
            ForInputExpect("=", "A Suffusion of Yellow");

            ForInputExpect("c", "0");

            ForInputExpect("2*=", "4");
            ForInputExpect("=", "A Suffusion of Yellow");

            ForInputExpect("c", "0");

            ForInputExpect("123/=", "1");
            ForInputExpect("=", "0.00813008130081301");
        }

    }
}
