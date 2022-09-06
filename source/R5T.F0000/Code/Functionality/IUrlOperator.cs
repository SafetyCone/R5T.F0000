using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface IUrlOperator : IFunctionalityMarker
	{
		public void OpenInBrowser(string url)
        {
			Instances.CommandLineOperator.Run(startInfo =>
			{
				startInfo.FileName = url;
				startInfo.UseShellExecute = true;
			});
        }
	}
}