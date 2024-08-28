using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IDateTimeOffsetOperator : IFunctionalityMarker,
		L0066.IDateTimeOffsetOperator
	{
		public DateTimeOffset FromDateTime_Utc(DateTime dateTimeUtc)
			=> this.From_DateTime_Utc(dateTimeUtc);

		public DateTimeOffset FromDateTime_Local(DateTime dateTimeLocal)
			=> this.From_DateTime_Local(dateTimeLocal);

		public DateTimeOffset GetNow_Local()
			=> this.Get_Now_Local();

		public DateTimeOffset GetNow_Utc()
			=> this.Get_Now_Utc();

		/// <summary>
		/// Chooses <see cref="GetNow_Local"/> as the default.
		/// </summary>
		public DateTimeOffset GetNow()
			=> this.GetNow_Local();

		public TimeSpan GetLocalOffsetFromUtc()
            => this.Get_LocalOffsetFromUtc();
    }
}