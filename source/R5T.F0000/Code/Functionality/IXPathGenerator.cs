using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IXPathGenerator : IFunctionalityMarker
	{
		public string FromCurrentNode_SelectChildWithGrandchild(string childName, string grandChildName)
        {
			var xPath  = $"./{childName}[{grandChildName}]";
			return xPath;
        }
	}
}