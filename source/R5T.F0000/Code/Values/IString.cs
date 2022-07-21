using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IString : IValuesMarker
	{
		public int IndexOfNotFound => Instances.Index.NegativeOne;
	}
}