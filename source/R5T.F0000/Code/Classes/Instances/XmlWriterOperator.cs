using System;


namespace R5T.F0000
{
	public class XmlWriterOperator : IXmlWriterOperator
	{
		#region Infrastructure

	    public static IXmlWriterOperator Instance { get; } = new XmlWriterOperator();

	    private XmlWriterOperator()
	    {
        }

	    #endregion
	}
}