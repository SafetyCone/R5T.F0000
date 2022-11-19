using System;


namespace R5T.F0000
{
	public class XmlPathOperator : IXmlPathOperator
	{
		#region Infrastructure

	    public static IXmlPathOperator Instance { get; } = new XmlPathOperator();

	    private XmlPathOperator()
	    {
        }

	    #endregion
	}
}