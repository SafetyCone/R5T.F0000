using System;


namespace R5T.F0000
{
	public class XmlOperator : IXmlOperator
	{
		#region Infrastructure

	    public static IXmlOperator Instance { get; } = new XmlOperator();

	    private XmlOperator()
	    {
        }

	    #endregion
	}


	namespace Implementations
	{
		public class XmlOperator : IXmlOperator
		{
			#region Infrastructure

			public static IXmlOperator Instance { get; } = new XmlOperator();

			private XmlOperator()
			{
			}

			#endregion
		}
	}
}