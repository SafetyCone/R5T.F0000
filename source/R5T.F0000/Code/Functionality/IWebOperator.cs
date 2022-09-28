using System;
using System.Diagnostics;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IWebOperator : IFunctionalityMarker
	{
		public void OpenUrlInDefaultBrowser(string url)
        {
            Process.Start(new ProcessStartInfo(url)
            {
                UseShellExecute = true,
            });
        }
	}
}