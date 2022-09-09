using System;


namespace R5T.F0000
{
	public class XmlOperator : IXmlOperator
	{
		#region Infrastructure

	    public static XmlOperator Instance { get; } = new();

	    private XmlOperator()
	    {
        }

	    #endregion
	}
}