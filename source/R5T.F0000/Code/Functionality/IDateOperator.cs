using System;

using R5T.T0132;
using R5T.L0089.T000;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IDateOperator : IFunctionalityMarker,
        L0066.IDateOperator
	{
        [Obsolete("See R5T.L0066.IDateOperator")]
        public DateTime GetDay(DateTime now)
            => this.Get_Day(now);

        [Obsolete("See R5T.IDateOperator")]
        public new DateTime GetToday_Utc()
            => this.Get_Today_Utc();

        [Obsolete("Use IStringOperator.Get_FormatTemplate()")]
        public string GetFormatTemplate(string format)
            => Instances.StringOperator.Get_FormatTemplate(format);

        public string FormatDateTime(DateTime dateTime, string format)
        {
            var formatTemplate = Instances.StringOperator.Get_FormatTemplate(format);

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