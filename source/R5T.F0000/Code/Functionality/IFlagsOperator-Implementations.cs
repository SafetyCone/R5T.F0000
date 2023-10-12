using System;

using R5T.T0132;


namespace R5T.F0000.Implementations
{
    /// <summary>
    /// Operations related to flags enumerations.
    /// </summary>
    [FunctionalityMarker]
    public partial interface IFlagsOperator : IFunctionalityMarker,
        L0066.Implementations.IFlagsOperator
    {
        /// <summary>
        /// Implementation showing how to implement your own flags enumeration value testing.
        /// Note that this implementation does not handle all the possible underlying types, just <see cref="Int32"/>.
        /// </summary>
        public bool Has_Flag_Custom<TEnum>(TEnum value, TEnum flags)
            where TEnum : Enum
        {
            Instances.EnumerationOperator.Verify_IsInt32Based<TEnum>();

            // Cannot use cast:
            //  Error CS0030  Cannot convert type 'T' to 'int'
            //var valueAsInt = (int)value;
                        
            var valueAsInt = Convert.ToInt32(value);
            var flagsAsInt = Convert.ToInt32(flags);

            // Needs parentheses since operator "==" has higher precedence that operator "&".
            var output = (valueAsInt & flagsAsInt) == valueAsInt;
            return output;
        }
    }
}
