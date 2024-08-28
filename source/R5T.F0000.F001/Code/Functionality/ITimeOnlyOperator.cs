using System;

using R5T.T0132;


namespace R5T.F0000.F001
{
	[FunctionalityMarker]
	public partial interface ITimeOnlyOperator : IFunctionalityMarker,
        L0072.ITimeOnlyOperator
	{
        public DateOnly GetDateForNextTime_Local(TimeOnly localTime, TimeOnly localNow)
        {
            var timeIsAfterNow = this.TimeIsAfterNow_Local(localTime, localNow);

            var dateForNextTime = timeIsAfterNow
                ? Instances.DateOperator_L0072.GetToday_Local()
                : Instances.DateOperator_L0072.GetTomorrow_Local();
                ;

            return dateForNextTime;
        }

        /// <summary>
        /// Gets the next datetime which the local time occurs.
        /// <inheritdoc cref="Documentation.NextDateAfterTime"/>
        /// </summary>
        public DateTime GetNextDateTime_Local(TimeOnly localTime, TimeOnly localNow)
        {
            var dateForNextTime = this.GetDateForNextTime_Local(localTime, localNow);

            var nextLocalDateTime = Instances.DateTimeOperator.From_DateAndTime(dateForNextTime, localTime);
            return nextLocalDateTime;
        }

        /// <summary>
        /// Gets the next datetime offset at which the local time occurs.
        /// <inheritdoc cref="Documentation.NextDateAfterTime"/>
        /// </summary>
        public DateTimeOffset GetNextDateTimeOffset_Local(TimeOnly localTime, TimeOnly localNow)
        {
            var nextLocalDateTime = this.GetNextDateTime_Local(localTime, localNow);

            var nextDateTimeOffset = DateTimeOffsetOperator.Instance.FromDateTime_Local(nextLocalDateTime);
            return nextDateTimeOffset;
        }

        /// <inheritdoc cref="GetNextDateTimeOffset_Local(TimeOnly, TimeOnly)"/>
        public DateTimeOffset GetNextDateTimeOffset_Local(TimeOnly localTime)
        {
            var localNow = this.GetNow_Local();

            var nextDateTimeOffset = this.GetNextDateTimeOffset_Local(localTime, localNow);
            return nextDateTimeOffset;
        }

        public TimeOnly GetNow_Local()
        {
            var nowLocalDateTime = Instances.F0000_DateOperator.GetNow_Local();

            var nowLocal = this.From_DateTime(nowLocalDateTime);
            return nowLocal;
        }

        public TimeOnly GetNow_Utc()
        {
            var nowUtcDateTime = Instances.F0000_DateOperator.GetNow_Utc();

            var nowUtc = this.From_DateTime(nowUtcDateTime);
            return nowUtc;
        }

        /// <summary>
        /// Chooses <see cref="GetNow_Local"/> as the default.
        /// </summary>
        public TimeOnly GetNow()
        {
            var now = this.GetNow_Local();
            return now;
        }

        public bool TimeIsAfterNow_Local(TimeOnly localTime, TimeOnly localNow)
        {
            var timeIsAfterNow = localTime > localNow;
            return timeIsAfterNow;
        }
    }
}