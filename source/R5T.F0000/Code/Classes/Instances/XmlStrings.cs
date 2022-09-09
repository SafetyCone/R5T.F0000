using System;


namespace R5T.F0000
{
	public class XmlStrings : IXmlStrings
	{
		#region Infrastructure

	    public static XmlStrings Instance { get; } = new();

	    private XmlStrings()
	    {
        }

	    #endregion
	}
}