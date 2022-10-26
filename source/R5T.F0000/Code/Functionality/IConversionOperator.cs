using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IConversionOperator : IFunctionalityMarker
	{
		public double ToDouble(string doubleString)
        {
			var @double = Convert.ToDouble(doubleString);
			return @double;
        }

		public long ToLong(string longString)
		{
			var @long = Convert.ToInt64(longString);
			return @long;
		}

		public string ToString(double @double)
        {
			var doubleString = @double.ToString();
			return doubleString;
        }
	}
}