using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IDateTimeOperator : IFunctionalityMarker
	{
		public string ToString_YYYYMMDD_HHMMSS(DateTime dateTime)
		{
			var output = $"{dateTime:yyyyMMdd HHmmss}";
			return output;
		}
	}
}