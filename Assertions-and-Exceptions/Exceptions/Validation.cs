using System;

public static class Validation
{
    public static void CheckForPositiveNumber(double value, string paramName)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(paramName, paramName + " should be positive.");
        }
    }

    public static void CheckForOutOfRange(double value, double minValue, double maxValue, string paramName)
    {
        if (value < minValue || maxValue > value)
        {
            throw new ArgumentOutOfRangeException(paramName, string.Format("{0} should be in range [{1}..{2}].", paramName, minValue, maxValue));
        }
    }

    public static void CheckForEmtyOrNull(string value, string paramName)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentNullException("The " + paramName + " should not be empty or null.", paramName);
        }
    }
}

