using System;


namespace R5T.F0000.Construction
{
	public class XmlOperations : IXmlOperations
	{
		#region Infrastructure

	    public static IXmlOperations Instance { get; } = new XmlOperations();

	    private XmlOperations()
	    {
        }

	    #endregion
	}
}