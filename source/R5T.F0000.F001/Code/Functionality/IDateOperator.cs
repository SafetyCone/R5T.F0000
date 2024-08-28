using System;

using R5T.T0132;


namespace R5T.F0000.F001
{
	[FunctionalityMarker]
	public partial interface IDateOperator : IFunctionalityMarker,
		F0000.IDateOperator

	{
#pragma warning disable IDE1006 // Naming Styles
		public F0000.IDateOperator _F0000 => F0000.DateOperator.Instance;
        public L0072.IDateOperator _L0072 => L0072.DateOperator.Instance;
#pragma warning restore IDE1006 // Naming Styles


		[Obsolete("See R5T.L0072.IDateOperator")]
		public new DateOnly GetToday_Local()
			=> _L0072.GetToday_Local();

		[Obsolete("See R5T.L0072.IDateOperator")]
		public new DateOnly GetToday_Utc()
			=> _L0072.GetToday_Utc();

        /// <summary>
        /// Chooses <see cref="GetToday_Local"/> as the default.
        /// </summary>
        [Obsolete("See R5T.L0072.IDateOperator")]
        public new DateOnly GetToday()
			=> this.GetToday_Local();

        [Obsolete("See R5T.L0072.IDateOperator")]
        public new DateOnly GetTomorrow_Local()
			=> _L0072.GetTomorrow_Local();

        [Obsolete("See R5T.L0072.IDateOperator")]
        public new DateOnly GetTomorrow_Utc()
			=> _L0072.GetTomorrow_Utc();

		/// <summary>
		/// Chooses <see cref="GetTomorrow_Local"/> as the default.
		/// </summary>
		[Obsolete("See R5T.L0072.IDateOperator")]
		public new DateOnly GetTomorrow()
			=> this.GetTomorrow_Local();

		public string ToString_YYYY_MM_DD_Dash(DateOnly date)
        {
			var representation = $"{date:yyyy-MM-dd}";
			return representation;
        }
	}
}