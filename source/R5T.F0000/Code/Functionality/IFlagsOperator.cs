using System;

using R5T.T0132;


namespace R5T.F0000
{
    /// <summary>
    /// Operations related to flags enumerations.
    /// </summary>
    // Sources:
    //  * https://devblogs.microsoft.com/premier-developer/dissecting-new-generics-constraints-in-c-7-3/#the-enum-constraint
    //  * https://journal.stuffwithstuff.com/2008/03/05/checking-flags-in-c-enums/
    [FunctionalityMarker]
    public partial interface IFlagsOperator : IFunctionalityMarker
    {
        private static Implementations.IFlagsOperator Implementations => F0000.Implementations.FlagsOperator.Instance;
        private static Unchecked.IFlagsOperator Unchecked => F0000.Unchecked.FlagsOperator.Instance;


        public TEnum Clear<TEnum>(TEnum value, TEnum flags)
            where TEnum : Enum
        {
            Instances.EnumerationOperator.Verify_IsInt32Based<TEnum>();

            var valueAsInt32 = Unchecked.To_Int32(value);
            var flagsAsInt32 = Unchecked.To_Int32(flags);

            var outputAsInt32 = valueAsInt32 & (~flagsAsInt32);

            var output = Unchecked.From_Int32<TEnum>(outputAsInt32);
            return output;
        }

        public TEnum From_Int32<TEnum>(int value)
            where TEnum : Enum
        {
            Instances.EnumerationOperator.Verify_IsInt32Based<TEnum>();

            var output = Unchecked.From_Int32<TEnum>(value);
            return output;
        }

        /// <summary>
        /// Works for an enumeration value of a single flag.
        /// </summary>
        public bool Has_Flag<TEnum>(TEnum value, TEnum flag)
            where TEnum : Enum
        {
            // Use the standard library's implementation, it works for both flag and flags (since both are actually just an integer value).
            var output = Implementations.Has_Flag_StandardLibrary(
                value,
                flag);

            return output;
        }

        /// <summary>
        /// Works for an enumeration value of combined flags.
        /// </summary>
        public bool Has_Flags<TEnum>(TEnum value, TEnum flags)
            where TEnum : Enum
        {
            // Use the standard library's implementation, it works for both flag and flags (since both are actually just an integer value).
            var output = Implementations.Has_Flag_StandardLibrary(
                value,
                flags);

            return output;
        }

        /// <summary>
        /// Allows testing for whether one or more flags are set.
        /// </summary>
        public bool Is_Set<TEnum>(TEnum value, TEnum flags)
            where TEnum : Enum
        {
            var output = value.HasFlag(flags);
            return output;
        }

        public bool Is_NotSet<TEnum>(TEnum value, TEnum flags)
            where TEnum : Enum
        {
            Instances.EnumerationOperator.Verify_IsInt32Based<TEnum>();

            var valueAsInt32 = Unchecked.To_Int32(value);
            var flagsAsInt32 = Unchecked.To_Int32(flags);

            var output = (valueAsInt32 & (~flagsAsInt32)) == 0;
            return output;
        }

        public int To_Int32(Enum value)
        {
            Instances.EnumerationOperator.Verify_IsInt32Based(value);

            var output = Instances.EnumerationOperator_Unchecked.To_Int32(value);
            return output;
        }

        public TEnum Set<TEnum>(TEnum value, TEnum flags)
            where TEnum : Enum
        {
            Instances.EnumerationOperator.Verify_IsInt32Based<TEnum>();

            var valueAsInt32 = Unchecked.To_Int32(value);
            var flagsAsInt32 = Unchecked.To_Int32(flags);

            var outputAsInt32 = valueAsInt32 | flagsAsInt32;

            var output = Unchecked.From_Int32<TEnum>(outputAsInt32);
            return output;
        }
    }
}
