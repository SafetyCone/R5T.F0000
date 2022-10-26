using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface ITypeNameAffixes : IValuesMarker
	{
		public string InterfacePrefix => Instances.Strings.I_UpperCase;
	}
}