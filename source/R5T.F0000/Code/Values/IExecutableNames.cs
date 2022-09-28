using System;

using R5T.T0131;


namespace R5T.F0000
{
	[ValuesMarker]
	public partial interface IExecutableNames : IValuesMarker
	{
		/// <summary>
		/// "cmd" (also known as "cmd.exe")
		/// </summary>
		public string Cmd => "cmd";
	}
}