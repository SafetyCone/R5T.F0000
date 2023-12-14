using System;

using R5T.T0132;


namespace R5T.F0000.F001
{
	[FunctionalityMarker]
	public partial interface IDateOperator : IFunctionalityMarker,
		F0000.IDateOperator
	{
		public new DateOnly GetToday_Local()
        {
			var todayLocalDateTime = Instances.F0000_DateOperator.GetToday_Local();

			var todayLocal = Instances.DateOnlyOperator.From_DateTime(todayLocalDateTime);
			return todayLocal;
        }

		public new DateOnly GetToday_Utc()
		{
			var todayUtcDateTime = Instances.F0000_DateOperator.GetToday_Utc();

			var todayUtc = Instances.DateOnlyOperator.From_DateTime(todayUtcDateTime);
			return todayUtc;
		}

		/// <summary>
		/// Chooses <see cref="GetToday_Local"/> as the default.
		/// </summary>
		public new DateOnly GetToday()
        {
			var today = this.GetToday_Local();
			return today;
        }


		public new DateOnly GetTomorrow_Local()
		{
			var todayLocalDateTime = Instances.F0000_DateOperator.GetTomorrow_Local();

			var todayLocal = Instances.DateOnlyOperator.From_DateTime(todayLocalDateTime);
			return todayLocal;
		}

		public new DateOnly GetTomorrow_Utc()
		{
			var todayUtcDateTime = Instances.F0000_DateOperator.GetTomorrow_Utc();

			var todayUtc = Instances.DateOnlyOperator.From_DateTime(todayUtcDateTime);
			return todayUtc;
		}

		/// <summary>
		/// Chooses <see cref="GetTomorrow_Local"/> as the default.
		/// </summary>
		public new DateOnly GetTomorrow()
		{
			var today = this.GetTomorrow_Local();
			return today;
		}

		public string ToString_YYYY_MM_DD_Dash(DateOnly date)
        {
			var representation = $"{date:yyyy-MM-dd}";
			return representation;
        }
	}
}