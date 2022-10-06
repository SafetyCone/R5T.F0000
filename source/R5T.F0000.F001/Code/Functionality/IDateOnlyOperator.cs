using System;

using R5T.T0132;


namespace R5T.F0000.F001
{
	[FunctionalityMarker]
	public partial interface IDateOnlyOperator : IFunctionalityMarker
	{
		public DateOnly FromDateTime(DateTime dateTime)
        {
			var dateOnly = DateOnly.FromDateTime(dateTime);
			return dateOnly;
        }
	}
}