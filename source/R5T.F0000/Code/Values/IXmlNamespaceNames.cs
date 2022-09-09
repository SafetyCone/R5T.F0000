using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IXmlNamespaceNames : IValuesMarker
	{
		/// <summary>
		/// xmlns
		/// </summary>
		public string XmlNamespaceName => "xmlns";
	}
}