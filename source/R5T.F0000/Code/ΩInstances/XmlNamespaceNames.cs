using System;


namespace R5T.F0000
{
	public class XmlNamespaceNames : IXmlNamespaceNames
	{
		#region Infrastructure

	    public static IXmlNamespaceNames Instance { get; } = new XmlNamespaceNames();

	    private XmlNamespaceNames()
	    {
        }

	    #endregion
	}
}