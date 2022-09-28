using System;


namespace R5T.F0000.Q000
{
	public class XmlDemonstrations : IXmlDemonstrations
	{
		#region Infrastructure

	    public static XmlDemonstrations Instance { get; } = new();

	    private XmlDemonstrations()
	    {
        }

	    #endregion
	}
}