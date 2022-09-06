using System;

using R5T.T0131;


namespace R5T.F0000.Construction
{
	[ValuesMarker]
	public partial interface IExecutableFilePaths : IValuesMarker
	{
		/// <summary>
		/// Note: requires a dotnet executable invocation to run the DLL.
		/// </summary>
		public string EchoingExecutableFilePath => @"C:\Users\David\Dropbox\Organizations\Rivet\Shared\Binaries\R5T.S0012\_Current\R5T.S0012.dll";
		public string MinimalExecutableFilePath => @"C:\Users\David\Dropbox\Organizations\Rivet\Shared\Binaries\R5T.S0013\_Current\R5T.S0013.exe";
	}
}