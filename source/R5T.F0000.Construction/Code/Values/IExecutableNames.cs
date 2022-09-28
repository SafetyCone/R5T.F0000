using System;

using R5T.T0131;


namespace R5T.F0000.Construction
{
	[ValuesMarker]
	public partial interface IExecutableNames : IValuesMarker
	{
		public string Dotnet => "dotnet";
		/// <summary>
		/// "cmd" (which is short for "cmd.exe")
		/// </summary>
		public string Command => "cmd";
	}
}