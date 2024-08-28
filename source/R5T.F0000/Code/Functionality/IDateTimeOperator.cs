using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using R5T.L0089.T000;
using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IDateTimeOperator : IFunctionalityMarker,
        L0053.IDateTimeOperator
	{
        public DateTime From_YYYYMMDD_HHMMSS(string yyyymmdd_hhmmss)
        {
            var output = Instances.DateTimeOperator.ParseExact(
                yyyymmdd_hhmmss,
                Instances.DateTimeFormats.YYYYMMDD_HHMMSS);

            return output;
        }

        public DateTime GetDate(DateTime dateTime)
		{
			var output = dateTime.Date;
			return output;
		}

        public DateTime Get_Today()
        {
            var output = Instances.DateOperator.GetToday();
            return output;
        }

        public WasFound<DateTime> Is_YYYYMMDD(string possible_YYYYMMDD)
        {
            var isYYYYMMDD_HHMMSS = this.TryParseExact(
                possible_YYYYMMDD,
                Instances.DateTimeFormats.YYYYMMDD,
                out var dateTime);

            var output = WasFound.From(isYYYYMMDD_HHMMSS, dateTime);
            return output;
        }

        public WasFound<DateTime> Is_YYYYMMDD_HHMMSS(string possible_YYYYMMDD_HHMMSS)
        {
            var isYYYYMMDD_HHMMSS = this.TryParseExact(
                possible_YYYYMMDD_HHMMSS,
                Instances.DateTimeFormats.YYYYMMDD_HHMMSS,
                out var dateTime);

            var output = WasFound.From(isYYYYMMDD_HHMMSS, dateTime);
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

		public DateTime ToUtc(DateTime local)
        {
			var utc = local.ToUniversalTime();
			return utc;
        }
    }
}