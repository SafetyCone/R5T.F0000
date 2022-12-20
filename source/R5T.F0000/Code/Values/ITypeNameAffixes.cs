using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface ITypeNameAffixes : IValuesMarker
	{
		public string AttributeSuffix => "Attribute";
		public string ExtensionsSuffix => "Extensions";
		public string InterfacePrefix => Instances.Strings.I_Uppercase;
        public char InterfacePrefix_Character => Instances.Characters.I_Uppercase;
    }
}