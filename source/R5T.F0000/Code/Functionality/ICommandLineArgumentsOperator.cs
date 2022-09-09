using System;

using R5T.T0132;


namespace R5T.F0000
{
	[FunctionalityMarker]
	public partial interface ICommandLineArgumentsOperator : IFunctionalityMarker
	{
		public string[] GetCommandLineArguments()
        {
			var output = Environment.GetCommandLineArgs();
			return output;
        }
	}
}