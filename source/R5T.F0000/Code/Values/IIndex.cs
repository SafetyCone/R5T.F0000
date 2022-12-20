using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IIndex : IValuesMarker
	{
		public int NegativeOne => -1;
		public int Zero => 0;
		public int One => 1;

		public int NotFound => this.NegativeOne;
	}
}