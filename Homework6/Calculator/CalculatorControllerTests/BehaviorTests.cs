using Calculator;
using NUnit.Framework;

namespace CalculatorControllerTests
{
    [TestFixture]
    class BehaviorTests
    {
        // Tiina
        [Test]
        public void CalculatorStartsOffShowingZero()
        {
            // Make a new calculator controller
            // Check that GetOutput() is equal to "0"

            CalculatorController calc1 = new CalculatorController();
            
            // The two following lines are equivalent.  One uses the "constraints" model, and one uses the "static test assertions" model.
            Assert.That(calc1.GetOutput(), Is.EqualTo("0"));  // Google "NUnit constraints"
            Assert.AreEqual(calc1.GetOutput(), "0");    // Google "NUnit static test assertions"

            // In this class, we will prefer the constraints-based approach, as it reads more like English and gives more detailed
            // and precise failure messages.
            // It also avoids the ambiguity as to which parameters is the "expected" result and which is the "actual" result.
        }

        // Ahsan, Alex, Bryan, Jay, Yana
        [Test]
        public void CalculatorClearButtonResetsValueToZero()
        {
            // Make a new calculator controller
            // Enter a non-zero number
            // Click the clear button
            // Assert GetOutput() is equal to "0"

            CalculatorController calc1 = new CalculatorController();
            calc1.AcceptCharacter('1');
            Assert.That(calc1.GetOutput(), Is.EqualTo("1"));
            calc1.AcceptCharacter('2');
            Assert.That(calc1.GetOutput(), Is.EqualTo("12"));
            calc1.AcceptCharacter('c');
            Assert.That(calc1.GetOutput(), Is.EqualTo("0"));  
        }
    }
}
