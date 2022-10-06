using System;

using R5T.T0132;


namespace R5T.F0000.F001
{
	[FunctionalityMarker]
	public partial interface IDateTimeOperator : IFunctionalityMarker
	{
		public DateTime FromDateAndTime(DateOnly dateOnly, TimeOnly timeOnly)
        {
			var dateTime = dateOnly.ToDateTime(timeOnly);
			return dateTime;
        }

		/// <summary>
		/// Quality-of-life overload for <see cref="FromDateAndTime(DateOnly, TimeOnly)"/>.
		/// </summary>
		public DateTime ToDateTime(DateOnly dateOnly, TimeOnly timeOnly)
		{
			var dateTime = this.FromDateAndTime(dateOnly, timeOnly);
			return dateTime;
		}
	}
}