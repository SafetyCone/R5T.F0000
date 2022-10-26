using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

		/// <summary>
		/// Oldest first, to youngest last.
		/// </summary>
		public IEnumerable<DateTime> OrderChronologically(IEnumerable<DateTime> dates)
        {
			var output = dates.OrderBy(x => x);
			return output;
        }

		/// <summary>
		/// Youngest first, to oldest last.
		/// </summary>
		public IEnumerable<DateTime> OrderReverseChronologically(IEnumerable<DateTime> dates)
		{
			var output = dates.OrderByDescending(x => x);
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

		/// <summary>
		/// Example output: 20221014 151201
		/// </summary>
		public string ToString_YYYYMMDD_HHMMSS(DateTime dateTime)
		{
			var output = $"{dateTime:yyyyMMdd HHmmss}";
			return output;
		}

		public DateTime ToUtc(DateTime local)
        {
			var utc = local.ToUniversalTime();
			return utc;
        }
	}
}