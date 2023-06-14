using System;

using R5T.T0132;


namespace R5T.F0000.Unchecked
{
    [FunctionalityMarker]
    public partial interface IFlagsOperator : IFunctionalityMarker
    {
        public TEnum From_Int32<TEnum>(int value)
            where TEnum : Enum
        {
            var output = Instances.EnumerationOperator_Unchecked.From_Int32<TEnum>(value);
            return output;
        }

        public int To_Int32(Enum value)
        {
            var output = Instances.EnumerationOperator_Unchecked.To_Int32(value);
            return output;
        }
    }
}
