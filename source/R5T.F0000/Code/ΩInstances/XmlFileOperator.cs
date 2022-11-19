using System;


namespace R5T.F0000
{
	public class XmlFileOperator : IXmlFileOperator
	{
		#region Infrastructure

	    public static IXmlFileOperator Instance { get; } = new XmlFileOperator();

	    private XmlFileOperator()
	    {
        }

	    #endregion
	}
}