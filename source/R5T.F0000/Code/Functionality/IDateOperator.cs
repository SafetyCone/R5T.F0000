using System;

using R5T.T0132;
using R5T.L0089.T000;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IDateOperator : IFunctionalityMarker,
        L0066.IDateOperator
	{
        public DateTime From_YYYYMMDD(string yyyymmdd)
        {
            var output = Instances.DateTimeOperator.ParseExact(
                yyyymmdd,
                Instances.DateTimeFormats.YYYYMMDD);

            return output;
        }

        public DateTime GetDefault()
        {
            var output = default(DateTime);
            return output;
        }

        public DateTime GetMaximum()
        {
            var output = DateTime.MaxValue;
            return output;
        }

        public DateTime GetMinimum()
        {
            var output = DateTime.MinValue;
            return output;
        }

        public DateTime GetNow_Local()
        {
            var output = DateTime.Now;
            return output;
        }

        public DateTime GetNow_Utc()
        {
            var output = DateTime.UtcNow;
            return output;
        }

        /// <summary>
        /// Chooses <see cref="GetNow_Local"/> as the default.
        /// </summary>
        public DateTime GetNow()
        {
            var output = this.GetNow_Local();
            return output;
        }

        public DateTime GetDay(DateTime now)
        {
            var output = new DateTime(
                now.Year,
                now.Month,
                now.Day);

            return output;
        }

        public DateTime GetTomorrow(DateTime dateTime)
        {
            var tomorrow = dateTime.AddDays(1);
            return tomorrow;
        }

        public DateTime GetTomorrow_Local()
        {
            var todayLocal = this.GetToday_Local();

            var tomorrowLocal = this.GetTomorrow(todayLocal);
            return tomorrowLocal;
        }

        public DateTime GetTomorrow_Utc()
        {
            var todayUtc = this.GetToday_Utc();

            var tomorrowUtc = this.GetTomorrow(todayUtc);
            return tomorrowUtc;
        }

        /// <summary>
        /// Chooses <see cref="GetTomorrow_Local"/> as the default.
        /// </summary>
        public DateTime GetTomorrow()
        {
            var tomorrow = this.GetTomorrow_Local();
            return tomorrow;
        }

        public DateTime GetToday_Local()
        {
            var nowLocal = this.GetNow_Local();

            var todayLocal = this.GetDay(nowLocal);
            return todayLocal;
        }

        public DateTime GetToday_Utc()
        {
            var nowUtc = this.GetNow_Utc();

            var todayUtc = this.GetDay(nowUtc);
            return todayUtc;
        }

        /// <summary>
        /// Chooses <see cref="GetToday_Local"/> as the default.
        /// </summary>
        public DateTime GetToday()
        {
            var today = this.GetToday_Local();
            return today;
        }

        public DateTime GetYesterday()
        {
            var today = this.GetToday();

            var yesterday = today.AddDays(-1);
            return yesterday;
        }

        public string GetFormatTemplate(string format)
        {
            var formatTemplate = $"{{0:{format}}}";
            return formatTemplate;
        }

        public string FormatDateTime(DateTime dateTime, string format)
        {
            var formatTemplate = this.GetFormatTemplate(format);

            var output = Instances.StringOperator.Format(formatTemplate, dateTime);
            return output;
        }

        public bool IsDefault(DateTime dateTime)
        {
            var output = dateTime == default;
            return output;
        }

        public WasFound<DateTime> IsYYYYMMDD(string possibleYYYYMMDD)
        {
            var isYYYYMMDD = Instances.DateTimeOperator.TryParseExact(
                possibleYYYYMMDD,
                Instances.DateTimeFormats.YYYYMMDD,
                out var dateTime);

            var output = WasFound.From(isYYYYMMDD, dateTime);
            return output;
        }

        public string ToString_YYYY_MM_DD_Dashed(DateTime dateTime)
        {
            var output = this.FormatDateTime(
                dateTime,
                Instances.DateTimeFormats.YYYY_MM_DD_Dashed);

            return output;
        }
    }
}