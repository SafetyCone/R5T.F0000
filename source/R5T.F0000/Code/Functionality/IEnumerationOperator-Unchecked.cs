using System;

using R5T.T0132;


namespace R5T.F0000.Unchecked
{
	[FunctionalityMarker]
	public partial interface IEnumerationOperator : IFunctionalityMarker
	{
        public TEnum From_Int32<TEnum>(int value)
            where TEnum : Enum
        {
            // Boxes, but ok.
            var output = (TEnum)(object)value;
            return output;
        }

        public int To_Int32(Enum value)
        {
            // Boxing is lame, but it happened when the the enumeration was made into an Enum class instance.
            var output = (int)(IConvertible)value;
            return output;
        }
    }
}