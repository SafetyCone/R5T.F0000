using System;


namespace R5T.F0000
{
	public class XmlNamespaceNames : IXmlNamespaceNames
	{
		#region Infrastructure

	    public static XmlNamespaceNames Instance { get; } = new();

	    private XmlNamespaceNames()
	    {
        }

	    #endregion
	}
}