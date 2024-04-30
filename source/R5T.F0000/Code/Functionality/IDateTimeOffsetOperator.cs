using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IDateTimeOffsetOperator : IFunctionalityMarker
	{
		public DateTimeOffset FromDateTime_Utc(DateTime dateTimeUtc)
        {
			var dateTimeOffset = new DateTimeOffset(dateTimeUtc, TimeSpan.Zero);

			return dateTimeOffset;
        }

		public DateTimeOffset FromDateTime_Local(DateTime dateTimeLocal)
		{
			var localOffset = this.GetLocalOffsetFromUtc();

			var dateTimeOffset = new DateTimeOffset(dateTimeLocal, localOffset);

			return dateTimeOffset;
		}

		public DateTimeOffset GetNow_Local()
        {
			var nowLocal = DateTimeOffset.Now;
			return nowLocal;
        }

		public DateTimeOffset GetNow_Utc()
		{
			var nowUtc = DateTimeOffset.UtcNow;
			return nowUtc;
		}

		/// <summary>
		/// Chooses <see cref="GetNow_Local"/> as the default.
		/// </summary>
		public DateTimeOffset GetNow()
		{
			var now = this.GetNow_Local();
			return now;
		}

		public TimeSpan GetLocalOffsetFromUtc()
        {
			var currentOffset = Instances.TimeSpanOperator.Get_OffsetFromUtc();
			return currentOffset;
		}
	}
}