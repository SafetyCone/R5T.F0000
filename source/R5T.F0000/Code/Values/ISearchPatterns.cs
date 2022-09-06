using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface ISearchPatterns : IValuesMarker
	{
		public string All => Z0000.Instances.Strings.Asterix;
	}
}