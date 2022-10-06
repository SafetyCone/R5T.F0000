using System;


namespace R5T.F0000
{
	public class XmlWriterSettingsOperator : IXmlWriterSettingsOperator
	{
		#region Infrastructure

	    public static IXmlWriterSettingsOperator Instance { get; } = new XmlWriterSettingsOperator();

	    private XmlWriterSettingsOperator()
	    {
        }

	    #endregion
	}
}