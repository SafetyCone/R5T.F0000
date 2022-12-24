using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IFileExtensions : IValuesMarker
	{
		public string Dll => "dll";
		public string Xml => "xml";
	}
}