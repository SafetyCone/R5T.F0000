using System;

using R5T.T0131;


namespace R5T.F0000.Construction
{
	[ValuesMarker]
	public partial interface IDurations : IValuesMarker
	{
		public int _500 => 500;
		public int _3000 => 3000;

		public int Short => this._500;
		public int Long => this._3000;
	}
}