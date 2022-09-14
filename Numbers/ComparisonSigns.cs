using System;

namespace Numbers
{
    /// <summary>
    /// Specifies comparison signs: less than, more than and equals.
    /// </summary>
    [Flags]
    public enum ComparisonSigns
    {
        LessThan = 0b_0000_0001,
        MoreThan = 0b_0000_0010,
        Equals = 0b_0000_0100,
    }
}
