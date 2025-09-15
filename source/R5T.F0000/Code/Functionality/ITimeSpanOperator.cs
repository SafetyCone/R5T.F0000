using System;

using R5T.T0132;
using R5T.T0143;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ITimeSpanOperator : IFunctionalityMarker,
		L0066.ITimeSpanOperator
	{
#pragma warning disable IDE1006 // Naming Styles

		[Ignore]
        L0066.ITimeSpanOperator _L0066 => L0066.TimeSpanOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}