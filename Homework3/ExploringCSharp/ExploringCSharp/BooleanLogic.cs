namespace ExploringCSharp
{
    public class BooleanLogic
    {
        public bool NegatesItsInput(bool input)
        {
            if (input)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool NegatesItsInputSingleLine(bool input)
        {
            return !input;
        }

        public bool TrueIfBothInputsAreTrue(bool input1, bool input2)
        {
            if (input1)
            {
                if (input2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (input1)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool TrueIfBothInputsAreTrueSingleLine(bool input1, bool input2)
        {
            return input1 && input2;
        }

        public bool TrueIfEitherInputIsTrue(bool input1, bool input2)
        {
            // Use resharper on this to reduce it to a single line.
            if (input1)
            {
                if (input2)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (input2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool TrueIfEitherInputIsTrueSingleLine(bool input1, bool input2)
        {
            return input1 || input2;
        }

        public bool MustPayExtraSurchargeToRentACar(string gender, int age)
        {
            // Implement this one from scratch so that all tests pass.  
            // Age is a whole number.  The intended values and meanings of the string "gender"
            // can be inferred from the tests.
            switch (gender)
            {
                case "F": // If the driver is female, she pays no extra charge, regardless of age.
                    return false;
                case "M": // If the driver is male, he'll pay an extra charge until he's 25. The "=" made the tests fail, so it was removed.
                    return age < 25 ? true : false;
                default: // For any other driver, the fee will be paid.  We are a business, after all.
                    return true;
            }
        }
    }
}
