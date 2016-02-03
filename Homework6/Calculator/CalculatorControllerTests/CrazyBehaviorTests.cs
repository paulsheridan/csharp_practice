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
            AssertOutput("18");
            AcceptCharacters("=");
            AssertOutput("27");
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
            AssertOutput("-9");
        }

        // Jay
        [Test]
        public void CanDoUnaryMultiply()
        {
            EnterNumber(9);
            AcceptCharacters("*");
            AcceptCharacters("=");
            AssertOutput("81");
            AcceptCharacters("=");
            AssertOutput("729");
        }

        // Jay
        [Test]
        public void CanDoUnaryDivide()
        {
            EnterNumber(9);
            AcceptCharacters("/");
            AcceptCharacters("=");
            AssertOutput("1");
            AcceptCharacters("=");
            AssertOutput("0.111111111111111");
        }

        // Tiina
        [Test]
        public void CanOperateOnLastResult()
        //  Understands +=  -=  *= and /=  as operating on last result
        //          1+2+= 6     any number -=  0        4*= 16     any number /=  1
        {
            ForInputExpect("1+2+=", "6");
            ForInputExpect("=", "9");

            ForInputExpect("c", "0");

            ForInputExpect("45-=", "0");
            ForInputExpect("=", "-45");

            ForInputExpect("c", "0");

            ForInputExpect("4*=", "16");
            ForInputExpect("=", "64");

            ForInputExpect("c", "0");

            ForInputExpect("123/=", "1");
            ForInputExpect("=", "0.00813008130081301");
        }

    }
}
