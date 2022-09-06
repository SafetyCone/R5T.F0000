using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface INowOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Chooses <see cref="GetNowLocal"/> as the default.
		/// </summary>
		public DateTime GetNow()
        {
			var output = this.GetNowLocal();
			return output;
        }

		public DateTime GetNowLocal()
		{
			var output = DateTime.Now;
			return output;
		}

		public DateTime GetNowUtc()
        {
			var output = DateTime.UtcNow;
			return output;
        }
	}
}