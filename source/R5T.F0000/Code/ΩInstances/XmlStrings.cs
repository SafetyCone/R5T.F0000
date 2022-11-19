using System;


namespace R5T.F0000
{
	public class XmlStrings : IXmlStrings
	{
		#region Infrastructure

	    public static IXmlStrings Instance { get; } = new XmlStrings();

	    private XmlStrings()
	    {
        }

	    #endregion
	}
}