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
        public string Format(
            DateTime dateTime,
            string formatTemplate)
        {
            var output = Instances.StringOperator.Format(
                formatTemplate,
                dateTime);

            return output;
        }

        public DateTime From_YYYYMMDD(string YYYYMMDD)
        {
            var output = DateTime.ParseExact(YYYYMMDD, "yyyyMMdd", CultureInfo.InvariantCulture);
            return output;
        }

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

        public DateTime ParseExact(
            string dateTimeString,
            string format)
        {
            var dateTime = DateTime.ParseExact(
                dateTimeString,
                format,
                Instances.FormatProviders.Default);

            return dateTime;
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

        public bool TryParseExact(
            string @string,
            string format,
            out DateTime dateTime)
        {
            var isDateTimeWithFormat = DateTime.TryParseExact(
                @string,
                format,
                Instances.FormatProviders.Default,
                // Use none to match the old behavior.
                DateTimeStyles.None,
                out dateTime);

            return isDateTimeWithFormat;
        }
    }
}