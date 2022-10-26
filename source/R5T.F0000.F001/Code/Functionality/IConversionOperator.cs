using System;

using R5T.T0132;


namespace R5T.F0000.F001
{
	[FunctionalityMarker]
	public partial interface IConversionOperator : IFunctionalityMarker,
		F0000.IConversionOperator
	{
		public DateOnly ToDate(string dateString)
        {
			var output = DateOnly.Parse(dateString);
			return output;
        }
	}
}