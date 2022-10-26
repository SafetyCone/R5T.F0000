using System;
using System.Globalization;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IFormatProviders : IValuesMarker
	{
		/// <summary>
		/// The <see cref="CultureInfo.InvariantCulture"/> value.
		/// </summary>
		public IFormatProvider Default => CultureInfo.InvariantCulture;
	}
}