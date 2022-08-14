using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface ISeeds : IValuesMarker
	{
		public int Default => this.Pi;

		public int Pi => 31415;
	}
}