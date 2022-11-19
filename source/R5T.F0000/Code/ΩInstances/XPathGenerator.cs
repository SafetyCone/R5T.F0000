using System;


namespace R5T.F0000
{
	public class XPathGenerator : IXPathGenerator
	{
		#region Infrastructure

	    public static IXPathGenerator Instance { get; } = new XPathGenerator();

	    private XPathGenerator()
	    {
        }

	    #endregion
	}
}