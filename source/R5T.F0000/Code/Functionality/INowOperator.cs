using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface INowOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Chooses <see cref="GetNow_Local"/> as the default.
		/// </summary>
		public DateTime GetNow()
        {
			var output = this.GetNow_Local();
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
		/// Chooses <see cref="GetToday_Local"/> as the default.
		/// </summary>
		public DateTime GetToday()
		{
			var output = this.GetToday_Local();
			return output;
		}

		public DateTime GetToday_Local()
		{
			var now = this.GetNow_Local();

			var output = now.Date;
			return output;
		}

        public DateTime GetToday_Utc()
        {
            var now = this.GetNow_Utc();

            var output = now.Date;
            return output;
        }
    }
}