using System;

using R5T.T0132;
using R5T.T0143;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IFileExtensionOperator : IFunctionalityMarker,
		L0053.IFileExtensionOperator
	{
#pragma warning disable IDE1006 // Naming Styles

		[Ignore]
        L0053.IFileExtensionOperator _L0053 => L0053.FileExtensionOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles
    }
}