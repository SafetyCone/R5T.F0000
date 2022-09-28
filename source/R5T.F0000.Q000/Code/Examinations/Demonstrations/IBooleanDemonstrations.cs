using System;

using R5T.T0141;


namespace R5T.F0000.Q000
{
	[DemonstrationsMarker]
	public partial interface IBooleanDemonstrations : IDemonstrationsMarker
	{
		/// <summary>
		/// Shows that the <see cref="Boolean.ToString()"/> produces camelcase values (i.e. "True" and "False").
		/// </summary>
		public void DefaultToStringIsCamelcase()
        {
			var value = true;

			var representation = value.ToString();

			Console.WriteLine($"Value: {representation}");
        }
	}
}