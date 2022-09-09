using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IXmlStrings : IValuesMarker
	{
		public string Encoding_UTF8 => "utf-8";
		public string Standalone_Default => null;
		public string Standalone_Yes => Instances.Strings.Yes_Lowercase;
		public string Standalone_No => Instances.Strings.No_Lowercase;
		public string Type => "type";
		public string Version_1_0 => "1.0";
		public string XmlSchemaDefinition_Name => this.Xsd_Name;
		public string XmlSchemaDefinition_Url => "http://www.w3.org/2001/XMLSchema";
		public string XmlSchemaInstance_Name => this.Xsi_Name;
		public string XmlSchemaInstance_Url => "http://www.w3.org/2001/XMLSchema-instance";
		public string Xsd_Name => "xsd";
		public string Xsi_Name => "xsi";

	}
}