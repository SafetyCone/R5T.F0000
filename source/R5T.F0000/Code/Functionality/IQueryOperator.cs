using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IQueryOperator : IFunctionalityMarker
	{
		public bool IsNoLimitMaximumResultsCount(int value)
		{
			var output = Values.Instance.NoLimitMaximumResultsCount == value;
			return output;
		}
	}
}