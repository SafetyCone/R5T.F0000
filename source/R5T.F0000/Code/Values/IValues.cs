using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IValues : IValuesMarker,
		L0053.IValues
	{
		public const int NoLimitMaximumResultsCount_Constant = -1;
		public int NoLimitMaximumResultsCount => IValues.NoLimitMaximumResultsCount_Constant;

		public const string ExplicitNone_Constant = "<None>";
		public string ExplicitNone => IValues.ExplicitNone_Constant;
    }
}