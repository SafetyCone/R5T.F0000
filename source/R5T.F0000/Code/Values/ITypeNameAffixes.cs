using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface ITypeNameAffixes : IValuesMarker,
		L0066.ITypeNameAffixes
	{
		public string ExtensionsSuffix => "Extensions";
		public string InterfacePrefix => Instances.Strings.I_Uppercase;
        public char InterfacePrefix_Character => Instances.Characters.I_Uppercase;
    }
}