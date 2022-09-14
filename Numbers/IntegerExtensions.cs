using System;

namespace Numbers
{
    public static class IntegerExtensions
    {
        /// <summary>
        /// Obtains formalized information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>Information in the form of an enum <see cref="ComparisonSigns"/>
        /// about the relationship of the order of two adjacent digits for all digits of a given number
        /// or null if the information is not defined.</returns>
        public static ComparisonSigns? GetTypeComparisonSigns(this long number)
        {
            ComparisonSigns result = 0b_0000_0000;
            byte prev, next = (byte)(number % 10);
            if (number < 9 & number > -9)
            {
                return null;
            }

            while (number > 9 | number < -9)
            {
                number /= 10;
                prev = (byte)(number % 10);
                if (next == prev)
                {
                    result |= ComparisonSigns.Equals;
                }
                else if (next < prev)
                {
                    result |= ComparisonSigns.MoreThan;
                }
                else
                {
                    result |= ComparisonSigns.LessThan;
                }

                next = prev;
            }

            return result;
        }

        /// <summary>
        /// Gets information in the form of a string about the type of sequence that the digit of a given number represents.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>The information in the form of a string about the type of sequence that the digit of a given number represents.</returns>
        public static string GetTypeOfDigitsSequence(this long number)
        {
            ComparisonSigns? temp = GetTypeComparisonSigns(number);
            string TypeOfDigitsSequence(ComparisonSigns? sings) => sings switch
            {
                ComparisonSigns.LessThan | ComparisonSigns.MoreThan | ComparisonSigns.Equals => "Unordered.",
                ComparisonSigns.LessThan | ComparisonSigns.MoreThan => "Unordered.",
                ComparisonSigns.LessThan | ComparisonSigns.Equals => "Increasing.",
                ComparisonSigns.MoreThan | ComparisonSigns.Equals => "Decreasing.",
                ComparisonSigns.MoreThan => "Strictly Decreasing.",
                ComparisonSigns.LessThan => "Strictly Increasing.",
                ComparisonSigns.Equals => "Monotonous.",
                null => "One digit number.",
                _ => "Unexpected Error",
            };
            return TypeOfDigitsSequence(temp);
        }
    }
}
