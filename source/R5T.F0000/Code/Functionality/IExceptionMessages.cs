using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IExceptionMessages : IFunctionalityMarker
	{
		public string TypeNameValueWasEmpty => "Type name value was empty.";
    }
}