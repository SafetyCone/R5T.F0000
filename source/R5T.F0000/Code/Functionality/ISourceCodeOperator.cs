using System;
using System.Runtime.CompilerServices;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ISourceCodeOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Gets the file path of the source code file in which this method is called.
		/// </summary>
		public string GetCurrentSourceCodeFilePath(
			// Must have null, else error CS4021: The CallerFilePathAttribute may only be applied to parameters with default values
			// The null value will be replaced with the source code file path of the code calling this method.
			[CallerFilePath] string callerFilePath = null)
		{
			return callerFilePath;
		}
	}
}