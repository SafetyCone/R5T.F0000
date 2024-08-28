using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IConversionOperator : IFunctionalityMarker,
		L0066.IConversionOperator
	{
		public double ToDouble(string doubleString)
			// Call into better-named base operator methods.
			=> this.To_Double(doubleString);

		public long ToLong(string longString)
            // Call into better-named base operator methods.
            => this.To_Long(longString);

		public string ToString(double @double)
            // Call into better-named base operator methods.
            => this.To_String(@double);
	}
}