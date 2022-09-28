using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IEnumerationOperator : IFunctionalityMarker
	{
		public string GetStringRepresentation<TEnum>(TEnum @enum)
			where TEnum : Enum
        {
			var output = @enum.ToString();
			return output;
        }
	}
}