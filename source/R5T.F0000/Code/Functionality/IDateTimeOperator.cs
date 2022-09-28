using System;
using System.Globalization;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IDateTimeOperator : IFunctionalityMarker
	{
		public DateTime From_YYYYMMDD(string YYYYMMDD)
		{
			var output = DateTime.ParseExact(YYYYMMDD, "yyyyMMdd", CultureInfo.InvariantCulture);
			return output;
		}

		public string ToString_MMM_DD_YYYY(DateTime dateTime)
		{
			var output = $"{dateTime:MMM dd, yyyy}";
			return output;
		}

		public string ToString_YYYY_MM_DD(DateTime dateTime)
		{
			var output = $"{dateTime:yyyy-MM-dd}";
			return output;
		}

		public string ToString_YYYYMMDD_HHMMSS(DateTime dateTime)
		{
			var output = $"{dateTime:yyyyMMdd HHmmss}";
			return output;
		}
	}
}